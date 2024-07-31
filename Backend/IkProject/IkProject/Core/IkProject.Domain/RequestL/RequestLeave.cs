using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkProject.Domain.Base;

namespace IkProject.Domain.RequestL
{
    public class RequestLeave : BaseEntity
    {
        public string Type { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndDate { get; set; }
        //public DateTime RequestDate { get; set; }
        //public DateTime ApprovalDate { get; set; }=DateTime.Now;
        public DateTime ReplyDate { get; set; }= DateTime.Now;
        public decimal Amount { get; set; }
        public string Explanation { get; set; }
        public int NumberOfDays { get; set; }
    }
}