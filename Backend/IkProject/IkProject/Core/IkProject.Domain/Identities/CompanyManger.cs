using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IkProject.Domain.Identities
{
    public class CompanyManger : AppUser
    {
        [Column("CompanyManager_CompanyId")]
        public Guid CompanyId { get; set; }
        public Company.Company? Company { get; set; }
    }
}
