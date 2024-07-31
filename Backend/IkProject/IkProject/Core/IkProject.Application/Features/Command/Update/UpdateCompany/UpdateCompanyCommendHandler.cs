using IkProject.Application.Abstractions;
using IkProject.Application.Constants;
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

namespace IkProject.Application.Features.Command.Update.UpdateCompany
{
    public class UpdateCompanyCommendHandler : IRequestHandler<UpdateCompanyCommend, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFileHelper _fileHelper;
        private readonly UserManager<CompanyManger> _userManager;

        public UpdateCompanyCommendHandler(IUnitOfWork unitOfWork, IMapper mapper, IFileHelper fileHelper, UserManager<CompanyManger> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fileHelper = fileHelper;
            _userManager = userManager;
        }

        public async Task<Unit> Handle(UpdateCompanyCommend request, CancellationToken cancellationToken)
        {
            var company = await _unitOfWork.GetReadRepository<Domain.Company.Company>().GetByIdAsync(request.Id.ToString());

            if (company is null)
                throw new BadRequestException("Şirket bulunamadı");

            if (request.ImgPath is not null)
                company.ImgPath = _fileHelper.Update(request.ImgPath, request.Id.ToString(), LocalPaths.CompanyImage);

            if (request.ContractStartDate is not null)
                company.ContractStartDate = (DateTime)request.ContractStartDate;

            if (request.ContractEndDate is not null)
                company.ContractEndDate = (DateTime)request.ContractEndDate;


            await _unitOfWork.GetWriteRepository<Domain.Company.Company>().UpdateAsync(company);

            return Unit.Value;
        }
    }
}
