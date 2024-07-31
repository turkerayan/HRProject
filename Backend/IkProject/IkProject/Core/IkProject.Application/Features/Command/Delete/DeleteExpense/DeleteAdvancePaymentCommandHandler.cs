using IkProject.Application.Abstractions;
using IkProject.Application.Constants;
using IkProject.Application.Expections;
using IkProject.Application.UnitOfWorks;
using IkProject.Domain.Requests;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IkProject.Application.Features.Command.Delete.DeleteExpense
{
    public class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommand, Unit>
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public DeleteExpenseCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<Unit> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
        {
            var advPaymentWriteRepo = _unitOfWork.GetWriteRepository<Expense>();
            var advPaymentReadRepo = _unitOfWork.GetReadRepository<Expense>();

            var expense = await advPaymentReadRepo.GetAsync(a => a.Id == request.Id);

            if (expense is null)
            {
                throw new Exception(Messages.AdvancePaymentNotFound);
            }

            await advPaymentWriteRepo.RemoveAsync(expense);
            var i = _unitOfWork.Save();

            return Unit.Value;
        }

    }
}
