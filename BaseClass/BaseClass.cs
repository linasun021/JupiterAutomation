using JupiterAutomation.ComponentHelper;
using JupiterAutomation.Configration;
using JupiterAutomation.CustomException;
using JupiterAutomation.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterAutomation.BaseClass
{
    [TestClass]
    public class BaseClass
    {
        private static IWebDriver GetChomeDriver()
        {
            IWebDriver driver = new ChromeDriver();
            return driver;
        }

        private static IWebDriver GetFireFoxDriver()
        {
            IWebDriver driver = new FirefoxDriver();
            return driver;
        }

        [AssemblyInitialize]
        public static void InitWebDriver(TestContext tc)
        {

            ObjectRepository.Config = new AppConfigReader();
            switch (ObjectRepository.Config.GetBrowser())
            {
                case BrowserType.Chrome:
                    ObjectRepository.WebDriver = GetChomeDriver();
                    break;
                case BrowserType.Firefox:
                    ObjectRepository.WebDriver = GetFireFoxDriver();
                    break;
                default:
                    throw new NoSuitableDriverFound(String.Format("Driver Not Found : {0}", ObjectRepository.Config.GetBrowser().ToString()));
                    
            }
            ObjectRepository.WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(ObjectRepository.Config.GetPageLoadTime());
            ObjectRepository.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ObjectRepository.Config.GetImplicitWaitTime());
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
        }

        [AssemblyCleanup]
        public static void TearDown()
        {
            if (ObjectRepository.WebDriver != null)
            {
                ObjectRepository.WebDriver.Close();
                ObjectRepository.WebDriver.Quit();
            }
        }
    }
}
