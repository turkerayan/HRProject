using IkProject.Domain.Identities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Command.Delete.DeleteExpense
{
    public class DeleteExpenseCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

    }
}
