using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace ConsoleAppAPIAuth.Classi
//{
//    class myTelegramBot
//    {
//    }
//}
using System;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace ConsoleAppAPIAuth.Classi
{
    class myTelegramBot
    {
        /// <summary>
        //msg mandato a barbara
//https://api.telegram.org/bot2142231062:AAEKp4T7TD0L0U54I3I_JWw3Jv_SGzRfQXg/sendMessage?chat_id=2143589472&text=questomrssaggio

//{"ok":true,"result":{"message_id":10,"from":{"id":2142231062,"is_bot":true,"first_name":"GiuliAle","username":"GiuliAle24Bot"},"chat":{"id":2143589472,"first_name":"Barbara","last_name":"Pace","username":"Barbara040502","type":"private"},"date":1637604819,"text":"questomrssaggio"}}

//msg mandato a me
//https://api.telegram.org/bot2142231062:AAEKp4T7TD0L0U54I3I_JWw3Jv_SGzRfQXg/sendMessage?chat_id=2146470928&text=nuovo_messaggio_inviato_da_api

//{"ok":true,"result":{"message_id":14,"from":{"id":2142231062,"is_bot":true,"first_name":"GiuliAle","username":"GiuliAle24Bot"},"chat":{"id":2146470928,"first_name":"Alessandro","last_name":"Giuli","username":"IngGiuli","type":"private"},"date":1637605036,"text":"nuovo_messaggio_inviato_da_api"}}

        /// Declare Telegrambot object
        /// </summary>
        private static readonly TelegramBotClient bot = new TelegramBotClient("2142231062:AAEKp4T7TD0L0U54I3I_JWw3Jv_SGzRfQXg");

        /// <summary>
        /// csharp corner chat bot web hook
        /// </summary>
        /// <param name="args"></param>
        //static void Main(string[] args)
        //{
        //    bot.OnMessage += Csharpcornerbotmessage;
        //    bot.StartReceiving();
        //    Console.ReadLine();
        //    bot.StopReceiving();

        //}

        /// <summary>
        /// Handle bot webhook
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Csharpcornerbotmessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
                PrepareQuestionnaires(e);
        }
        public static void PrepareQuestionnaires(MessageEventArgs e)
        {
            if (e.Message.Text.ToLower() == "hi")
                bot.SendTextMessageAsync(e.Message.Chat.Id, "hello dude" + Environment.NewLine + "welcome to csharp corner chat bot." + Environment.NewLine + "How may i help you ?");
            else if (e.Message.Text.ToLower().Contains("know about"))
                bot.SendTextMessageAsync(e.Message.Chat.Id, "Yes sure..!!" + Environment.NewLine + "Mahesh Chand is the founder of C# Corner.Please go through for more detail." + Environment.NewLine + "https://www.c-sharpcorner.com/about");
            else if (e.Message.Text.ToLower().Contains("logo"))
            {
                bot.SendStickerAsync(e.Message.Chat.Id, "https://csharpcorner-mindcrackerinc.netdna-ssl.com/App_Themes/CSharp/Images/SiteLogo.png");
                bot.SendTextMessageAsync(e.Message.Chat.Id, "Anything else?");
            }
            else if (e.Message.Text.ToLower().Contains("featured"))
                bot.SendTextMessageAsync(e.Message.Chat.Id, "Give me your profile link ");
            else if (e.Message.Text.ToLower().Contains("here"))
                bot.SendTextMessageAsync(e.Message.Chat.Id, Environment.NewLine + "https://www.c-sharpcorner.com/article/getting-started-with-ionic-framework-angular-and-net-core-3/" + Environment.NewLine + Environment.NewLine +
                    "https://www.c-sharpcorner.com/article/getting-started-with-ember-js-and-net-core-3/" + Environment.NewLine + Environment.NewLine +
                    "https://www.c-sharpcorner.com/article/getting-started-with-vue-js-and-net-core-32/");
            else if (e.Message.Text.ToLower().Contains("thank you"))
                bot.SendTextMessageAsync(e.Message.Chat.Id, "You're welcome..!!");
            else

                bot.SendTextMessageAsync(e.Message.Chat.Id, "This bot is under development");
        }
    }
}
