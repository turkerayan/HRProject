using IkProject.Domain.Requests;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Domain.Identities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string? Token { get; set; }
        public string Name { get; set; }
        public string? SecondName { get; set; }
        public string Surname { get; set; }
        public string? SecondSurname { get; set; }
        public DateTime BirthDate { get; set; }
        public string PlaceOfBirth { get; set; }
        public string IdentityNo { get; set; }
        public DateTime? StartAJob { get; set; }
        public DateTime? LeavingJob { get; set; }
        public bool IsActive
        {
            get
            {
                if (StartAJob.HasValue && StartAJob <= DateTime.Now && (LeavingJob == null || DateTime.Now <= LeavingJob)) return true;
                else return false;
            }
        }
        public string Job { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        [Column(TypeName = "decimal(28, 6)")]
        public decimal Wage { get; set; }
        public string ImgPath { get; set; }
        public bool IsBoy { get; set; }
        public IList<PermissionRequest>? PermissionRequests { get; set; }
        public IList<AdvancePayment> AdvancePayments { get; set; }
        public IList<Expense> Expenses { get; set; }
    }
}
