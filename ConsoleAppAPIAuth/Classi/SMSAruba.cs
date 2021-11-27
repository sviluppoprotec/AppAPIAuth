using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Text;
using System.Net;
using System.Collections.Specialized;

// We are using JSON.NET (http://www.newtonsoft.com/json)
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ConsoleAppAPIAuth.Classi
{
    class SMSAruba
    {
        //public const string HOSTNAME = "adminsms.aruba.it"; //"adminsms.aruba.it"; 
        //public const string USERNAME = "Sms52333"; //"your@login";1913233@aruba.it   ISUQ88   Sms52333
        //public const string PASSWORD = "Prt_040502"; //"yourpassword";1973ardea   Prt_040502
        //public const int DEFAULT_PORT = 80;
        //public const string PROXY = "";
        //public const int PROXY_PORT = 8080;
        public static String BASEURL = "https://adminsms.aruba.it/API/v1.0/REST/";

        public static String MESSAGE_HIGH_QUALITY = "N";
        public static String MESSAGE_MEDIUM_QUALITY = "L";

        public static String MY_USERNAME = "Sms52333";
        public static String MY_PASSWORD = "Prt_040502";

        //static void Main(string[] args)
        //{
        //    string telefoniDestinatari = "+393463228369";
        //    string Messaggio = " mio messaggio";
        //    GestioneSMS(telefoniDestinatari, MESSAGE_MEDIUM_QUALITY, Messaggio);
        //    List<string> listOrariStart = new List<string>();
        //    DateTime Now = DateTime.Now;
        //    DateTime Start = DateTime.Now;
        //    DateTime End = DateTime.Now;
        //    DateTime datePrecedente = new DateTime(Now.Year, Now.Month, Now.Day, 0, 0, 0);
        //    DateTime dateSuccessiva = datePrecedente.AddDays(1);
        //    datePrecedente = datePrecedente.AddHours(2);
        //    dateSuccessiva = dateSuccessiva.AddHours(-1);

        //    TimeSpan tsInf = new TimeSpan(0, 0, 0, 0);
        //    TimeSpan tsSup = new TimeSpan(1, 0, 0, 0);
        //    TimeSpan tsStepCombo = new TimeSpan(2, 0, 0);
        //    TimeSpan span30Min = new TimeSpan(0, 30, 0);
        //    TimeSpan interval = new TimeSpan(1, 0, 0, 0);

        //    interval = dateSuccessiva - datePrecedente;
        //    DateTime datascadenza = DateTime.Now.AddSeconds(+570);  // 570 A 9 MINUTI E MEZZO
        //    int giri = 0;
        //    // Part 2: use do-while loop to sum numbers in 4-element array.
        //    do
        //    {
        //        //try
        //        //{
        //        //    using (MandaMailSms mandaMailSms = new MandaMailSms())
        //        //    {
        //        //        mandaMailSms.RunEmailSms(System.Configuration.ConfigurationManager.ConnectionStrings["CN"].ConnectionString,
        //        //        "Admin",
        //        //        AppDomain.CurrentDomain.BaseDirectory,
        //        //        dataSessioneLancio,
        //        //        sessione_ID);

        //        //        mandaMailSms.UnLocketRecord(
        //        //        System.Configuration.ConfigurationManager.ConnectionStrings["CN"].ConnectionString,
        //        //        "Admin",
        //        //        AppDomain.CurrentDomain.BaseDirectory,
        //        //        dataSessioneLancio,
        //        //        sessione_ID);
        //        //    }
        //        //    if (false)
        //        //    {
        //        //        using (VerificaStatoInvioSMS verSMS = new VerificaStatoInvioSMS())
        //        //        {
        //        //            //verSMS.SetStatusInvioSMS(System.Configuration.ConfigurationManager.ConnectionStrings["CN"].ConnectionString, "Admin", sessione_ID);
        //        //        }
        //        //    }
        //        //}
        //        //catch
        //        //{
        //        //    System.Console.WriteLine("Errore");
        //        //}
        //        System.Threading.Thread.Sleep(5000);
        //        giri++;
        //        System.Console.WriteLine("Data Attuale: " + DateTime.Now);
        //        System.Console.WriteLine("Data Scadenza: " + datascadenza);
        //        TimeSpan diff1 = datascadenza.Subtract(DateTime.Now);
        //        System.Console.WriteLine("Differenza in secondi: " + diff1.Seconds);
        //        System.Console.WriteLine("numero di giri fatti: " + giri);
        //    } while (datascadenza > DateTime.Now);

        //    #region vecchio codice
        //    //String[] auth = authenticate(MY_USERNAME, MY_PASSWORD);

        //    //SendSMS sendSMSRequest = new SendSMS();

        //    //sendSMSRequest.message = "prova basso ";
        //    ////sendSMSRequest.message_type = MESSAGE_HIGH_QUALITY;
        //    //sendSMSRequest.message_type = MESSAGE_MEDIUM_QUALITY;
        //    //string telefonodestinatario = "+393463228369";
        //    //sendSMSRequest.recipient = new String[] { "+393463228369" };
        //    ////  sendSMSRequest.recipient = new String[] { "+39349123456789" };

        //    //// Send the SMS message at the given date (Optional)
        //    //int minute = DateTime.Now.AddMinutes(+2).Minute;
        //    //int ora = DateTime.Now.Hour;
        //    //sendSMSRequest.scheduled_delivery_time = null; // new DateTime(2021, 11, 24, ora, minute, 00);
        //    //sendSMSRequest.returnCredits = true;
        //    //sendSMSRequest.returnRemaining = true;

        //    //SMSSent smsSent = mysendSMS(auth, sendSMSRequest);

        //    //if ("OK".Equals(smsSent.result))
        //    //{
        //    //    Console.WriteLine("SMS successfully sent!");
        //    //    string msg = string.Format("smsSent.order_id {0}, smsSent.remaining_credits {1}, smsSent.result {2}, , smsSent.total_sent {3}",
        //    //        smsSent.order_id, smsSent.remaining_credits, smsSent.result, smsSent.total_sent);
        //    //    Console.WriteLine(msg);
        //    //}
        //    //Console.WriteLine(smsSent.result.ToString());
        //    #endregion
        //}



        public static SMSSent GestioneSMS(string telefoniDestinatari, String message_type, string Messaggio)
        {
            //SMSSent smsSent = null;
            String[] auth = authenticate(MY_USERNAME, MY_PASSWORD);

            SendSMS sendSMSRequest = new SendSMS();
            sendSMSRequest.message = Messaggio;
            sendSMSRequest.message_type = message_type;
            sendSMSRequest.recipient = new String[] { telefoniDestinatari };


            // Send the SMS message at the given date (Optional)
            int minute = DateTime.Now.AddMinutes(+2).Minute;
            int ora = DateTime.Now.Hour;
            sendSMSRequest.scheduled_delivery_time = null; // new DateTime(2021, 11, 24, ora, minute, 00);
            sendSMSRequest.returnCredits = true;
            sendSMSRequest.returnRemaining = true;

            SMSSent smsSent = mysendSMS(auth, sendSMSRequest);

            if ("OK".Equals(smsSent.result))
            {
                Console.WriteLine("SMS successfully sent!");
                string msg = string.Format("smsSent.order_id {0}, smsSent.remaining_credits {1}, smsSent.result {2}, , smsSent.total_sent {3}",
                    smsSent.order_id, smsSent.remaining_credits, smsSent.result, smsSent.total_sent);
                Console.WriteLine(msg);
            }
            Console.WriteLine(smsSent.result.ToString());
            return smsSent;
        }

        /**
         * Authenticates the user given it's username and
         * password. Returns a couple (user_key, session_key)
         */
        static String[] authenticate(String username, String password)
        {
            String[] auth = null;

            using (var wb = new WebClient())
            {
                var response = wb.DownloadString(BASEURL +
                                                 "login?username=" + username +
                                                 "&password=" + password);
                auth = response.Split(';');
            }

            return auth;
        }


        /**
         * Sends an SMS
         */
        static SMSSent mysendSMS(String[] auth, SendSMS sendSMS)
        {
            using (var wb = new WebClient())
            {
                // Setting the encoding is required when sending UTF8 characters!
                wb.Encoding = System.Text.Encoding.UTF8;

                wb.Headers.Set(HttpRequestHeader.ContentType, "application/json");
                wb.Headers.Add("user_key", auth[0]);
                wb.Headers.Add("Session_key", auth[1]);

                String json = JsonConvert.SerializeObject(sendSMS);

                var sentSMSBody =
                    wb.UploadString(BASEURL + "sms", "POST", json);

                SMSSent sentSMSResponse =
                    JsonConvert.DeserializeObject<SMSSent>(sentSMSBody);

                return sentSMSResponse;
            }
        }

    }

    /**
 * This object is used to create an SMS message sending request.
 * The JSon object is then automatically created starting from an
 * instance of this class, using JSON.NET.
 */
    class SendSMS
    {
        /** The message body */
        public String message;

        /** The message type */
        public String message_type;

        /** The sender Alias (TPOA) */
        public String sender;

        /** Postpone the SMS message sending to the specified date */
        public DateTime? scheduled_delivery_time;

        /** The list of recipients */
        public String[] recipient;

        /** Should the API return the remaining credits? */
        public Boolean returnCredits = false;

        public Boolean returnRemaining = false;
    }


    /**
     * This class represents the API Response. It is automatically created starting
     * from the JSON object returned by the server, using GSon
     */
    class SMSSent
    {
        /** The result of the SMS message sending */
        public String result;

        /** The order ID of the SMS message sending */
        public String order_id;

        /** The actual number of sent SMS messages */
        public int total_sent;

        /** The remaining credits */
        public int remaining_credits;


    }




}
