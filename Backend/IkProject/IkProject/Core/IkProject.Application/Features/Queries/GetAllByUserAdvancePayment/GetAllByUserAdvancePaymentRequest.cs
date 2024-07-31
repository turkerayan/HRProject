﻿using IkProject.Domain.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Queries.GetAllByUserAdvancePayment
{
    public class GetAllByUserAdvancePaymentRequest:IRequest<IList<AdvancePayment>>
    {
        public string UserId { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }

}
