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
        public static InvioSmsResult Invia(string[] recipient, string testo)
        {
            try
            {
                InvioSmsResult res = null;
                IEnumerable<string> messages = Split(testo, 160);
                foreach (string m in messages)
                {
                    SMSSoapClient client = new SMSSoapClient();
                    res = client.InvioSms(MY_USERNAME, MY_PASSWORD, Sender, recipient, m);
                    logger.Log(JsonConvert.SerializeObject(res));
                }
                return res;
            }
            catch (Exception ex)
            {
                logger.Log(ex.Message);
                return new InvioSmsResult()
                {
                    Successo = false,
                    CodiceErrore = ex.Message
                };
            }
        }

        public static StatoSmsResult GetStatoSms(string CodiceCliente, DateTime dataInvio)
        {
            try
            {
                string id = $"{CodiceCliente}{dataInvio.Hour}{dataInvio.Minute.ToString().PadLeft(2,'0')}";
                SMSSoapClient client = new SMSSoapClient();
                var res = client.StatoSms(MY_USERNAME, MY_PASSWORD, id);
                logger.Log(JsonConvert.SerializeObject(res));
                return res;
            }
            catch (Exception ex)
            {
                logger.Log(ex.Message);
                return new StatoSmsResult()
                {
                    Successo = false,
                    CodiceErrore = ex.Message
                };
            }
        }

        public static CreditoResiduoResult GetCreditoResiduo()
        {
            try
            {
                SMSSoapClient client = new SMSSoapClient();
                var res = client.CreditoResiduo(MY_USERNAME, MY_PASSWORD);
                logger.Log(JsonConvert.SerializeObject(res));
                return res;
            }
            catch (Exception ex)
            {
                logger.Log(ex.Message);
                return new CreditoResiduoResult()
                {
                    Successo = false,
                    CodiceErrore = ex.Message
                };
            }
        }

        static IEnumerable<string> Split(string str, int chunkSize)
        {
            var split = str.Select((c, index) => new { c, index })
                .GroupBy(x => x.index / chunkSize)
                .Select(group => group.Select(elem => elem.c))
                .Select(chars => new string(chars.ToArray()));
            return split;
        }
    }
}
