using JupiterAutomation.BaseClass;
using JupiterAutomation.Settings;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterAutomation.PageObjects
{
    public class HomePage : PageBase
    {
        private IWebDriver _driver;
        #region WebElement

        [FindsBy(How = How.XPath, Using = "//a[@class = 'btn btn-success btn-large']")]
        private IWebElement StartShoppingBtn { get; set;}



        #endregion

        public HomePage(IWebDriver driver) : base(driver)
        {
            this._driver = driver;
        }


        #region Navigation
        public ShopPage StartShopping()
        {
            StartShoppingBtn.Click();
            return new ShopPage(_driver);
        }

        #endregion
    }
}
