using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Queries.GetAdminDetails
{
    public class GetAdminDetailsRequest : IRequest<GetAdminDetailsResponse>
    {
        public string UserId { get; set; }
    }
}
