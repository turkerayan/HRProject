using IkProject.Application.Abstractions;
using IkProject.Application.Abstractions.Services;
using IkProject.Application.Features.Command.Create.CreateCompanyManager;
using IkProject.Application.Features.Command.Create.Register;
using IkProject.Domain.Identities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Command.Create.AddSiteManager
{

    public class CreateSiteManagerCommandHandler : IRequestHandler<CreateSiteManagerCommand, Unit>
    {
        private readonly UserManager<Domain.Identities.SiteManager> _userManager;
        private readonly IMapper _mapper;
        private readonly IFileHelper _fileHelper;
        private readonly IMailServices _mailServices;
        public CreateSiteManagerCommandHandler(UserManager<Domain.Identities.SiteManager> userManager, IMapper mapper, IFileHelper fileHelper, IMailServices mailServices)
        {
            _userManager = userManager;
            _mapper = mapper;
            _fileHelper = fileHelper;
            _mailServices = mailServices;
        }

        public async Task<Unit> Handle(CreateSiteManagerCommand request, CancellationToken cancellationToken)
        {
            Domain.Identities.SiteManager appUser = _mapper.Map<Domain.Identities.SiteManager, CreateSiteManagerCommand>(request);

            //var checkUser = await _userManager.Users.AnyAsync(cm => cm.Email == request.Email);

            //if (checkUser) throw new BadRequestException("Aynı isimde email adresi bulunmaktadır.");

            appUser.SecurityStamp = Guid.NewGuid().ToString();

            appUser.UserName = request.Email;

            _ = await _userManager.CreateAsync(appUser, request.Password);

            await _userManager.AddToRoleAsync(appUser, "SiteManager");

            appUser.ImgPath = _fileHelper.Add(request.ImgPath, userId: appUser.Id.ToString());

            await _userManager.UpdateAsync(appUser);

            //string resetToken = await _userManager.GeneratePasswordResetTokenAsync(appUser);

            //await _mailServices.SendCompanyManagerResetPasswordAsycn(appUser, resetToken);

            return Unit.Value;

        }
    }
}
