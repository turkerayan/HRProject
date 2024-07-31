using IkProject.Application.Abstractions;
using IkProject.Domain.Identities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Command.Create.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Unit>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IFileHelper _fileHelper;
        private readonly IMapper _mapper;

        public RegisterCommandHandler(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IFileHelper fileHelper, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _fileHelper = fileHelper;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var appUser = _mapper.Map<AppUser, RegisterCommand>(request);

            appUser.SecurityStamp = Guid.NewGuid().ToString();

            appUser.UserName = request.Email;

            _ = await _userManager.CreateAsync(appUser, request.Password);

            await _userManager.AddToRoleAsync(appUser, "Personal");

            await _userManager.AddToRoleAsync(appUser, "CompanyManager");

            appUser.ImgPath = _fileHelper.Add(request.ImgPath, userId: appUser.Id.ToString());

            await _userManager.UpdateAsync(appUser);

            return Unit.Value;
        }
    }
}
