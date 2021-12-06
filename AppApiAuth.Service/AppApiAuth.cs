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
using MailSender;

namespace AppApiAuth.Service
{
    public partial class AppApiAuth : ServiceBase
    {

        Logger.FileLogger logger = new Logger.FileLogger("ServiceApiAuth");
        MailSend mailSend = new MailSend();
        string[] args = null;
        public AppApiAuth()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            this.args = args;
            logger.Log($"Service {nameof(AppApiAuth)} partito!");
            try
            {
                mailSend.SendEmail(subject: "Servizio avviato", message: $"Il servizio {nameof(AppApiAuth)} è stato avviato");
            }
            catch (Exception ex)
            {
                logger.Log($"Service {nameof(AppApiAuth)} ERRORE {ex.Message}");

            }
            Timer timer = new Timer();
            timer.Interval = 600000; // 600 seconds
            timer.Elapsed += new ElapsedEventHandler(this.OnTimer);
            timer.Start();
        }

        protected override void OnStop()
        {
            logger.Log($"Service {nameof(AppApiAuth)} terminato!");
            try
            {
                mailSend.SendEmail(subject: "Servizio terminato", message: $"Il servizio {nameof(AppApiAuth)} è stato terminato");
            }
            catch (Exception ex)
            {
                logger.Log($"Service {nameof(AppApiAuth)} ERRORE {ex.Message}");

            }
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
            try
            {
                mailSend.SendEmail(subject: "Servizio in arresto", message: $"Il servizio {nameof(AppApiAuth)} è in arresto");
            }
            catch (Exception ex)
            {
                logger.Log($"Service {nameof(AppApiAuth)} ERRORE {ex.Message}");

            }
        }

        public void OnTimer(object sender, ElapsedEventArgs args)
        {
            // TODO: Insert monitoring activities here.
            logger.Log($"Service {nameof(AppApiAuth)} timer scattato!");
            try
            {
                ConsoleAppAPIAuth.Program.Main(this.args);
            }
            catch (Exception ex)
            {
                try
                {
                    logger.Log($"Service {nameof(AppApiAuth)} ERRORE {ex.Message}");
                    mailSend.SendEmail(subject: "Servizio andato in errore", message: $"Il servizio {nameof(AppApiAuth)} è in errore: {ex.Message}");
                }
                catch (Exception ex2)
                {

                }
            }
        }
    }
}
