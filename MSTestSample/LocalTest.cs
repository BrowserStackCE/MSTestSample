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
        [TestMethod]
        [TestCategory("smoke")]
        [TestCategory("Local")]
        [TestProperty("Env","Pvt")]
        public void localTest()
        {

            driver.Navigate().GoToUrl("http://google.com");
            System.Threading.Thread.Sleep(5000);
            Assert.IsTrue(driver.Title == "Google");




        }
    }
}
