using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Diagnostics;
using System.Reflection;

namespace PatientRegistrationService
{
    static class Program
    {
        static void Main(string[] args)
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            //If true then it means Project is running as debug mode. It will enable the code debugging
            if (IsDebugMode())
            {
                var form = new DebugForm(ServicesToRun);
                Helpers.Helper._debugForm = form;
                Application.Run(form);
            }
            //If false then its in release mode
            else
            {
                ServiceBase.Run(ServicesToRun);
            }

        }


        private static bool IsDebugMode()
        {
            object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(DebuggableAttribute), false);
            if ((customAttributes != null) && (customAttributes.Length == 1))
            {
                DebuggableAttribute attribute = customAttributes[0] as DebuggableAttribute;
                return (attribute.IsJITOptimizerDisabled && attribute.IsJITTrackingEnabled);
            }
            return false;
        }
    }
}
