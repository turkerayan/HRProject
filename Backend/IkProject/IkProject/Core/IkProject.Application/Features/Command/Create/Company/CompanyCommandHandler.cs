using IkProject.Application.Abstractions;
using IkProject.Application.Constants;
using IkProject.Application.DTOs.CompanyManager;
using IkProject.Application.DTOs.Personel;
using IkProject.Application.UnitOfWorks;
using IkProject.Domain.Identities;
using MediatR;
using SendGrid.Helpers.Errors.Model;

namespace IkProject.Application.Features.Command.Create.Company
{
    public class CompanyCommandHandler : IRequestHandler<CompanyCommand, CompanyResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFileHelper _fileHelper;
        private readonly IUnitOfWork _unitOfWork;

        public CompanyCommandHandler(IMapper mapper, IFileHelper fileHelper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _fileHelper = fileHelper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CompanyResponse> Handle(CompanyCommand request, CancellationToken cancellationToken)
        {

            var company = _mapper.Map<Domain.Company.Company, CompanyCommand>(request);

            var checkCompany = await _unitOfWork.GetReadRepository<Domain.Company.Company>().GetAsync(c => c.Name == company.Name);

            if (checkCompany is not null)
                throw new BadRequestException(Messages.CompanyAlreadyExists);

            company.ImgPath = _fileHelper.Add(request.ImgPath, userId: company.Id.ToString(), root: LocalPaths.CompanyImage);

            await _unitOfWork.GetWriteRepository<Domain.Company.Company>().AddAsync(company);
            _ = _mapper.Map<CompanyManagerDto, CompanyManger>(new CompanyManger());

            _ = _mapper.Map<PersonalDto, Domain.Identities.Personal>(new Domain.Identities.Personal());

            var response = _mapper.Map<CompanyResponse, Domain.Company.Company>(company);

            await _unitOfWork.SaveAsync();

            return response;
        }
    }
}
