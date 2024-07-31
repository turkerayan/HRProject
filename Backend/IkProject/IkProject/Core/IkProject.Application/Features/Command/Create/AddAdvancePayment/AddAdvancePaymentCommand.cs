using IkProject.Domain.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Command.Create.AddAdvancePayment
{
    public class AddAdvancePaymentCommand : IRequest<AddAdvancePaymentCommandResponse>
    {
        public Guid UserId { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? ResponseDate { get; set; }
        public decimal Money { get; set; }
        public Currency Currency { get; set; }
        public string Description { get; set; }
        public AdvancePaymentType Type { get; set; }

    }
}
