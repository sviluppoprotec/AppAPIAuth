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
            Logger.FileLogger logger = new Logger.FileLogger();
            logger.Log("test");
        }
    }
}
