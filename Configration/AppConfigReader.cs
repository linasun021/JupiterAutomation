using JupiterAutomation.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterAutomation.Configration
{
    public class AppConfigReader : IConfig
    {
        public BrowserType GetBrowser()
        {
            string browser = ConfigurationManager.AppSettings.Get(AppConfigKeys.BrowserType);
            return (BrowserType)Enum.Parse(typeof(BrowserType), browser);

        }

        public string GetPassword()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.Password);
        }

        public string GetUsername()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.Username);
        }

        public string GetWebsite()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.Website);
        }

        public int GetPageLoadTime()
        {
            return int.Parse(ConfigurationManager.AppSettings.Get(AppConfigKeys.PageLoadTime));
        }

        public int GetImplicitWaitTime()
        {
            return int.Parse(ConfigurationManager.AppSettings.Get(AppConfigKeys.ImplicitWaitTime));
        }
    }
}
