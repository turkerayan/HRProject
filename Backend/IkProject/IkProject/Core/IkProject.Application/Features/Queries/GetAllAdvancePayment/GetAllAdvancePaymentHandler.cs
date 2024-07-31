using IkProject.Application.Abstractions;
using IkProject.Application.Constants;
using IkProject.Application.UnitOfWorks;
using IkProject.Domain.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IkProject.Application.Features.Queries.GetAllAdvancePayment
{
    public class GetAllAdvancePaymentHandler : IRequestHandler<GetAllAdvancePaymentRequest, IList<GetAllAdvancePaymentResponse>>
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public GetAllAdvancePaymentHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<GetAllAdvancePaymentResponse>> Handle(GetAllAdvancePaymentRequest request, CancellationToken cancellationToken)
        {
            if (request.CurrentPage <1 || request.PageSize <1)
            {
                throw new Exception(Messages.PageAndCurrentSizeNotLessThanOne);
            }

            var readRepo = _unitOfWork.GetReadRepository<AdvancePayment>();

            var advancePayments = await readRepo.GetAllByPagingAsync(
                include: a => a.Include(a => a.User),
                orderBy: a => a.OrderByDescending(a => a.RequestDate),
                currentPage: request.CurrentPage, pageSize: request.PageSize);

            var response = new List<GetAllAdvancePaymentResponse>();

            try
            {
                foreach (var advancePayment in advancePayments)
                {
                    response.Add
                        (new()
                        {
                            Id = advancePayment.Id,
                            UserId = advancePayment.UserId,
                            ApprovalStatus = advancePayment.ApprovalStatus,
                            Currency = advancePayment.Currency,
                            Description = advancePayment.Description,
                            Money = advancePayment.Money,
                            RequestDate = advancePayment.RequestDate,
                            ResponseDate = advancePayment.ResponseDate,
                            Type = advancePayment.Type,
                            UserEmail = advancePayment.User.Email,
                            UserImage = advancePayment.User.ImgPath,
                            UserFirstName = advancePayment.User.Name,
                            UserSecondName = advancePayment.User.SecondName,
                            UserSurname = advancePayment.User.Surname,
                            UserSecondSurname = advancePayment.User.SecondSurname

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
