using Microsoft.Extensions.Configuration;


namespace IkProject.Persistence
{
    public static class Configuration
    {
        public static string ConnectionString
        {
            get
            {
                ConfigurationManager manager = new();
                //manager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../IkProject.API"));
                manager.AddJsonFile("appsettings.json");

                //return manager.GetConnectionString("TugbaDbIKProject");

                return manager.GetConnectionString("AzureMsSql");

                //return manager.GetConnectionString("CanDbIkProject");
                //return manager.GetConnectionString("CihanDbIkProject");
            }
        }
    }
}
