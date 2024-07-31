using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Quaries.Login
{
    public class LoginQueryResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
