using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Queries.PermissionRequest.GetAllCompanyManagerPermissionRequest
{
    public class GetAllCompanyManagerPermissionRequestQueryRequest : IRequest<IList<GetAllCompanyManagerPermissionRequestQueryResponse>>
    {
    }
}
