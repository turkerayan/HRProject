using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Command.Create.Company
{
    public class CompanyCommand : IRequest<CompanyResponse>
    {
        public string Name { get; set; }
        public string MersisNo { get; set; }
        public string TaxNo { get; set; }
        public string TaxAdministration { get; set; }
        public IFormFile ImgPath { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime EstablishmentDate { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
    }
}
