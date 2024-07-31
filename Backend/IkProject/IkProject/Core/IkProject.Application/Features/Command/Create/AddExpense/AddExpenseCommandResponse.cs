using IkProject.Domain.Identities;
using IkProject.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Command.Create.AddExpense
{
    public class AddExpenseCommandResponse
    {
        public Guid Id { get; set; }
        public ExpenseType Type { get; set; }
        public decimal Money { get; set; }
        public Currency Currency { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? ResponseDate { get; set; }
        public string ImagePath { get; set; }
    }
}
