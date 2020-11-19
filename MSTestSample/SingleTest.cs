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

namespace MSTestSample
{
    [TestClass]
    
    public class SingleTest : BrowserstackMStestConfig
    {
        public TestContext TestContext { get; set; }
        protected IWebDriver driver;


        //public SingleTest(string profile, string environment) : base(profile, environment) { }


        [TestMethod]
        [TestCategory("smoke")]
        [DataTestMethod]
        [DataRow("single","chrome")]

        public void singleTest(String profile, String environment)
        {
            IWebDriver driver = Init(profile, environment);
            //Console.WriteLine("Test");
            //string testname = (string)TestContext.Properties["TestName"];// object from regular context
            //Console.WriteLine(testname + " qwertyu");
            driver.Navigate().GoToUrl("http://google.com");
            //Console.WriteLine("++++++TEST_NAME:  " + TestContext.TestName);
            System.Threading.Thread.Sleep(5000);
            Assert.IsTrue(driver.Title == "Google");

        }


    }
}
