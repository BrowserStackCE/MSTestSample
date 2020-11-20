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
        public IConfiguration configuration { get; set; }
        String user, key, URL;

        public IWebDriver Init(string profile, string environment)
        {
         
            var builder = new ConfigurationBuilder().
            SetBasePath(Directory.GetCurrentDirectory() + "../../../../").
            AddJsonFile("appsettings.json");
            configuration = builder.Build();

            user = configuration["appSettings:user"];
            key = configuration["appSettings:key"];
            URL = configuration["appSettings:server"];

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
                    bsLocalArgs.Add(new KeyValuePair<string, string>("binarypath", "<Absolute PATH FOR BINARY>"));
                    browserStackLocal.start(bsLocalArgs);
                    Thread.Sleep(5000);
                    Console.WriteLine("Local Running: " + browserStackLocal.isRunning());
                }
            }

            capsec = configuration.GetSection("environment:" + environment).GetChildren().ToDictionary(x => x.Key, x => x.Value as string);

            foreach (KeyValuePair<string, string> kvp in capsec)
            {
                options.AddAdditionalCapability(kvp.Key, kvp.Value, true);
            }

            

            driver = new RemoteWebDriver(new Uri("http://" + user + ":" + key + "@" + URL), options.ToCapabilities());
            return driver;
        }
        [TestCleanup]
        public void Stop()
        {
            driver.Quit();
            if (browserStackLocal != null)
            {
                browserStackLocal.stop();
            }

        }
    }
}
