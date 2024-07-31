using IkProject.Application.Abstractions;
using IkProject.Application.Abstractions.Services;
using IkProject.Infrastructure.ImageService;
using IkProject.Infrastructure.Services;
using IkProject.Infrastructure.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.Extensions.DependencyInjection;

using Microsoft.IdentityModel.Tokens;
using System.Text;



namespace IkProject.Infrastructure
{
    public static class ServiceRegistration
    {

        public static void AddInfrastructureServices(this IServiceCollection services)
        {

            services.AddTransient<ITokenServices, TokenServices>();

            services.AddTransient<IFileHelper, FileHelper>();

            services.Configure<TokenSettings>(Configuration.Token.GetSection("Token"));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new()
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration.Token["Token:Issuer"],
                    ValidAudience = Configuration.Token["Token:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.Token["Token:SecurityKey"])),
                    ClockSkew = TimeSpan.Zero
                };
            });
            services.AddTransient<IMailServices,MailService>(); 

        }
    }
}
