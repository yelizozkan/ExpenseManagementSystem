using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
