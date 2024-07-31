using IkProject.Application.Abstractions;
using IkProject.Application.Constants;
using IkProject.Application.UnitOfWorks;
using IkProject.Domain.Identities;
using IkProject.Domain.Requests;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Queries.PermissionType.GetAllPermissionType
{
    public class GetPermissionTypeQueryHandler : IRequestHandler<GetAllPermissionTypeQueryRequest, IList<GetAllPermissionTypeQueryResponse>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetPermissionTypeQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IList<GetAllPermissionTypeQueryResponse>> Handle(GetAllPermissionTypeQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.AppUserId);

            if (user is null) throw new Exception(Messages.UserNotFound);
            var gender = Convert.ToInt32(user.IsBoy) + 1;


            var permissionList = await _unitOfWork.GetReadRepository<Domain.Requests.PermissionType>()
                .GetAllAsync(x => x.Gender == (Gender)gender || x.Gender == Gender.All);

            var permissionListResponse = _mapper.Map<GetAllPermissionTypeQueryResponse, Domain.Requests.PermissionType>(permissionList);

            return permissionListResponse;
        }
    }
}
