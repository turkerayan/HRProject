using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Domain.Base
{
    public class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }
        public DataStatus Status { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? Deleted { get; set; }
    }
}
