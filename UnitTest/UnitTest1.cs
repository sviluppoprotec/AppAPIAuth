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
    }
}
