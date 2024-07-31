using IkProject.Application.Abstractions;
using IkProject.Application.DTOs.CompanyManager;
using IkProject.Application.DTOs.Personel;
using IkProject.Application.UnitOfWorks;
using IkProject.Domain.Identities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace IkProject.Application.Features.Queries.Company.GetAllCompany
{
    public class GetAllCompanyHandler : IRequestHandler<GetAllCompanyRequest, IList<GetAllCompanyResponse>>
    {
        private readonly UserManager<CompanyManger> _userManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCompanyHandler(IMapper mapper, IUnitOfWork unitOfWork, UserManager<CompanyManger> userManager)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<IList<GetAllCompanyResponse>> Handle(GetAllCompanyRequest request, CancellationToken cancellationToken)
        {
            if (request.CurrentPage < 0 || request.PageSize < 0)
            {
                throw new Exception("Hatalı istek");
            }
            var readRepo = _unitOfWork.GetReadRepository<Domain.Company.Company>();


            var companyList = await readRepo.GetAllByPagingAsync(
                include: c => c.Include(a => a.CompanyManger).Include(p => p.Personels),
                predicate: c => c.Status != Domain.Base.DataStatus.Deleted,
                orderBy: a => a.OrderByDescending(a => a.Created),
                currentPage: request.CurrentPage, pageSize: request.PageSize,
                enableTracking: false);

            _ = _mapper.Map<CompanyManagerDto, CompanyManger>(new CompanyManger());

            _ = _mapper.Map<PersonalDto, Personal>(new Personal());

            var response = _mapper.Map<GetAllCompanyResponse, Domain.Company.Company>(companyList);

            return response;

        }
    }
}
