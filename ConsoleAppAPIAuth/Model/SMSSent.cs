using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAPIAuth.Model
{
    //class SMSSent
    //{
    //}
   public class SMSSent
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
