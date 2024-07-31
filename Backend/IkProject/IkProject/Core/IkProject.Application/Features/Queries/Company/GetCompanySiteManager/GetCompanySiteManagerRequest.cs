using IkProject.Application.Features.Queries.Company.GetCompany;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Queries.Company.GetCompanySiteManager
{
    public class GetCompanySiteManagerRequest : IRequest<GetCompanySiteManagerResponse>
    {
        public Guid Id { get; set; }
    }
}
