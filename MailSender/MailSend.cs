using AegisImplicitMail;
using System;
using System.ComponentModel;


namespace MailSender
{
    public class MailSend
    {
        public void SendEmail(
            string recipient = "protec@protecsrl.biz",
            string recipientCC = "protec@protecsrl.biz",
            string subject = "subject",
            string message = "message",
            string host = "smtps.aruba.it",
            string user = "protec@protecsrl.biz",
            string pass = "ardea33",
            int port = 465
        )
        {
            //Generate Message 
            var mymessage = new MimeMailMessage();
            mymessage.From = new MimeMailAddress(recipient);
            mymessage.To.Add(recipient);
            mymessage.CC.Add(recipientCC);
            mymessage.Subject = subject;
            mymessage.Body = message;

            //Create Smtp Client
            var mailer = new MimeMailer(host, port);
            mailer.User = user;
            mailer.Password = pass;
            mailer.SslType = SslMode.Ssl;
            mailer.AuthenticationMode = AuthenticationType.Base64;

            //Set a delegate function for call back
            mailer.SendCompleted += compEvent;
            mailer.SendMailAsync(mymessage);
        }

        //Call back function
        private void compEvent(object sender, AsyncCompletedEventArgs e)
        {
            if (e.UserState != null)
                Console.Out.WriteLine(e.UserState.ToString());

            Console.Out.WriteLine("is it canceled? " + e.Cancelled);

            if (e.Error != null)
                Console.Out.WriteLine("Error : " + e.Error.Message);
        }
    }
}
