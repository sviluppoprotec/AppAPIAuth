using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAPIAuth.Model
{

    //        {
    //    "recipient_number": 1,
    //    "result": "OK",
    //    "recipients": [
    //        {
    //            "status": "WAITING",
    //            "destination": "+393471234567",
    //            "delivery_date": "20180307175609",
    //            "first_click_date": "yyyyMMddHHmmss","// (Optional, present for Rich SMS) When the embedded link was clicked first"
    //            "last_click_date": "yyyyMMddHHmmss", "// (Optional, present for Rich SMS) When the embedded link was clicked last"
    //            "total_clicks": "561"                "// (Optional, present for Rich SMS) Total number of clicks on the link"
    //        }
    //    ]
    //}

    //"result": "OK",
    //"recipients": [
    //  {
    //    "destination": "+393463228369",
    //    "status": "DLVRD",
    //    "delivery_date": "20211129154835"
    //  }
    //],
    //"recipient_number": 1
    //}
    public class StatusSMSApi
    {
        public String recipient_number;
        public String result;
        public MyRecipients recipients;

    }
    public class MyRecipients
    {
        public String destination;
        public String status;
        public String delivery_date;

    }
}
