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
            FileLogger logger = new FileLogger();
            logger.Log("test");
        }
    }
}
