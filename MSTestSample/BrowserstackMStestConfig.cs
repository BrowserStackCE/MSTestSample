using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace MSTestSample
{
    public class BrowserstackMStestConfig
    {

        protected IWebDriver driver;

        [TestInitialize]
        public void  Init()
        {
            Console.WriteLine("Username :" +Environment.GetEnvironmentVariable("BROWSERSTACK_USERNAME")); 
            ChromeOptions options = new ChromeOptions();
            options.AddAdditionalCapability("os", "Windows",true);
            options.AddAdditionalCapability("os_version", "10", true);
            options.AddAdditionalCapability("browser", "chrome", true);
            options.AddAdditionalCapability("browser_version", "latest", true);
            options.AddAdditionalCapability("browserstack.local", "false", true);
            options.AddAdditionalCapability("browserstack.selenium_version", "3.5.2",true);
            options.AddAdditionalCapability("build", "MSTestV2 Build 1", true);
            options.AddAdditionalCapability("name", "Single Test", true);
            driver = new RemoteWebDriver(new Uri("http://USERNAME:ACCESS_KEY@hub-cloud.browserstack.com/wd/hub/"), options.ToCapabilities());
        }
        [TestCleanup]
        public void Stop()
        {
            driver.Quit();
        }
    }
}
