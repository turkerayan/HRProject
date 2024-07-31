using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Command.Create.PermissionType
{
    public class PermissionCommand : IRequest<Unit>
    {
        public string Name { get; set; }
        public int Gender { get; set; }
    }
}
