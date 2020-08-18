using PatientRegistrationService.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRegistrationService.Services
{
    public class ConfigurationService
    {
        DBService dBService;

        public ConfigurationService()
        {
            dBService = new DBService();
        }
        public ServiceConfiguration configuration(string dbName, string tableName)
        {
            var result = ConvertHelper.ConvertDataTableToList<ServiceConfiguration>(dBService.GetConfiguration(dbName, tableName));
            return result[0];
        }
    }
}
