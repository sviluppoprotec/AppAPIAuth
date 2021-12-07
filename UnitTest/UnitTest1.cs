using ConsoleAppAPIAuth.Classi;
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
                var r = SMSAruba.GestioneSMS("3288279496", "", "prova");
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
    }
}
