using IkProject.Application.Abstractions;
using IkProject.Application.Constants;

using IkProject.Domain.Identities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Command.Update.UpdateUser
{

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IFileHelper _fileHelper;

        public UpdateUserCommandHandler(UserManager<AppUser> userManager, IFileHelper fileHelper)
        {
            _userManager = userManager;
            _fileHelper = fileHelper;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);

            if (request.Image is not null)
            {
            var imgPath = _fileHelper.Update(request.Image, user.Id.ToString());
                if (imgPath == null)
                {
                    throw new NotFoundException(Messages.ImageNotSaved);
                }
                user.ImgPath = imgPath;
            }


            if (user == null)
            {
                throw new NotFoundException(Messages.UserNotFound);
            }

       


            user.Address = request.Address;
            user.PhoneNumber = request.PhoneNumber;
          

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                throw new NotFoundException(Messages.UserUpdateFailed);
            }
            return Unit.Value;

        }
    }
}
