using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Command.Update.UpdatePassword
{
    public class UpdatePasswordCommand : IRequest<Unit>
    {
        public string Id { get; set; }
        public string ResetToken { get; set; }
        public string NewPassword { get; set; }
    }
}
