using JupiterAutomation.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterAutomation.ComponentHelper
{
    public class NavigationHelper
    {
        public static void NavigateToUrl(string url)
        {
            ObjectRepository.WebDriver.Navigate().GoToUrl(url);
        }
    }
}
