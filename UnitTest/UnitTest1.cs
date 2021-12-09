using ConsoleAppAPIAuth.Classi;
using ConsoleAppAPIAuth.Classi.SmsHosting;
using ConsoleAppAPIAuth.Classi.SmsSender;
using Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        string m150 = "Messaggio per prova 150 caratteri inviato col progetto di test Nullam lobortis lectus quis quam auctor, in tristique arcu feugiat. Sed eu sapien luct";
        string m300 = "Messaggio per prova 300 caratteri inviato col progetto di test Nullam lobortis lectus quis quam auctor, in tristique arcu feugiat. Sed eu sapien luctus, rutrum lorem eu, fringilla dolor. Phasellus nec leo orci. Sed sagittis metus nec sapien faucibus sodales. In efficitur accumsan metus et varius. D";
        string m450 = "Messaggio per prova 450 caratteri inviato col progetto di test Nullam lobortis lectus quis quam auctor, in tristique arcu feugiat. Sed eu sapien luctus, rutrum lorem eu, fringilla dolor. Phasellus nec leo orci. Sed sagittis metus nec sapien faucibus sodales. In efficitur accumsan metus et varius. Donec sit amet sodales orci. Donec at orci sit amet elit sagittis mattis. Integer accumsan dolor id nisi luctus tempor. Praesent urna turpis, eleifende";
        [TestMethod]
        public void TestLog()
        {
            try
            {
                FileLogger logger = new FileLogger("Test");
                logger.Log("test");
            } catch (Exception ex){
                ;
            }
        }

        [TestMethod]
        public void TestAruba()
        {
            try
            {
                var r = SMSAruba.GestioneSMS("3288279496", "N", "prova");
                Assert.IsTrue(r.result == "OK");
            }
            catch (Exception ex)
            {
                ;
            }
        }

        [TestMethod]
        public void TestSmsSender()
        {
        
            try
            {
                var r = SmsSenderHandler.Invia(new string[] { "3288279496", "3396140489" }, m150);
                Assert.IsTrue(r.Successo);
                var rc = SmsSenderHandler.GetStatoSms("cliente115042", DateTime.Now);
                Assert.IsTrue(rc.Successo);

                r = SmsSenderHandler.Invia(new string[] { "3288279496", "3396140489" }, m300);
                Assert.IsTrue(r.Successo);


                r = SmsSenderHandler.Invia(new string[] { "3288279496", "3396140489" }, m450);
                Assert.IsTrue(r.Successo);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [TestMethod]
        public void TestSmsSender450()
        {

            try
            {
                var r = SmsSenderHandler.Invia(new string[] { "3288279496", "3396140489" }, m450);
                Assert.IsTrue(r.Successo);
                var rc = SmsSenderHandler.GetStatoSms("cliente115042", DateTime.Now);
                Assert.IsTrue(rc.Successo);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [TestMethod]
        public void TestSmsSenderSmsInfo()
        {
            try
            {
                var r = SmsSenderHandler.GetStatoSms("cliente115042", new DateTime(2021,11,09,10,25,0));
                Assert.IsTrue(string.IsNullOrEmpty(r.CodiceErrore));
            }
            catch (Exception ex)
            {
                ;
            }
        }

        [TestMethod]
        public void TestSmsSenderCredito()
        {
            try
            {
                var r = SmsSenderHandler.GetCreditoResiduo();
                Assert.IsTrue(string.IsNullOrEmpty(r.CodiceErrore));
            }
            catch (Exception ex)
            {
                ;
            }
        }

        [TestMethod]
        public void TestSmsHosting()
        {
            try
            {
                var r = SmsHostingHandler.Invia("393288279496", m150);
                Assert.IsTrue(r.ErrorCode == 0);
                r = SmsHostingHandler.Invia("393288279496", m300);
                Assert.IsTrue(r.ErrorCode == 0);
                r = SmsHostingHandler.Invia("393288279496", m450);
                Assert.IsTrue(r.ErrorCode == 0);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [TestMethod]
        public void TestSmsHostingSmsInfo()
        {
            try
            {
                var r = SmsHostingHandler.CheckSms("1798575037");
                Assert.IsTrue(r.SmsList.Count > 0);
            }
            catch (Exception ex)
            {
                ;
            }
        }


        [TestMethod]
        public void TestSmsHostingCredit()
        {
            try
            {
                var r = SmsHostingHandler.CheckCredit("393288279496", "Messaggio corpulento inviato col progetto di test");
                Assert.IsTrue(r.ErrorCode == 0);
            }
            catch (Exception ex)
            {
                ;
            }
        }


    }
}
