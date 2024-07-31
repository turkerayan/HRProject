using IkProject.Application.DTOs.CompanyManager;
using IkProject.Application.DTOs.Personel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Command.Create.Company
{
    public class CompanyResponse
    {
        private bool _isActive;
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string MersisNo { get; set; }
        public string TaxNo { get; set; }
        public string TaxAdministration { get; set; }
        public string ImgPath { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int PersonelCount { get; set; }
        public DateTime EstablishmentDate { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public bool IsAktive
        {
            get
            {
                return _isActive;
            }
            set
            {
                if (DateTime.Now > ContractEndDate) _isActive = false;
                else _isActive = true;
            }
        }
        public CompanyManagerDto? CompanyManger { get; set; }
        public IList<PersonalDto> Personels { get; set; }

    }
}

