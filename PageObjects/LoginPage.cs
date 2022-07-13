using JupiterAutomation.BaseClass;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterAutomation.PageObjects
{
    public class LoginPage : PageBase
    {
        private IWebDriver _driver;
        //Need to implement all web elements 
        public LoginPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }
    }
}
