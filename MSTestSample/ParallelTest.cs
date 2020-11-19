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
        //public ParallelTest(string profile, string environment) : base(profile, environment) { }

        [TestMethod]
        [DataTestMethod]
        [DataRow("parallel", "firefox")]
        public void parallelTest(string profile, string environment)
        {
            IWebDriver driver = Init(profile, environment);
            driver.Navigate().GoToUrl("http://google.com");
            System.Threading.Thread.Sleep(5000);
            Assert.IsTrue(driver.Title == "Google");
        }
        [TestMethod]
        [DataTestMethod]
        [DataRow("parallel", "chrome")]
        public void parallelTest1(string profile, string environment)
        {
            IWebDriver driver = Init(profile, environment);
            driver.Navigate().GoToUrl("http://google.com");
            System.Threading.Thread.Sleep(5000);
            Assert.IsTrue(driver.Title == "Google");
        }
        [TestMethod]
        [DataTestMethod]
        [DataRow("parallel", "safari")]
        public void parallelTest2(string profile, string environment)
        {
            IWebDriver driver = Init(profile, environment);
            driver.Navigate().GoToUrl("http://google.com");
            System.Threading.Thread.Sleep(5000);
            Assert.IsTrue(driver.Title == "Google");
        }

    }
}
