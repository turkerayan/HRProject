using IkProject.Application.Expections;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application
{
    public static class ConfigureExpectionMiddleware
    {
        public static void ConfigureExpectionHandleingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExpectionMiddelware>();
        }
    }
}
