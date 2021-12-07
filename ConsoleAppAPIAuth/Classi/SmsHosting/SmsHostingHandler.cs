using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAPIAuth.Classi.SmsHosting
{

    public class SmsHostingResponse
    {
        [JsonProperty("from")]
        public string From { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("transactionId")]
        public string TransactionId { get; set; }
        [JsonProperty("smsInserted")]
        public int SmsInserted { get; set; }
        [JsonProperty("smsNotInserted")]
        public int SmsNotInserted { get; set; }
        [JsonProperty("sms")]
        public List<SmsHostingResponseSms> sms { get; set; }

        [JsonProperty("errorMsg")]
        public string ErrorMsg { get; set; }
        [JsonProperty("errorCode")]
        public int ErrorCode { get; set; }
    }

    public class SmsHostingResponseSms
    {

        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("to")]
        public string To { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class SmsHostingCheckMessageResponse
    {
        [JsonProperty("metadata")]
        public SmsHostingCheckMessageResponseMetadata Metadata { get; set; }
        [JsonProperty("smsList")]
        public List<SmsHostingCheckMessageResponseSms> SmsList { get; set; }
    }

    public class SmsHostingCheckMessageResponseMetadata
    {
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("offset")]
        public int offset { get; set; }
        [JsonProperty("limit")]
        public int limit { get; set; }
    }

public class SmsHostingCheckMessageResponseSms
    {
        [JsonProperty("id")]
        public long id { get; set; }
        [JsonProperty("to")]
        public string to { get; set; }
        [JsonProperty("text")]
        public string text { get; set; }
        [JsonProperty("from")]
        public string from { get; set; }
        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("insertDate")]
        public DateTime insertDate { get; set; }
        [JsonProperty("sentDate")]
        public DateTime sentDate { get; set; }
        [JsonProperty("deliveryDate")]
        public DateTime deliveryDate { get; set; }
        [JsonProperty("transactionId")]
        public string transactionId { get; set; }
        [JsonProperty("price")]
        public decimal price { get; set; }
    }

public class SmsHostingHandler
    {
        private static Logger.FileLogger logger = new Logger.FileLogger("SMSHANDLER");
        private static string AUTH_KEY = "SMSHFKEJ2F5PCJIMDIL7K";
        private static string AUTH_SECRET = "2YRUUKBNBHTRCXLKVYTFX5LI2HYHMOOL";

        public static String BASEURL = "https://AUTH_KEY:AUTH_SECRET@api.smshosting.it/rest/api/user";
        public static String BASEURL2 = "https://SMSHFKEJ2F5PCJIMDIL7K:2YRUUKBNBHTRCXLKVYTFX5LI2HYHMOOL@api.smshosting.it/rest/api/user";

        public static SmsHostingResponse Invia(string recipient, string testo)
        {
            return CallSendApi(recipient, testo);
        }

        private static SmsHostingResponse CallSendApi(string recipient, string testo)
        {
            var client = new RestClient("https://api.smshosting.it/rest/api/sms/send");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Authorization", $"Basic {EncodeTo64($"{AUTH_KEY}:{AUTH_SECRET}")}");
            request.AddParameter("from", "Protec Srl");
            request.AddParameter("to", recipient);
            request.AddParameter("text", testo);
            request.AddParameter("sandbox", "false");
            // request.AddParameter("statusCallback", "https://www.pranio.it");
            IRestResponse response = client.Execute(request);
            logger.Log(response.Content);

            SmsHostingResponse sentSMSResponse =
                JsonConvert.DeserializeObject<SmsHostingResponse>(response.Content);
            return sentSMSResponse;

            // { "errorMsg":"BAD_CREDENTIALS","errorCode":401}

            // { "from":"DemoSMS",
            // "text":"Messaggio corpulento inviato col progetto di test",
            // "transactionId":"54d038072035b3c6d6f5d6b4f6a244d0",
            // "smsInserted":0,"smsNotInserted":0,"sms":[]}
        }

        public static SmsHostingCheckMessageResponse CheckSms(string Id){
            var client = new RestClient($"https://api.smshosting.it/rest/api/sms/search?id={Id}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Basic {EncodeTo64($"{AUTH_KEY}:{AUTH_SECRET}")}");
            IRestResponse response = client.Execute(request);
            logger.Log(response.Content);
            SmsHostingCheckMessageResponse checkSMSResponse =
                JsonConvert.DeserializeObject<SmsHostingCheckMessageResponse>(response.Content);
            return checkSMSResponse;
        }

        static internal string EncodeTo64(string toEncode)
        {

            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);

            string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);

            return returnValue;

        }
    }

}
