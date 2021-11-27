using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleNotificheAPI
{
    class SendSms : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


    }
}
