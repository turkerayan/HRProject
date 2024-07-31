using IkProject.Application.Abstractions;
using IkProject.Application.DTOs.Personel;
using IkProject.Domain.Identities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;


namespace IkProject.Application.Features.Command.Create.Personel
{
    public class PersonalCommendHandler : IRequestHandler<PersonalCommend, PersonalDto>
    {
        private readonly UserManager<Domain.Identities.Personal> _userManager;
        private readonly IMapper _mapper;
        private readonly IFileHelper _fileHelper;
        private readonly UserManager<CompanyManger> _userManagerManger;

        public PersonalCommendHandler(UserManager<Domain.Identities.Personal> userManager, IMapper mapper, IFileHelper fileHelper, UserManager<CompanyManger> userManagerManger)
        {
            _userManager = userManager;
            _mapper = mapper;
            _fileHelper = fileHelper;
            _userManagerManger = userManagerManger;
        }

        public async Task<PersonalDto> Handle(PersonalCommend request, CancellationToken cancellationToken)
        {
            var personal = _mapper.Map<Domain.Identities.Personal, PersonalCommend>(request);

            var checkUser = await _userManager.Users.AnyAsync(per => per.Email == request.Email);

            if (checkUser) throw new BadRequestException("Aynı mail adresinde bir kullanıcı bulunmaktadır");


            if (request.UserId != Guid.Empty)
            {
                var user = await _userManagerManger.FindByIdAsync(request.UserId.ToString());
                personal.CompanyPersonelId = user.CompanyId;
            }

            personal.SecurityStamp = Guid.NewGuid().ToString();

            personal.UserName = request.Email;

            _ = await _userManager.CreateAsync(personal, request.Password);

            await _userManager.AddToRoleAsync(personal, "Personal");

            personal.ImgPath = _fileHelper.Add(request.ImgPath, userId: personal.Id.ToString());

            await _userManager.UpdateAsync(personal);

            var personalDto = _mapper.Map<PersonalDto, IkProject.Domain.Identities.Personal>(personal);

            return personalDto;
        }
    }
}