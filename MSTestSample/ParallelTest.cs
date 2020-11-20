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
        [DataTestMethod]
        [DataRow("parallel", "firefox")]
        public void parallelTest(string profile, string environment)
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
        [TestMethod]
        [DataTestMethod]
        [DataRow("parallel", "chrome")]
        public void parallelTest1(string profile, string environment)
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
        [TestMethod]
        [DataTestMethod]
        [DataRow("parallel", "ie")]
        public void parallelTest2(string profile, string environment)
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
        [TestMethod]
        [DataTestMethod]
        [DataRow("parallel", "mobile")]
        public void parallelTest3(string profile, string environment)
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
