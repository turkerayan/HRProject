using IkProject.Domain.Requests;

namespace IkProject.Application.Features.Queries.GetAllAdvancePayment
{
    public class GetAllAdvancePaymentResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? ResponseDate { get; set; }
        public decimal Money { get; set; }
        public Currency Currency { get; set; }
        public string Description { get; set; }
        public AdvancePaymentType Type { get; set; }
        public string UserImage { get; set; }
        public string UserEmail { get; set; }
        public string UserFirstName { get; set; }
        public string? UserSecondName { get; set; }
        public string UserSurname { get; set; }
        public string? UserSecondSurname { get; set; }


    }
}
