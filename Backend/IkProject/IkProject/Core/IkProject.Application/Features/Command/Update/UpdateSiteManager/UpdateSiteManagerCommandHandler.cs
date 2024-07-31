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

    public class UpdateSiteManagerCommandHandler : IRequestHandler<UpdateSiteManagerCommand, Unit>
    {
        private readonly UserManager<SiteManager> _userManager;
        private readonly IFileHelper _fileHelper;

        public UpdateSiteManagerCommandHandler(UserManager<SiteManager> userManager, IFileHelper fileHelper)
        {
            _userManager = userManager;
            _fileHelper = fileHelper;
        }

        public async Task<Unit> Handle(UpdateSiteManagerCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);

            var imgPath = _fileHelper.Update(request.Image, user.Id.ToString());

            if (user == null)
            {
                throw new NotFoundException(Messages.UserNotFound);
            }

            if (imgPath == null)
            {
                throw new NotFoundException(Messages.ImageNotSaved);
            }


            user.Address = request.Address;
            user.PhoneNumber = request.PhoneNumber;
            user.ImgPath = imgPath;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                throw new NotFoundException(Messages.UserUpdateFailed);
            }
            return Unit.Value;

        }
    }
}
