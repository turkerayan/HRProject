using IkProject.Application.Abstractions;
using IkProject.Application.Constants;
using IkProject.Application.UnitOfWorks;
using IkProject.Domain.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IkProject.Application.Features.Queries.GetAllExpense
{
    public class GetAllExpenseHandler : IRequestHandler<GetAllExpenseRequest, IList<GetAllExpenseResponse>>
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public GetAllExpenseHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<GetAllExpenseResponse>> Handle(GetAllExpenseRequest request, CancellationToken cancellationToken)
        {
            if (request.CurrentPage < 1 || request.PageSize < 1)
            {
                throw new Exception(Messages.PageAndCurrentSizeNotLessThanOne);
            }

            var readRepo = _unitOfWork.GetReadRepository<Expense>();

            var expenses = await readRepo.GetAllByPagingAsync(
                include: a => a.Include(a => a.User),
                orderBy: a => a.OrderByDescending(a => a.RequestDate),
                currentPage: request.CurrentPage, pageSize: request.PageSize);

            var response = new List<GetAllExpenseResponse>();

            try
            {
                foreach (var expense in expenses)
                {
                    response.Add
                        (new()
                        {
                            Id = expense.Id,
                            UserId = expense.UserId,
                            ApprovalStatus = expense.ApprovalStatus,
                            Currency = expense.Currency,
                            Money = expense.Money,
                            RequestDate = expense.RequestDate,
                            ResponseDate = expense.ResponseDate,
                            Type = expense.Type,
                            ImagePath=expense.ImagePath,
                            UserEmail = expense.User.Email,
                            UserImage = expense.User.ImgPath,
                            UserFirstName = expense.User.Name,
                            UserSecondName = expense.User.SecondName,
                            UserSurname = expense.User.Surname,
                            UserSecondSurname = expense.User.SecondSurname

                        });
                }
            }
            catch (Exception e)
            {

                throw e;
            }

            return response;
        }
    }
}
