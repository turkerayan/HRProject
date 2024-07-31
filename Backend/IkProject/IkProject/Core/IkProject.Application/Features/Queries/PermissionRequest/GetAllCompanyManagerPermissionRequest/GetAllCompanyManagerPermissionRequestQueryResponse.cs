using IkProject.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Queries.PermissionRequest.GetAllCompanyManagerPermissionRequest
{
    public class GetAllCompanyManagerPermissionRequestQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime PermissionStart { get; set; }
        public DateTime PermissionEnd { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public DateTime? ReplyDate { get; set; }
        public int? NumberOfDay { get; set; }
        public DateTime Created { get; set; }
        public string UserImage { get; set; }
        public string UserEmail { get; set; }
        public string UserFirstName { get; set; }
        public string? UserSecondName { get; set; }
        public string UserSurname { get; set; }
        public string? UserSecondSurname { get; set; }


    }
}
