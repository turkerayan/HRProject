using IkProject.Domain.Requests;
using MediatR;

namespace IkProject.Application.Features.Command.Update.UpdateExpense
{
    public class UpdateExpenseCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }

    }
}
