using IkProject.Application.Abstractions;
using IkProject.Application.Constants;
using IkProject.Application.UnitOfWorks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Queries.PermissionType.GetPermissonType
{
    public class GetPermissionTypeQueryHandler : IRequestHandler<GetPermissionTypeQueryRequest, GetPermissionTypeQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetPermissionTypeQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetPermissionTypeQueryResponse> Handle(GetPermissionTypeQueryRequest request, CancellationToken cancellationToken)
        {
            var permissionType = await _unitOfWork.GetReadRepository<Domain.Requests.PermissionType>().GetByIdAsync(request.Id.ToString());
            if (permissionType is null) throw new Exception(Messages.PermissionRequestNotFound);
            var permissionResponse = _mapper.Map<GetPermissionTypeQueryResponse, Domain.Requests.PermissionType>(permissionType);
            return permissionResponse;
        }
    }
}
