using JupiterAutomation.Configration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterAutomation.Interfaces
{
    public interface IConfig
    {
        BrowserType GetBrowser();
        string GetUsername();
        string GetPassword();
        string GetWebsite();
        int GetPageLoadTime();
        int GetImplicitWaitTime();
    }
}
