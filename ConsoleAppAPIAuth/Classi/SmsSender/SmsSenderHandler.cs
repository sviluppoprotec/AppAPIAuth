using ConsoleAppAPIAuth.SmsSenderService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAPIAuth.Classi.SmsSender
{
    public class SmsSenderHandler
    {
        private static Logger.FileLogger logger = new Logger.FileLogger("SMSSENDER");
        public static String MY_USERNAME = "AnovelliProtec";
        public static String MY_PASSWORD = "Floridiana00135";
        public static String Sender = "Sms sistema";
        public static InvioSmsResult Invia(string[] recipient, string testo){
            SMSSoapClient client = new SMSSoapClient();
            var res = client.InvioSms(MY_USERNAME, MY_PASSWORD, Sender, recipient, testo);
            logger.Log(JsonConvert.SerializeObject(res));
            return res;
        }

        public static StatoSmsResult GetStatoSms(string id)
        {
            SMSSoapClient client = new SMSSoapClient();
            var res = client.StatoSms(MY_USERNAME, MY_PASSWORD, id);
            logger.Log(JsonConvert.SerializeObject(res));
            return res;
        }
    }
}
