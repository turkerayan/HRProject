using IkProject.Application.Abstractions;
using IkProject.Application.Constants;
using IkProject.Application.UnitOfWorks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Command.Delete.PermissionRequest
{
    public class PermissionRequestDeleteCommandHandler : IRequestHandler<PermissonRequestDeleteCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PermissionRequestDeleteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(PermissonRequestDeleteCommand request, CancellationToken cancellationToken)
        {
            var permission = await _unitOfWork.GetReadRepository<Domain.Requests.PermissionRequest>().GetByIdAsync(request.PermissionRequestId.ToString());
            if (permission == null) throw new Exception(Messages.ExpenseNotFound);
            await _unitOfWork.GetWriteRepository<Domain.Requests.PermissionRequest>().RemoveAsync(permission);
            await _unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
