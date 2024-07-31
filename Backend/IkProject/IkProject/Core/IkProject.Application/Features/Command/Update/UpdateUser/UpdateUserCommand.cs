using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Command.Update.UpdateUser
{

    public class UpdateUserCommand : IRequest<Unit>
    {
        public string? Id { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public IFormFile? Image { get; set; }
    }
}
