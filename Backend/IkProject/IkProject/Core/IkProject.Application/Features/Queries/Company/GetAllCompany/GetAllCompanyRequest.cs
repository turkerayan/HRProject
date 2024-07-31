using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Queries.Company.GetAllCompany
{
    public class GetAllCompanyRequest : IRequest<IList<GetAllCompanyResponse>>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
