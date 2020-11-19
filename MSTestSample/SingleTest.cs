using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium;
using BrowserStack;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AppLogger;

namespace MSTestSample
{
    [TestClass]
    public class SingleTest : BrowserstackMStestConfig
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [TestCategory("smoke")]

        public void singleTestname()
        {
            driver.Navigate().GoToUrl("http://google.com");
            Console.WriteLine("++++++TEST_NAME:  " + TestContext.TestName);
            System.Threading.Thread.Sleep(5000);
            Assert.IsTrue(driver.Title == "Google");

        }

              
    }
}
