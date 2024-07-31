using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Command.Put.PermissionRequest
{
    public class PermissionRequestApprovalStatusCommand : IRequest<Unit>
    {
        public Guid PermissinRequestId { get; set; }
        public int ApprovalStatus { get; set; }
    }
}
