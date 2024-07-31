using IkProject.Application.Abstractions;
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

namespace IkProject.Application.Features.Command.Update.UpdateCompanyManager
{
    public class UpdateCompanyManagerCommandHandler : IRequestHandler<UpdateCompanyManagerCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IFileHelper _fileHelper;
        private readonly UserManager<CompanyManger> _userManager;

        public UpdateCompanyManagerCommandHandler( IMapper mapper, IFileHelper fileHelper, UserManager<CompanyManger> userManager)
        {
            
            _mapper = mapper;
            _fileHelper = fileHelper;
            _userManager = userManager;
        }

        public async Task<Unit> Handle(UpdateCompanyManagerCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());

            if (user is null)
                throw new BadRequestException("Kullanici bulunamadi");

            user.Name = request.Name;
            user.SecondName = request.SecondName;
            user.Surname = request.Surname;
            user.SecondSurname = request.SecondSurname;
            user.BirthDate = (DateTime)request.BirthDate;
            user.PlaceOfBirth = request.PlaceOfBirth;
            user.IdentityNo = request.IdentityNo;   
            user.StartAJob = request.StartAJob; 
            user.LeavingJob = request.LeavingJob;   
            user.Job = request.Job; 
            user.Department = request.Department;
            user.Address = request.Address; 
            user.PhoneNumber = request.PhoneNumber;
            user.Wage = (decimal)request.Wage;
            if (request.ImgPath is not null)
            {
                var imgPath = _fileHelper.Update(request.ImgPath, user.Id.ToString());
                user.ImgPath = imgPath;
            }
            user.IsBoy = (bool)request.IsBoy;
            user.CompanyId = (Guid)request.CompanyId; 

            await _userManager.UpdateAsync(user);

            return  Unit.Value;
        }
    }
}
