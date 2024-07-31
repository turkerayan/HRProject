using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Queries.PermissionType.GetPermissonType
{
    public class GetPermissionTypeQueryRequest : IRequest<GetPermissionTypeQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
