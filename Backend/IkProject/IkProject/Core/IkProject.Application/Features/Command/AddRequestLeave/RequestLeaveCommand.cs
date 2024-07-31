using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Command.AddRequestLeave
{
    public class RequestLeaveCommand : IRequest<Unit>
    {
        public string Type { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RequestDate { get; set;}
        public DateTime ApprovalDate { get; set; }
        public DateTime ReplyDate { get; set; }
        public decimal Amount { get; set; }
        public string Explanation { get; set; }
        public int NumberOfDays { get; set; }
    }
}
