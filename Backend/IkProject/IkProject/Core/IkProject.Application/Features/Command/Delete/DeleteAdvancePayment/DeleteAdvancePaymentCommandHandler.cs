using IkProject.Application.Abstractions;
using IkProject.Application.Constants;

using IkProject.Application.UnitOfWorks;
using IkProject.Domain.Requests;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IkProject.Application.Features.Command.Delete.DeleteAdvancePayment
{
    public class DeleteAdvancePaymentCommandHandler : IRequestHandler<DeleteAdvancePaymentCommand, Unit>
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public DeleteAdvancePaymentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<Unit> Handle(DeleteAdvancePaymentCommand request, CancellationToken cancellationToken)
        {
            var advPaymentWriteRepo = _unitOfWork.GetWriteRepository<AdvancePayment>();
            var advPaymentReadRepo = _unitOfWork.GetReadRepository<AdvancePayment>();

            var advancePayment = await advPaymentReadRepo.GetAsync(a => a.Id == request.Id);

            if (advancePayment is null)
            {
                throw new Exception(Messages.AdvancePaymentNotFound);
            }

            await advPaymentWriteRepo.RemoveAsync(advancePayment);
            var i = _unitOfWork.Save();

            return Unit.Value;
        }

    }
}
