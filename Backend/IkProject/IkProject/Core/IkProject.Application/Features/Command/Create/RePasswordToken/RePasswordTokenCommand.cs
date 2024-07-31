using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Command.Create.RePasswordToken
{
    public class RePasswordTokenCommand : IRequest<Unit>
    {
        public string Email { get; set; }
    }
}
