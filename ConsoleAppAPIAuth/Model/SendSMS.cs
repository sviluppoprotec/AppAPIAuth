using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAPIAuth.Model
{
    public class SendSMS
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
}
