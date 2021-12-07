using ConsoleAppAPIAuth.SmsSenderService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAPIAuth.Classi.SmsSender
{
    public class SmsSenderHandler
    {
        public static String MY_USERNAME = "AnovelliProtec";
        public static String MY_PASSWORD = "Floridiana00135";
        public static String Sender = "Sms sistema";
        public static InvioSmsResult Invia(string[] recipient, string testo){
            SMSSoapClient client = new SMSSoapClient();
            return client.InvioSms(MY_USERNAME, MY_PASSWORD, Sender, recipient, testo);
        }
    }
}
