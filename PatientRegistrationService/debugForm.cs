using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientRegistrationService
{
    public partial class DebugForm : Form
    {
        private readonly ServiceBase[] servicesToRun;
        private Task serviceTask;

        public DebugForm(ServiceBase[] servicesToRun)
        {
            InitializeComponent();
            uxStop.Enabled = false;
            this.servicesToRun = servicesToRun;
        }

        public void AddMessage(string message)
        {
            DoAction(() =>
            {
                var lines = new List<string>(uxMessages.Lines);
                lines.Add(message);
                uxMessages.Lines = lines.ToArray();
                uxMessages.SelectionStart = uxMessages.TextLength;
                uxMessages.ScrollToCaret();
            });
        }

        private void DoAction(Action a)
        {
            if (InvokeRequired)
            {
                BeginInvoke(a);
            }
            else
            {
                a();
            }
        }

        private void uxStart_Click(object sender, EventArgs e)
        {
            uxStart.Enabled = false;
            MethodInfo onStartMethod = typeof(ServiceBase).GetMethod("OnStart",
                BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (ServiceBase service in servicesToRun)
            {
                //Console.Write("Starting {0}...", service.ServiceName);
                onStartMethod.Invoke(service, new object[] { new string[] { } });
                //Console.Write("Started");
            }
            uxStop.Enabled = true;
        }

        private void uxStop_Click(object sender, EventArgs e)
        {
            uxStop.Enabled = false;
            MethodInfo onStopMethod = typeof(ServiceBase).GetMethod("OnStop",
                BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (ServiceBase service in servicesToRun)
            {
                //Console.Write("Stopping {0}...", service.ServiceName);
                onStopMethod.Invoke(service, null);
                //Console.WriteLine("Stopped");
            }
            uxStart.Enabled = true;
        }

        private void uxMessages_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
