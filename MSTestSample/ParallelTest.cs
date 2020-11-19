using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BrowserStack;
using System.Threading;



    
namespace MSTestSample
{
    [TestClass]
    public class ParallelTest : BrowserstackMStestConfig
    {
        [TestMethod]   
        public void parallelTest()
        {
            driver.Navigate().GoToUrl("http://google.com");
            System.Threading.Thread.Sleep(5000);
            Assert.IsTrue(driver.Title == "Google");
        }
        [TestMethod]
        public void parallelTest1()
        {
            driver.Navigate().GoToUrl("http://browserstack.com");
            System.Threading.Thread.Sleep(5000);
            Assert.IsTrue(driver.Title == "Browserstack");
        }
        [TestMethod]
        public void parallelTest2()
        {
            driver.Navigate().GoToUrl("http://google.com");
            System.Threading.Thread.Sleep(5000);
            Assert.IsTrue(driver.Title == "Google");
        }

    }
}
