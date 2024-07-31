using IkProject.Application.Abstractions;
using IkProject.Application.Constants;
using IkProject.Application.UnitOfWorks;
using IkProject.Domain.Identities;
using IkProject.Domain.Requests;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SendGrid.Helpers.Errors.Model;

namespace IkProject.Application.Features.Command.Create.AddExpense
{
    public class AddExpenseCommandHandler : IRequestHandler<AddExpenseCommand, AddExpenseCommandResponse>
    {
        private IUnitOfWork _unitOfWork { get; set; }
        private UserManager<AppUser> _userManager { get; set; }
        private IMapper _mapper { get; set; }
        private IFileHelper _fileHelper { get; set; }

        public AddExpenseCommandHandler(IUnitOfWork unitOfWork, UserManager<AppUser> userManager, IMapper mapper, IFileHelper fileHelper)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
            _fileHelper = fileHelper;
        }


        public async Task<AddExpenseCommandResponse> Handle(AddExpenseCommand request, CancellationToken cancellationToken)
        {
            request.RequestDate = DateTime.Now;

            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            var expenseWriteRepo = _unitOfWork.GetWriteRepository<Expense>();
            var expenseReadRepo = _unitOfWork.GetReadRepository<Expense>();


            switch (request.Type)
            {
                
                case ExpenseType.Food:
                    if ((request.Currency == Currency.TL && (request.Money < 50 || request.Money > 400) )
                        || ((request.Money < 3 || request.Money > 60) && request.Currency != Currency.TL))
                        throw new Exception("Yemek harcaması 50₺ - 400₺ arasında olmalıdır.");
                    break;

                case ExpenseType.Accommodation:
                        if ((request.Currency == Currency.TL && (request.Money < 750 || request.Money > 25000))
                        || ((request.Money < 25 || request.Money > 800) && request.Currency != Currency.TL))
                        
                        throw new Exception("Konaklama harcaması 750₺ - 25.000₺ arasında olmalıdır.");
                    break;

                case ExpenseType.Travel:
                    if ((request.Currency == Currency.TL && (request.Money < 50 || request.Money > 10000))
                        || ((request.Money < 3 || request.Money > 330) && request.Currency != Currency.TL))
                        throw new Exception("Seyahat harcaması 50₺ - 10.000₺ arasında olmalıdır.");
                    break;

                
                default:
                    break;
            }

            if (request.Money > 100000 && request.Money <= 0)
            {
                throw new Exception("Harcama miktarı 0₺ - 100.000₺ arasında olmalıdır.");
            }

            if (user is null)
            {
                throw new NotFoundException(Messages.UserNotFound);
            }


            var expense = _mapper.Map<Expense, AddExpenseCommand>(request);
            expense.ApprovalStatus = ApprovalStatus.Pending;

            if (!Enum.IsDefined(typeof(Currency), request.Currency)
                || !Enum.IsDefined(typeof(ExpenseType), request.Type)
                || expense.UserId==Guid.Empty
                )
            {
                throw new NotFoundException(Messages.ExpenceorCurrencyNotDefined);
            }

            var imagePath = _fileHelper.Add(request.Image, user.Id.ToString(), LocalPaths.ExpenseImage);

            if (imagePath is null) 
            {
                throw new Exception(Messages.ImageNotSaved);
            }

            expense.ImagePath = imagePath;

            await expenseWriteRepo.AddAsync(expense);
            var i = _unitOfWork.Save();

            var response = _mapper.Map<AddExpenseCommandResponse, Expense>(expense);

            return response;
        }

    }
}
