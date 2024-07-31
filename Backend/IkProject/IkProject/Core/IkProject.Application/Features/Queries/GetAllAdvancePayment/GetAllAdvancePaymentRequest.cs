using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Queries.GetAllAdvancePayment
{
    public class GetAllAdvancePaymentRequest : IRequest<IList<GetAllAdvancePaymentResponse>>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
