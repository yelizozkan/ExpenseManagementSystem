using Microsoft.Extensions.Configuration;

namespace ExpenseManagementSystem.Persistence
{
    public static class Configuration
    {
        public static string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();

                try
                {
                    configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ExpenseManagementSystem.API"));
                    configurationManager.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                }
                catch
                {
                    configurationManager.AddJsonFile("appsettings.Production.json", optional: true);
                }

                return configurationManager.GetConnectionString("DefaultConnection");
            }
        }
    }
}
