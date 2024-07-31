using IkProject.Domain.Identities;
using IkProject.Domain.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Command.Create.PermissionRequest
{
    public class PermissionRequestCommand : IRequest<PermissionRequestResponse>
    {
        public string PermissionTypeId { get; set; }
        public string AppUserId { get; set; }
        public IFormFile? Image { get; set; }
        public DateTime PermissionStart { get; set; }
        public DateTime PermissionEnd { get; set; }
    }
}
