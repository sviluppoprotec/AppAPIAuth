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

namespace AppApiAuth.Service
{
    public partial class AppApiAuth : ServiceBase
    {

        Logger.FileLogger logger = new Logger.FileLogger();

        string[] args = null;
        public AppApiAuth()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            this.args = args;
            logger.Log($"Service {nameof(AppApiAuth)} partito!");
            Timer timer = new Timer();
            timer.Interval = 600000; // 600 seconds
            timer.Elapsed += new ElapsedEventHandler(this.OnTimer);
            timer.Start();
        }

        protected override void OnStop()
        {
            logger.Log($"Service {nameof(AppApiAuth)} terminato!");
        }

        protected override void OnContinue()
        {
            logger.Log($"Service {nameof(AppApiAuth)} ripreso!");
        }
        protected override void OnPause()
        {
            logger.Log($"Service {nameof(AppApiAuth)} in pausa!");
        }
        protected override void OnShutdown()
        {
            logger.Log($"Service {nameof(AppApiAuth)} in arresto!");
        }

        public void OnTimer(object sender, ElapsedEventArgs args)
        {
            // TODO: Insert monitoring activities here.
            logger.Log($"Service {nameof(AppApiAuth)} timer scattato!");
            ConsoleAppAPIAuth.Program.Main(this.args);
        }
    }
}
