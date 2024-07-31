using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Domain.Identities
{
    public class Personal : AppUser
    {
        [Column("Personel_CompanyId")]
        public Guid CompanyPersonelId { get; set; }
        public Company.Company? CompanyPersonel { get; set; }
    }
}
