using IkProject.Application.Abstractions;
using IkProject.Application.Constants;
using IkProject.Application.UnitOfWorks;
using IkProject.Domain.Base;
using IkProject.Domain.Identities;
using IkProject.Domain.Requests;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SendGrid.Helpers.Errors.Model;


namespace IkProject.Application.Features.Command.Create.PermissionRequest
{
    public class PermissionRequestCommandHandler : IRequestHandler<PermissionRequestCommand, PermissionRequestResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IFileHelper _fileHelper;

        public PermissionRequestCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager, IFileHelper fileHelper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _fileHelper = fileHelper;
        }

        public async Task<PermissionRequestResponse> Handle(PermissionRequestCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.AppUserId);
            if (user is null) throw new NotFoundException(Messages.UserNotFound);

            var permissionType = await _unitOfWork.GetReadRepository<Domain.Requests.PermissionType>().GetByIdAsync(request.PermissionTypeId.ToString());
            if (permissionType is null) throw new Exception(Messages.PermissionRequestNotFound);

            var permission = _mapper.Map<Domain.Requests.PermissionRequest, PermissionRequestCommand>(request);
            permission.ApprovalStatus = ApprovalStatus.Pending;
            permission.PermissionType = permissionType;

            var permissionTypes = new string[] 
            {
                "ae5d8436-9e77-40fc-8e14-f8ff49bca5c3",
                "0db8f712-e880-45bc-898e-a4a140ef6439",
                "6e9d4f4a-9ddb-4098-adae-e275d83c086d",
                "d8f07d79-2f03-4915-975d-aa167a954af3",
                "668cd66d-9bf3-4ab8-8e09-6e108ed3f4bb",
                "3ce6e2e3-a471-47ee-a4cf-343ec355096a",
                "f64f5dce-a84d-4dad-8235-a5fca38ec831",
                "b402370a-c4db-4890-9070-056d9ece33b4",
                "40cc4874-ef44-47d5-bc68-56bf5dd8fbff",
                "f3357e7d-6c4b-455a-bf95-308fcee78e58"
            };

            if (request.Image is not null && permissionTypes.Contains(request.PermissionTypeId))
            {
                var path = _fileHelper.Add(request.Image, request.AppUserId, LocalPaths.PermissionImage);
                permission.ImagePath = path;

            }

            await _unitOfWork.GetWriteRepository<Domain.Requests.PermissionRequest>().AddAsync(permission);
            await _unitOfWork.SaveAsync();
            var result = _mapper.Map<PermissionRequestResponse, Domain.Requests.PermissionRequest>(permission);
            result.Name = permission.PermissionType.Name;

            return result;
        }
    }
}
