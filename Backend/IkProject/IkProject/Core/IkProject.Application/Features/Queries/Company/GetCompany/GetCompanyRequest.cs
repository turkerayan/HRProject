using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Queries.Company.GetCompany
{
    public class GetCompanyRequest : IRequest<GetCompanyResponse>
    {
        public Guid Id { get; set; }
    }
}
