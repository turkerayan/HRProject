using IkProject.Application.Abstractions;
using IkProject.Application.Constants;
using IkProject.Domain.Identities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using SendGrid.Helpers.Errors.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace IkProject.Application.Features.Quaries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQueryRequest, LoginQueryResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenServices _tokenServices;
        public LoginQueryHandler(UserManager<AppUser> userManager, ITokenServices tokenServices)
        {
            _userManager = userManager;
            _tokenServices = tokenServices;
        }

        public async Task<LoginQueryResponse> Handle(LoginQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null) throw new Exception(Messages.UsernameOrPasswordInvalid);

            var CheckPassword = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!CheckPassword) throw new Exception(Messages.UsernameOrPasswordInvalid);

            var roles = await _userManager.GetRolesAsync(user);
            var token = await _tokenServices.CreateToken(user, roles);

            var _token = new JwtSecurityTokenHandler().WriteToken(token);

            user.Token = _token;

            await _userManager.UpdateAsync(user);

            var response = new LoginQueryResponse()
            {
                Token = _token,
                Expiration = token.ValidTo,
            };
            return response;
        }
    }
}
