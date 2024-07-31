using IkProject.Application.Abstractions;
using IkProject.Application.Abstractions.Services;
using IkProject.Application.Features.Command.Create.Register;
using IkProject.Application.UnitOfWorks;
using IkProject.Domain.Identities;
using IkProject.Domain.Company;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkProject.Application.Features.Command.Create.CompanyManager;

namespace IkProject.Application.Features.Command.Create.CreateCompanyManager
{
    public class CreateCompanyManagerCommendHandler : IRequestHandler<CreateCompanyManagerCommend, CompanyManagerCommendResponse>
    {
        private readonly UserManager<CompanyManger> _userManager;
        private readonly IMapper _mapper;
        private readonly IFileHelper _fileHelper;
        private readonly IMailServices _mailServices;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCompanyManagerCommendHandler(UserManager<CompanyManger> userManager, IMapper mapper, IFileHelper fileHelper, IMailServices mailServices, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _mapper = mapper;
            _fileHelper = fileHelper;
            _mailServices = mailServices;
            _unitOfWork = unitOfWork;
        }

        public async Task<CompanyManagerCommendResponse> Handle(CreateCompanyManagerCommend request, CancellationToken cancellationToken)
        {
            CompanyManger appUser = _mapper.Map<CompanyManger, CreateCompanyManagerCommend>(request);
            var companyReadRepo = _unitOfWork.GetReadRepository<Domain.Company.Company>();
            var companyWriteRepo = _unitOfWork.GetWriteRepository<Domain.Company.Company>();

            var checkUser = await _userManager.Users.AnyAsync(cm => cm.Email == request.Email);

            if (checkUser) throw new BadRequestException("Aynı isimde email adresi bulunmaktadır.");

            appUser.SecurityStamp = Guid.NewGuid().ToString();

            appUser.UserName = request.Email;

            if (!Guid.TryParse(request.CompanyId.ToString(), out var companyId))
            {
                throw new BadRequestException("Şirket ID si hatalı.");
            }


            var company = await companyReadRepo.GetByIdAsync(companyId.ToString());
            if (company == null)
            {
                throw new NotFoundException("Şirket bulunamadı.");
            }

            appUser.Company = company;


            _ = await _userManager.CreateAsync(appUser, request.Password);

            await _userManager.AddToRoleAsync(appUser, "CompanyManager");

            appUser.ImgPath = _fileHelper.Add(request.ImgPath, userId: appUser.Id.ToString());


            await _mailServices.SendMessageAsync(appUser.Email, "Hoş Geldiniz", "Main Crew IK ekibine Şirket Yöneticisi olarak hoş geldiniz.");

            company.CompanyManger = appUser;

            var response = _mapper.Map<CompanyManagerCommendResponse, CompanyManger>(appUser);

            await companyWriteRepo.UpdateAsync(company);


            return response;

        }
    }
}
