using IkProject.Application.Abstractions;
using IkProject.Application.UnitOfWorks;
using MediatR;
using SendGrid.Helpers.Errors.Model;

namespace IkProject.Application.Features.Command.Create.PermissionType
{
    public class PermissionCommandHandler : IRequestHandler<PermissionCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PermissionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(PermissionCommand request, CancellationToken cancellationToken)
        {
            var checkPermissinType = await _unitOfWork.GetReadRepository<Domain.Requests.PermissionType>().GetAllAsync();

            if (checkPermissinType.Any(pr => pr.Name == request.Name)) throw new BadRequestException("Ayni izin türünden bulunmaktadır.");

            var permissionType = _mapper.Map<Domain.Requests.PermissionType, PermissionCommand>(request);

            await _unitOfWork.GetWriteRepository<Domain.Requests.PermissionType>().AddAsync(permissionType);

            _ = await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
