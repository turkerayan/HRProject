using IkProject.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Command.Create.PermissionRequest
{
    public class PermissionRequestResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime PermissionStart { get; set; }
        public DateTime PermissionEnd { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public DateTime? ReplyDate { get; set; }
        public DateTime Created { get; set; }
        public int? NumberOfDay { get; set; }
    }
}
