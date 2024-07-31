using IkProject.Application.Abstractions;
using IkProject.Application.Constants;
using IkProject.Application.DTOs.Company;
using IkProject.Application.UnitOfWorks;
using IkProject.Domain.Identities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SendGrid.Helpers.Errors.Model;

namespace IkProject.Application.Features.Queries.GetAdminDetails
{
    public class GetAdminDetailsHandler : IRequestHandler<GetAdminDetailsRequest, GetAdminDetailsResponse>
    {
        private readonly UserManager<AppUser> _manager;
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public GetAdminDetailsHandler(IMapper mapper, UserManager<AppUser> manager, IFileHelper fileHelper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _manager = manager;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetAdminDetailsResponse> Handle(GetAdminDetailsRequest request, CancellationToken cancellationToken)
        {
            var user = await _manager.FindByIdAsync(request.UserId);
            if (user is null)
                throw new BadRequestException("Kullanici bulunamadi");
            var companies = await _unitOfWork.GetReadRepository<Domain.Company.Company>().GetAllAsync();
            var company = companies.FirstOrDefault(x => x.CompanyManger?.Id.ToString() == request.UserId);
            GetAdminDetailsResponse response;
            if (company is not null)
            {
                response = _mapper.Map<GetAdminDetailsResponse, AppUser>(user);
                var companyDto = _mapper.Map<CompanyDto, Domain.Company.Company>(company);
                response.Company = companyDto;
            }
            else
            {
                response = _mapper.Map<GetAdminDetailsResponse, AppUser>(user);

            }

            if (user == null)
            {
                throw new Exception(Messages.UserNotFound);
            }
            return response;
        }
    }
}
