using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BL;
using System.Net;
namespace BLUniteTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetIP()
        {
           IPAddress s= Common.getLocalIpAdress();
            Assert.AreEqual("192.168.131.1", s.ToString()) ; //131的网，以太网
        }

        [TestMethod]
        public void TestGetPort()
        {
            int port = Common.GetAvailablePort();
            Assert.AreEqual(8081,port);
            Assert.AreEqual(8082, port);
        }
    
    }
}
