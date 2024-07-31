using IkProject.Application.Abstractions;
using IkProject.Application.Constants;
using IkProject.Application.UnitOfWorks;
using IkProject.Domain.Identities;
using IkProject.Domain.Requests;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SendGrid.Helpers.Errors.Model;

namespace IkProject.Application.Features.Command.Create.AddAdvancePayment
{
    public class AddAdvancePaymentCommandHandler : IRequestHandler<AddAdvancePaymentCommand, AddAdvancePaymentCommandResponse>
    {
        private IUnitOfWork _unitOfWork { get; set; }
        private UserManager<AppUser> _userManager { get; set; }
        private IMapper _mapper { get; set; }

        public AddAdvancePaymentCommandHandler(IUnitOfWork unitOfWork, UserManager<AppUser> userManager, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
        }


        public async Task<AddAdvancePaymentCommandResponse> Handle(AddAdvancePaymentCommand request, CancellationToken cancellationToken)
        {
            request.RequestDate = DateTime.Now;

            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            var advPaymentWriteRepo = _unitOfWork.GetWriteRepository<AdvancePayment>();
            var advPaymentReadRepo = _unitOfWork.GetReadRepository<AdvancePayment>();

            var advancePaymentsByUser = (await advPaymentReadRepo.GetAllAsync(a => a.UserId == request.UserId)).ToList();

            if (user is null)
            {
                throw new NotFoundException(Messages.UserNotFound);
            }
            

            if (request.Type == AdvancePaymentType.Individual && request.Currency != Currency.TL)
            {
                throw new BadRequestException(Messages.UserMustUseTurkishlira);
            }


            var advancePayment = _mapper.Map<AdvancePayment, AddAdvancePaymentCommand>(request);
            advancePayment.ApprovalStatus = ApprovalStatus.Pending;

            if (!Enum.IsDefined(typeof(Currency), request.Currency)
                || !Enum.IsDefined(typeof(AdvancePaymentType), request.Type)
                || advancePayment.UserId == Guid.Empty
                )
            {
                throw new NotFoundException(Messages.AdvancePaymentOrCurrencyNotDefined);
            }


            decimal amountedPayment = request.Money;

            //Kullanıcın son bir yıldaki avanslarını topla
            advancePaymentsByUser?.ForEach(a =>
            {
                if (a.ResponseDate > DateTime.Now.AddYears(-1))
                {
                    amountedPayment += a.Money;
                }
            });

            if (request.Type == AdvancePaymentType.Individual && amountedPayment > user.Wage * 3 && user.Wage>300 )
            {
                throw new BadRequestException($"Bireysel avans limiti {300}₺ - {user.Wage*3}₺ aralığında olmalıdır.");
            }

            if (request.Money > 500000
               || request.Money < 300)
            {
                throw new Exception(Messages.AdvancePaymentMustThisRange);
            }

            await advPaymentWriteRepo.AddAsync(advancePayment);
            var i = _unitOfWork.Save();
            var response = _mapper.Map<AddAdvancePaymentCommandResponse, AdvancePayment>(advancePayment);

            response.ApprovalStatus = ApprovalStatus.Pending;   

            return response;
        }

    }
}
