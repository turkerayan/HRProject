using IkProject.Application.Abstractions;
using IkProject.Application.Constants;
using IkProject.Application.UnitOfWorks;
using IkProject.Domain.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Command.Put.PermissionRequest
{
    internal class PermissionRequestApprovalStatusHandler : IRequestHandler<PermissionRequestApprovalStatusCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PermissionRequestApprovalStatusHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(PermissionRequestApprovalStatusCommand request, CancellationToken cancellationToken)
        {
            var permissionRequest = await _unitOfWork.GetReadRepository<Domain.Requests.PermissionRequest>().GetByIdAsync(request.PermissinRequestId.ToString());
            if (permissionRequest is null) throw new Exception(Messages.PermissionRequestNotFound);
            permissionRequest.ApprovalStatus = (ApprovalStatus)request.ApprovalStatus;
            permissionRequest.ReplyDate = DateTime.Now;
            await _unitOfWork.GetWriteRepository<Domain.Requests.PermissionRequest>().UpdateAsync(permissionRequest);
            await _unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
