using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace IkProject.Infrastructure
{
    public static class Configuration
    {
        public static IConfigurationRoot Token
        {
            get
            {
                var envConfigBuild = new ConfigurationBuilder().AddEnvironmentVariables().Build();
                var env = envConfigBuild["ASPNETCORE_ENVIRONMENT"];
                env = env.IsNullOrEmpty() ? "Production" : env;
                ConfigurationBuilder manager = new();
                //manager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../IkProject.API"));
                manager.AddJsonFile("appsettings.json")
                       .AddJsonFile($"appsettings.{env}.json");
                return manager.Build();
            }
        }
    }
}
