using IkProject.Domain.Base;
using IkProject.Domain.Identities;

namespace IkProject.Domain.Requests
{
    public class AdvancePayment : BaseEntity
    {
        public Guid UserId { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? ResponseDate { get; set; }
        public decimal Money { get; set; }
        public Currency Currency { get; set; }
        public string Description { get; set; }
        public string? ResponseDescription { get; set; }
        public AdvancePaymentType Type { get; set; }
        public AppUser User { get; set; }
    }
}
