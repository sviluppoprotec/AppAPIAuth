﻿using ConsoleAppAPIAuth.Classi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAPIAuth
{
    class Program
    {
        static void Main(string[] args)
        {

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
            DateTime datascadenza = DateTime.Now.AddSeconds(+570);  // 570 A 9 MINUTI E MEZZO
            int giri = 0;
            string sessione_ID = Guid.NewGuid().ToString();
            DateTime dataSessioneLancio = DateTime.Now;
            // Part 2: use do-while loop to sum numbers in 4-element array.
            do
            {
                try
                {
                    using (SendNotificaSMS mandaMailSms = new SendNotificaSMS())
                    {
                        mandaMailSms.Run(
                        "Admin",
                        AppDomain.CurrentDomain.BaseDirectory,
                        dataSessioneLancio,
                        sessione_ID);

                        //mandaMailSms.UnLocketRecord(
                        //System.Configuration.ConfigurationManager.ConnectionStrings["CN"].ConnectionString,
                        //"Admin",
                        //AppDomain.CurrentDomain.BaseDirectory,
                        //dataSessioneLancio,
                        //sessione_ID);
                    }
                    if (false)
                    {
                        //using (VerificaStatoInvioSMS verSMS = new VerificaStatoInvioSMS())
                        //{
                        //    //verSMS.SetStatusInvioSMS(System.Configuration.ConfigurationManager.ConnectionStrings["CN"].ConnectionString, "Admin", sessione_ID);
                        //}
                    }
                }
                catch
                {
                    System.Console.WriteLine("Errore");
                }
                System.Threading.Thread.Sleep(5000);
                giri++;
                System.Console.WriteLine("Data Attuale: " + DateTime.Now);
                System.Console.WriteLine("Data Scadenza: " + datascadenza);
                TimeSpan diff1 = datascadenza.Subtract(DateTime.Now);
                System.Console.WriteLine("Differenza in secondi: " + diff1.Seconds);
                System.Console.WriteLine("numero di giri fatti: " + giri);
            } while (datascadenza > DateTime.Now);

        }
    }
}