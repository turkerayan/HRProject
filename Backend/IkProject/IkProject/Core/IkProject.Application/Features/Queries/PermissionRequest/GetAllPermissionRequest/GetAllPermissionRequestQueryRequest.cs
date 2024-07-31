using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Queries.PermissionRequest.GetAllPermissionRequest
{
    public class GetAllPermissionRequestQueryRequest : IRequest<IList<GetAllPermissionRequestQueryResponse>>
    {
        public string AppUserId { get; set; }
    }
}
