using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using BrowserStack;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MSTestSample
{
    public class BrowserstackMStestConfig
    {

        IWebDriver driver;
        Local browserStackLocal;
        //public BrowserStackXunitConfig() { }
        public IConfiguration configuration { get; set; }


        //public BrowserstackMStestConfig(string profile, string environment)
        //{
        //    this.profile = profile;
        //    this.environment = environment;
        //}

        //[TestInitialize]
        public IWebDriver Init(string profile, string environment)
        {
            Console.WriteLine("Profile: " + profile + " Environ: " + environment);

            Console.WriteLine("Username :" +Environment.GetEnvironmentVariable("BROWSERSTACK_USERNAME"));
            //ChromeOptions options = new ChromeOptions();
            //options.AddAdditionalCapability("os", "Windows",true);
            //options.AddAdditionalCapability("os_version", "10", true);
            //options.AddAdditionalCapability("browser", "chrome", true);
            //options.AddAdditionalCapability("browser_version", "latest", true);
            //options.AddAdditionalCapability("browserstack.local", "false", true);
            //options.AddAdditionalCapability("browserstack.selenium_version", "3.5.2",true);
            //options.AddAdditionalCapability("build", "MSTestV2 Build 1", true);
            //options.AddAdditionalCapability("name", "Single Test", true);

            var builder = new ConfigurationBuilder().
            SetBasePath(Directory.GetCurrentDirectory() + "../../../../").
            AddJsonFile("appsettings.json");
            configuration = builder.Build();

            Dictionary<string, string> capsec = new Dictionary<string, string>();

            var caps = configuration["appSettings:environment"];

            capsec = configuration.GetSection("profile:" + profile).GetChildren().ToDictionary(x => x.Key, x => x.Value as string);
            ChromeOptions options = new ChromeOptions();


            foreach (KeyValuePair<string, string> kvp in capsec)
            {

                options.AddAdditionalCapability(kvp.Key, kvp.Value, true);
                if (kvp.Key == "browserstack.local" && kvp.Value == "true")
                {
                    browserStackLocal = new Local();
                    List<KeyValuePair<string, string>> bsLocalArgs = new List<KeyValuePair<string, string>>() {
                        new KeyValuePair<string, string>("key", configuration["appSettings:key"])};
                    bsLocalArgs.Add(new KeyValuePair<string, string>("onlyAutomate", "true"));
                    bsLocalArgs.Add(new KeyValuePair<string, string>("binarypath", "/Users/rathilpatel/Downloads/BrowserStackLocal"));
                    browserStackLocal.start(bsLocalArgs);
                    Thread.Sleep(5000);
                    Console.WriteLine("Local Running: " + browserStackLocal.isRunning());
                }
                Console.WriteLine("{0},{1}", kvp.Key, kvp.Value);
            }

            capsec = configuration.GetSection("environment:" + environment).GetChildren().ToDictionary(x => x.Key, x => x.Value as string);


            foreach (KeyValuePair<string, string> kvp in capsec)
            {

                options.AddAdditionalCapability(kvp.Key, kvp.Value, true);
                Console.WriteLine("{0},{1}", kvp.Key, kvp.Value);
            }


            string user = configuration["appSettings.user"];
            string key = configuration["appSettings.key"];
            Console.WriteLine("user: " + user + "  Key: " + key);

            driver = new RemoteWebDriver(new Uri("http://USERNAME:ACCESS_KEY@hub-cloud.browserstack.com/wd/hub/"), options.ToCapabilities());
            return driver;
        }
        [TestCleanup]
        public void Stop()
        {
            driver.Quit();
        }
    }
}
