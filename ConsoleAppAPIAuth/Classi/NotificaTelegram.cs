using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace ConsoleAppAPIAuth.Classi
{
    class NotificaTelegram
    {
  
      //private static readonly TelegramBotClient bot = new TelegramBotClient("2142231062:AAEKp4T7TD0L0U54I3I_JWw3Jv_SGzRfQXg");
        public static void SendMSG(long Destinatario, string Messaggio )
        {
       TelegramBotClient bot = new TelegramBotClient("2142231062:AAEKp4T7TD0L0U54I3I_JWw3Jv_SGzRfQXg");
        //if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)e.Message.Chat.Id
        bot.SendTextMessageAsync(Destinatario, Messaggio);

        }
    }
}
