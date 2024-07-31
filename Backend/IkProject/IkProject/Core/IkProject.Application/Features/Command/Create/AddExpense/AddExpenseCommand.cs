using IkProject.Domain.Identities;
using IkProject.Domain.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Command.Create.AddExpense
{
    public class AddExpenseCommand : IRequest<AddExpenseCommandResponse>
    {
        private Guid _userId;
        public ExpenseType Type { get; set; }
        public decimal Money { get; set; }
        public Currency Currency { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? ResponseDate { get; set; }
        public IFormFile Image { get; set; }
        public Guid UserId
        {
            get
            {
                return _userId;
            }
        }
        public void setUserId(Guid id)
        {
            _userId = id;
        }

    }
}
