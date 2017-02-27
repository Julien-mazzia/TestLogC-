using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace LogCoucou
{
    public partial class Service1 : ServiceBase
    {
        private Timer timer = null;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer = new Timer();
            this.timer.Interval = 60000;
            this.timer.Elapsed += new System.Timers.ElapsedEventHandler(this.tick);
            timer.Enabled = true;
        }

        protected override void OnStop()
        {
        }

        public void tick(object sender, ElapsedEventArgs e ){
            WriteLog();
        }

        public void WriteLog()
        {
            string source = "Service Test";
            string fichier_log = "Application";
            string message = "Coucou";

            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, fichier_log);
            }
            EventLog.WriteEntry(source, message);
        }
    }
}
