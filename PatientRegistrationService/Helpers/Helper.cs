using PatientRegistrationService.Models;
using PatientRegistrationService.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRegistrationService.Helpers
{
    public static class Helper
    {
        public static object _locked = new object();
        public static DebugForm _debugForm = null;
        private static string dbName = ConfigurationManager.AppSettings["DatabaseName"].ToString();

        public static void WriteToFile(string Message)
        {
            ConfigurationService configurationService = new ConfigurationService();
            //Configuration Settings
            string path = configurationService.configuration(dbName, "ServiceConfiguration").LogsFilePath;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            lock (_locked)
            {
                string filepath = $"{path}\\ServiceLog_ {DateTime.Now.Date.ToShortDateString().Replace('/', '_')}.txt";
                if (!File.Exists(filepath))
                {
                    // Create a file to write to.   
                    using (StreamWriter sw = File.CreateText(filepath))
                    {
                        sw.WriteLine(DateTime.Now + "---" + Message);
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(filepath))
                    {
                        sw.WriteLine(DateTime.Now + "---" + Message);
                    }
                }

                if (_debugForm != null)
                {
                    _debugForm.AddMessage(Message);
                }
            }
        }
    }
}
