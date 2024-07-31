using IkProject.Domain.Identities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Command.Update.UpdatePassword
{
    public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommand, Unit>
    {
        private readonly UserManager<AppUser> _userManager;

        public UpdatePasswordCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
        {

            var user = await _userManager.FindByIdAsync(request.Id);

            byte[] bytes = WebEncoders.Base64UrlDecode(request.ResetToken);
            var token = Encoding.UTF8.GetString(bytes);

            var check = await _userManager.VerifyUserTokenAsync(user, _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", token);

            if (!check) throw new Exception();

            var res = await _userManager.ResetPasswordAsync(user, token, request.NewPassword);

            return Unit.Value;
        }
    }
}
