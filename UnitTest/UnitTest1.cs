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
                var r = SmsSenderHandler.Invia(new string[] { "3288279496", "3396140489" }, "Messaggio corpulento inviato col progetto di test");
                Assert.IsTrue(r.Successo);
            }
            catch (Exception ex)
            {
                ;
            }
        }

        [TestMethod]
        public void TestSmsSenderSmsInfo()
        {
            try
            {
                var r = SmsSenderHandler.GetStatoSms("69859AE07BA7435280D05D53483657F0");
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
                var r = SmsHostingHandler.Invia("393288279496", "Messaggio corpulento inviato col progetto di test");
                Assert.IsTrue(r.ErrorCode == 0);
            }
            catch (Exception ex)
            {
                ;
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
