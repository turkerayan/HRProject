using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Domain.Base
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
        DataStatus Status { get; set; }
        DateTime Created { get; set; }
        DateTime? Updated { get; set; }
        DateTime? Deleted { get; set; }
    }
}
