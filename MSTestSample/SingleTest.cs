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




        [TestMethod]
        [TestCategory("smoke")]
        [DataTestMethod]
        [DataRow("single","chrome")]

        public void singleTest(String profile, String environment)
        {
            IWebDriver driver = Init(profile, environment);
            driver.Navigate().GoToUrl("http://www.google.com");
            IWebElement query = driver.FindElement(By.Name("q"));
            query.SendKeys("BrowserStack");
            query.Submit();
            Console.WriteLine(driver.Title);

            // Setting the status of test as 'passed' or 'failed' based on the condition; if title of the web page matches 'BrowserStack - Google Search'
            string str = "BrowserStack - Google Search";
            if (string.Equals(driver.Title, str))
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"passed\", \"reason\": \" Title matched!\"}}");
            }
            else
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" Title not matched \"}}");
            }

        }


    }
}
