using IkProject.Domain.Base;
using IkProject.Domain.Identities;

namespace IkProject.Domain.Company
{
    public class Company : BaseEntity
    {
        private bool _isActive;
        public string Name { get; set; }
        public string MersisNo { get; set; }
        public string TaxNo { get; set; }
        public string TaxAdministration { get; set; }
        public string? ImgPath { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int PersonelCount
        {
            get
            {
                 
                if (CompanyManger is not null)
                    return Personels.Count + 1;
                if (Personels is not null)
                    return Personels.Count;
                return 0;
            }
        }
        public DateTime EstablishmentDate { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public CompanyManger? CompanyManger { get; set; }
        public IList<Personal>? Personels { get; set; } = new List<Personal>();
        public bool IsAktive => DateTime.Now <= ContractEndDate;

    }
}


