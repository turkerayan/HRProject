using IkProject.Domain.Base;
using IkProject.Domain.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Domain.Requests
{
    public class PermissionRequest : BaseEntity
    {
        public PermissionType PermissionType { get; set; }
        public DateTime PermissionStart { get; set; }
        public DateTime PermissionEnd { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public DateTime? ReplyDate { get; set; }
        public int? NumberOfDay { get; set; }        
        public Guid AppUserId { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
