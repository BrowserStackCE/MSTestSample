using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BrowserStack;
using System.Threading;



//[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.MethodLevel)] //0 means use as many workers as possible

namespace MSTestSample
{
    [TestClass]
    public class LocalTest : BrowserstackMStestConfig
    {
        //public LocalTest(string profile, string environment) : base(profile, environment) { }


        [TestMethod]
        [DataTestMethod]
        [DataRow("local", "chrome")]
        public void localTest(string profile, string environment)
        {
            IWebDriver driver = Init(profile, environment);
            driver.Navigate().GoToUrl("localhost:8000");
            System.Threading.Thread.Sleep(5000);
            Assert.IsTrue(driver.Title == "Local Server");




        }
    }
}
