using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Queries.PermissionType.GetAllPermissionType
{
    public class GetAllPermissionTypeQueryRequest : IRequest<IList<GetAllPermissionTypeQueryResponse>>
    {
        internal string AppUserId { get; set; }
        public void TakeId(string id)
        {
            AppUserId = id;
        }


    }
}
