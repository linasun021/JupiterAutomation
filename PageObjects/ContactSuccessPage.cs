using JupiterAutomation.BaseClass;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterAutomation.PageObjects
{
    public class ContactSuccessPage : PageBase
    {
        private IWebDriver _driver;

        #region WebElement
        [FindsBy(How=How.CssSelector,Using = "div[class='alert alert-success']")]
        private IWebElement AlterSuccessText { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='« Back']")]
        private IWebElement BackBtn { get; set; }
        #endregion
        public ContactSuccessPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        #region Action
        public string GetAlterSuccessText()
        {
            //Add Dynamic wait for contact success page showing
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            wait.Until(waitSuccessPage());
            return AlterSuccessText.Text;
        }

        private Func<IWebDriver, bool> waitSuccessPage()
        {
            return ((x) =>
            {
                return (AlterSuccessText.Text.Contains("we appreciate your feedback."));
            });
        }

        #endregion

        #region Navigation
        public ContactPage BackToContactPage()
        {
            BackBtn.Click();
            return new ContactPage(_driver);
        }
        #endregion

    }
}
