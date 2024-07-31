using IkProject.Domain.Base;
using IkProject.Domain.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Domain.Requests
{
    public class Expense:BaseEntity
    {
        public Guid UserId { get; set; }        
        public ExpenseType Type { get; set; }
        public decimal Money { get; set; }
        public Currency Currency { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? ResponseDate { get; set; }
        public string ImagePath { get; set; }
        public string? Description { get; set; }

        public AppUser User { get; set; }
    }
}
