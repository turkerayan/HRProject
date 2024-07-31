using IkProject.Domain.Identities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Command.Update.UpdateCompany
{
    public class UpdateCompanyCommend : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public IFormFile? ImgPath { get; set; }
        public DateTime? ContractStartDate { get; set; } = DateTime.Now;
        public DateTime? ContractEndDate { get; set; } = DateTime.Now.AddMinutes(2);

    }
}
