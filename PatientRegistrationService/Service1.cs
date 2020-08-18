using System;
using System.ComponentModel;
using System.Configuration;
using System.ServiceProcess;
using System.Timers;
using PatientRegistrationService.Helpers;
using PatientRegistrationService.Models;
using PatientRegistrationService.Services;

namespace PatientRegistrationService
{
    [RunInstaller(true)]
    public partial class Service1 : ServiceBase
    {
        string dbName = ConfigurationManager.AppSettings["DatabaseName"].ToString();

        private Timer tmrExecutor = new Timer();
        private int counter = 0;
        private PatientService patientService;
        private ConfigurationService configurationService;
        //Configuration Settings
        private ServiceConfiguration configSettings = new ServiceConfiguration();
        public Service1()
        {
            configurationService = new ConfigurationService();
            patientService = new PatientService();
            configSettings = configurationService.configuration(dbName, "ServiceConfiguration");
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            try
            {
                Helper.WriteToFile("Starting service ...");
                tmrExecutor.Elapsed += new ElapsedEventHandler(OnElapsedTime); // adding Event
                tmrExecutor.Interval = configSettings.Timer; // Reading timer info from database
                tmrExecutor.Enabled = true;
                tmrExecutor.Start();

                //Read Patient Info from text file and then insert or update the value
                patientService.ReadPatientInfo(configSettings);

            }
            catch (Exception ex)
            {
                //Helper file manage the logs
                Helper.WriteToFile(ExceptionManager.GetExceptionStackTrace(ex) + "\nStack Trace\n" + ex.StackTrace);
            }
        }

        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            try
            {
                counter++;

                if (counter % 3 == 0)
                {
                    patientService.ReadPatientInfo(configSettings);
                }

                Helper.WriteToFile("Service is recalled at " + DateTime.Now);
            }
            catch (Exception ex)
            {
                Helper.WriteToFile(ExceptionManager.GetExceptionStackTrace(ex) + "\nStack Trace\n" + ex.StackTrace);
            }
        }


        protected override void OnStop()
        {
            Helper.WriteToFile("Service is stopped at " + DateTime.Now);
        }
    }
}
