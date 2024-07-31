using IkProject.Domain.Identities;
using IkProject.Domain.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Command.Update.UpdateAdvancePayment
{
    public class UpdateAdvancePaymentCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }

    }
}
