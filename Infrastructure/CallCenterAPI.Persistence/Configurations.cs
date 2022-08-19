using Microsoft.Extensions.Configuration;

namespace CallCenterAPI.Persistence;

public  class Configurations
{
    public static string ConnectionString
    {
        get
        {
            ConfigurationManager manager = new ConfigurationManager();
            manager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/CallCenterAPI.API"));
            manager.AddJsonFile("appsettings.json");
            return manager.GetConnectionString("PostgreSQL");
        }
    }
}