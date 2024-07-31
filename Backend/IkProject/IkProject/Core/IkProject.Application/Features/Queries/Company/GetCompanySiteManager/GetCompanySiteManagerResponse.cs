using IkProject.Application.DTOs.CompanyManager;
using IkProject.Application.DTOs.Personel;
using IkProject.Domain.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Queries.Company.GetCompanySiteManager
{
    public class GetCompanySiteManagerResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string MersisNo { get; set; }
        public string TaxNo { get; set; }
        public string TaxAdministration { get; set; }
        public string? ImgPath { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int PersonelCount { get; set; }
        public DateTime EstablishmentDate { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public bool IsAktive { get; set; }
        [JsonIgnore]
        public CompanyManagerDto? CompanyManger { get; set; }
        public IList<PersonalDto> Personels { get; set; }  
    }
}
