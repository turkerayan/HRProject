using IkProject.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Domain.Requests
{
    public class PermissionType : BaseEntity
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public IList<PermissionRequest> PermissionRequests { get; set; }

    }
}
