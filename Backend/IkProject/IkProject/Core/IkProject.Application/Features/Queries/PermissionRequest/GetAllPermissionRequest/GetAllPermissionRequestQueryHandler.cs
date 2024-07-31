using Azure.Core;
using IkProject.Application.Abstractions;
using IkProject.Application.UnitOfWorks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Queries.PermissionRequest.GetAllPermissionRequest
{
    public class GetAllPermissionRequestQueryHandler : IRequestHandler<GetAllPermissionRequestQueryRequest, IList<GetAllPermissionRequestQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllPermissionRequestQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<GetAllPermissionRequestQueryResponse>> Handle(GetAllPermissionRequestQueryRequest request, CancellationToken cancellationToken)
        {
            var allPermissionRequest = await _unitOfWork.GetReadRepository<Domain.Requests.PermissionRequest>()
                .GetAllAsync(p => p.AppUserId == Guid.Parse(request.AppUserId), orderBy: a => a.OrderByDescending(a => a.Created));

            var permissionTypeList = await _unitOfWork.GetReadRepository<Domain.Requests.PermissionType>().GetAllAsync();

            var response = _mapper.Map<GetAllPermissionRequestQueryResponse, Domain.Requests.PermissionRequest>(allPermissionRequest);

            response = response.Select((request, index) =>
            {
                request.Name = allPermissionRequest[index].PermissionType.Name;
                return request;
            }).ToList();

            return response;
        }
    }
}
