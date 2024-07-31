using IkProject.Application.UnitOfWorks;
using IkProject.Domain.Identities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Command.Delete.DeleteCompany
{
    public class DeleteSiteManagerCommandHandler : IRequestHandler<DeleteSiteManagerCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<SiteManager> _userManager;
        public DeleteSiteManagerCommandHandler(IUnitOfWork unitOfWork, UserManager<SiteManager> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<Unit> Handle(DeleteSiteManagerCommand request, CancellationToken cancellationToken)
        {
            var siteManager = await _userManager.FindByIdAsync(request.Id.ToString());

            if (siteManager == null) throw new BadRequestException("Kullanıcı bulunamadı");

            await _userManager.DeleteAsync(siteManager);

            return Unit.Value;
        }
    }
}
