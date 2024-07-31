using IkProject.Application.Constants;
using IkProject.Application.UnitOfWorks;
using IkProject.Domain.Requests;
using MediatR;

namespace IkProject.Application.Features.Queries.GetAllByUserAdvancePayment
{
    public class GetAllByUserAdvancePaymentRequestHandler : IRequestHandler<GetAllByUserAdvancePaymentRequest, IList<AdvancePayment>>
    {
        private IUnitOfWork _unitOfWork;

        public GetAllByUserAdvancePaymentRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<AdvancePayment>> Handle(GetAllByUserAdvancePaymentRequest request, CancellationToken cancellationToken)
        {
            if (request.CurrentPage<1 || request.PageSize<1)
            {
                throw new Exception(Messages.PageAndCurrentSizeNotLessThanOne);
            }
            var advancePaymentRepo = _unitOfWork.GetReadRepository<AdvancePayment>();

            var advancePayments = await advancePaymentRepo.GetAllByPagingAsync(a => a.UserId == new Guid(request.UserId),orderBy:a=>a.OrderByDescending(a=>a.RequestDate),currentPage:request.CurrentPage,pageSize:request.PageSize);

            return advancePayments.ToList();
        }
    }

}
