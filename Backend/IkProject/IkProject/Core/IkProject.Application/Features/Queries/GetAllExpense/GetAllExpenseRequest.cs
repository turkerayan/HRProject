using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Queries.GetAllExpense
{
    public class GetAllExpenseRequest : IRequest<IList<GetAllExpenseResponse>>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
