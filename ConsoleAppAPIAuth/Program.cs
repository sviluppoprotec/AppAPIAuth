using ConsoleAppAPIAuth.Classi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAPIAuth
{
    public class Program
    {
        static Logger.FileLogger logger = new Logger.FileLogger();
        public static void Main(string[] args)
        {
            logger.Log($"ConsoleAppAPIAuth start"); 
            string telefoniDestinatari = "+393463228369";
            string Messaggio = " mio messaggio";
            //GestioneSMS(telefoniDestinatari, MESSAGE_MEDIUM_QUALITY, Messaggio);
            List<string> listOrariStart = new List<string>();
            DateTime Now = DateTime.Now;
            DateTime Start = DateTime.Now;
            DateTime End = DateTime.Now;
            DateTime datePrecedente = new DateTime(Now.Year, Now.Month, Now.Day, 0, 0, 0);
            DateTime dateSuccessiva = datePrecedente.AddDays(1);
            datePrecedente = datePrecedente.AddHours(2);
            dateSuccessiva = dateSuccessiva.AddHours(-1);

            TimeSpan tsInf = new TimeSpan(0, 0, 0, 0);
            TimeSpan tsSup = new TimeSpan(1, 0, 0, 0);
            TimeSpan tsStepCombo = new TimeSpan(2, 0, 0);
            TimeSpan span30Min = new TimeSpan(0, 30, 0);
            TimeSpan interval = new TimeSpan(1, 0, 0, 0);

            interval = dateSuccessiva - datePrecedente;
            DateTime datascadenza = DateTime.Now.AddSeconds(+590);  // 570 A 9 MINUTI E MEZZO
            int giri = 0;
            string sessione_ID = Guid.NewGuid().ToString();
            DateTime dataSessioneLancio = DateTime.Now;
            // Part 2: use do-while loop to sum numbers in 4-element array. tipo == "Spedisci" || tipo == "Controlla"
            do
            {
                try
                {
                    using (SendNotificaSMS mandaMailSms = new SendNotificaSMS())
                    {
                        mandaMailSms.Run(
                        "Admin",
                        "Spedisci",
                        dataSessioneLancio,
                        sessione_ID);          
                    }
                    using (SendNotificaSMS mandaMailSms = new SendNotificaSMS())
                    {
                        mandaMailSms.Run(
                        "Admin",
                        "Controlla",
                        dataSessioneLancio,
                        sessione_ID);
                    }
                }
                catch(Exception ex)
                {
                    System.Console.WriteLine("ConsoleAppAPIAuth Errore");

                    logger.Log($"ConsoleAppAPIAuth error {ex.Message}");
                }
                System.Threading.Thread.Sleep(4000);
                giri++;
                System.Console.WriteLine("Data Attuale: " + DateTime.Now);
                System.Console.WriteLine("Data Scadenza: " + datascadenza);
                TimeSpan diff1 = datascadenza.Subtract(DateTime.Now);
                System.Console.WriteLine("Differenza in secondi: " + diff1.TotalSeconds);
                System.Console.WriteLine("numero di giri fatti: " + giri);
                System.Console.WriteLine("========================= " );

            } while (datascadenza > DateTime.Now);
            logger.Log("end");
        }
    }
}
