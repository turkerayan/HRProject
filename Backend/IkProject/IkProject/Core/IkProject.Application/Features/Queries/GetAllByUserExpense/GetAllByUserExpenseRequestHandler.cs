using IkProject.Application.Constants;
using IkProject.Application.UnitOfWorks;
using IkProject.Domain.Requests;
using MediatR;

namespace IkProject.Application.Features.Queries.GetAllByUserExpense
{
    public class GetAllByUserExpenseRequestHandler : IRequestHandler<GetAllByUserExpenseRequest, IList<Expense>>
    {
        private IUnitOfWork _unitOfWork;

        public GetAllByUserExpenseRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<Expense>> Handle(GetAllByUserExpenseRequest request, CancellationToken cancellationToken)
        {
            if (request.CurrentPage<1 || request.PageSize<1)
            {
                throw new Exception(Messages.PageAndCurrentSizeNotLessThanOne);
            }
            var expenseRepo = _unitOfWork.GetReadRepository<Expense>();

            var expenses = await expenseRepo.GetAllByPagingAsync(a => a.UserId == new Guid(request.UserId),orderBy:a=>a.OrderByDescending(a=>a.RequestDate),currentPage:request.CurrentPage,pageSize:request.PageSize);

            return expenses.ToList();
        }
    }

}
