using IkProject.Application.Abstractions;
using IkProject.Application.Constants;
using IkProject.Application.DTOs.CompanyManager;
using IkProject.Application.DTOs.Personel;
using IkProject.Application.Features.Queries.Company.GetCompany;
using IkProject.Application.UnitOfWorks;
using IkProject.Domain.Identities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;


namespace IkProject.Application.Features.Queries.Company.GetCompanySiteManager
{
    public class GetCompanySiteManagerHandler : IRequestHandler<GetCompanySiteManagerRequest, GetCompanySiteManagerResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<CompanyManger> _userManager;

        public GetCompanySiteManagerHandler(IUnitOfWork unitOfWork, IMapper mapper, UserManager<CompanyManger> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<GetCompanySiteManagerResponse> Handle(GetCompanySiteManagerRequest request, CancellationToken cancellationToken)
        {

            var company = await _unitOfWork.GetReadRepository<Domain.Company.Company>().GetAsync(
                predicate: x => x.Id == request.Id,
                include: x => x.Include(x => x.CompanyManger).Include(p=>p.Personels)
                );


            if (company is null) throw new NotFoundException("Company not found");

            _ = _mapper.Map<CompanyManagerDto, CompanyManger>(new CompanyManger());

            _ = _mapper.Map<PersonalDto, Personal>(new Personal());

            var response = _mapper.Map<GetCompanySiteManagerResponse, Domain.Company.Company>(company);

            return response;

        }
    }
}
