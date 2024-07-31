using IkProject.Application.Abstractions;
using IkProject.Application.Constants;

using IkProject.Application.UnitOfWorks;
using IkProject.Domain.Requests;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SendGrid.Helpers.Errors.Model;

namespace IkProject.Application.Features.Command.Update.UpdateExpense
{
    public class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommand, Unit>
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public UpdateExpenseCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<Unit> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
        {
            var expenseWriteRepo = _unitOfWork.GetWriteRepository<Expense>();
            var expenseReadRepo = _unitOfWork.GetReadRepository<Expense>();

            var expense = await expenseReadRepo.GetAsync(a => a.Id == request.Id);

            if (expense is null)
            {
                throw new Exception(Messages.ExpenseNotFound);
            }

            if (!Enum.IsDefined(typeof(ApprovalStatus), request.ApprovalStatus))
            {
                throw new NotFoundException(Messages.ApprovalstatusNotDefined);
            }

            expense.ApprovalStatus = request.ApprovalStatus;
            expense.ResponseDate = DateTime.Now;


            await expenseWriteRepo.UpdateAsync(expense);
            var i = _unitOfWork.Save();

            return Unit.Value;
        }

    }
}
