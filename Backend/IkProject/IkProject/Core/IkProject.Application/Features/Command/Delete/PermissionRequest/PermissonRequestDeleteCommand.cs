using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Command.Delete.PermissionRequest
{
    public class PermissonRequestDeleteCommand : IRequest<Unit>
    {
        public Guid PermissionRequestId { get; set; }
    }
}
