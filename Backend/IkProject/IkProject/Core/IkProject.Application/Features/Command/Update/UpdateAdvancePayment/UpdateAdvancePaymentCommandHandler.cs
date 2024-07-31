using IkProject.Application.Abstractions;
using IkProject.Application.Constants;

using IkProject.Application.UnitOfWorks;
using IkProject.Domain.Requests;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SendGrid.Helpers.Errors.Model;

namespace IkProject.Application.Features.Command.Update.UpdateAdvancePayment
{
    public class UpdateAdvancePaymentCommandHandler : IRequestHandler<UpdateAdvancePaymentCommand, Unit>
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public UpdateAdvancePaymentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<Unit> Handle(UpdateAdvancePaymentCommand request, CancellationToken cancellationToken)
        {
            var advPaymentWriteRepo = _unitOfWork.GetWriteRepository<AdvancePayment>();
            var advPaymentReadRepo = _unitOfWork.GetReadRepository<AdvancePayment>();

            var advancePayment = await advPaymentReadRepo.GetAsync(a => a.Id == request.Id);

            if (advancePayment is null)
            {
                throw new Exception(Messages.AdvancePaymentNotFound);
            }

            if (!Enum.IsDefined(typeof(ApprovalStatus), request.ApprovalStatus) )
            {
                throw new NotFoundException(Messages.ApprovalstatusNotDefined);
            }

            advancePayment.ApprovalStatus = request.ApprovalStatus;
            advancePayment.ResponseDate = DateTime.Now;


            await advPaymentWriteRepo.UpdateAsync(advancePayment);
            var i = _unitOfWork.Save();

            return Unit.Value;
        }

    }
}
