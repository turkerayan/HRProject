using IkProject.Application.Abstractions.Services;
using IkProject.Application.Constants;
using IkProject.Domain.Identities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using SendGrid.Helpers.Errors.Model;
using System.Text;

namespace IkProject.Application.Features.Command.Create.RePasswordToken
{
    public class RePasswordTokenCommandHandler : IRequestHandler<RePasswordTokenCommand, Unit>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMailServices _mailService;

        public RePasswordTokenCommandHandler(UserManager<AppUser> userManager, IMailServices mailService)
        {
            _userManager = userManager;
            _mailService = mailService;
        }

        public async Task<Unit> Handle(RePasswordTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null) throw new Exception(Messages.UserNotFound);

            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            byte[] bytes = Encoding.UTF8.GetBytes(resetToken);
            resetToken = WebEncoders.Base64UrlEncode(bytes);

            await _mailService.SendPasswordResetMailAsycn(user, resetToken);

            return Unit.Value;
        }
    }
}
