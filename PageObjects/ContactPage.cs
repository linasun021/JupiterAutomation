using JupiterAutomation.BaseClass;
using JupiterAutomation.CustomException;
using JupiterAutomation.Settings;
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
    public class ContactPage : PageBase
    {
        private IWebDriver _driver;
        #region WebElement
        [FindsBy(How = How.CssSelector, Using = "input[id = 'forename']")]
        private IWebElement ForenameTextBox { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[id = 'surname']")]
        private IWebElement SurnameTextBox { get; set; }
        [FindsBy(How = How.CssSelector, Using = "input[id = 'email']")]
        private IWebElement EmailTextBox { get; set; }
        [FindsBy(How = How.CssSelector, Using = "input[id = 'telephone']")]
        private IWebElement TelephoneTextBox { get; set; }
        [FindsBy(How = How.CssSelector, Using = "textarea[id = 'message']")]
        private IWebElement MessageTextBox { get; set; }
        [FindsBy(How = How.CssSelector, Using = "a[class='btn-contact btn btn-primary']")]
        private IWebElement SubmitBtn { get; set; }
        [FindsBy(How = How.CssSelector, Using = "span[id='forename-err']")]
        private IWebElement forenameErrorText { get; set; }
        [FindsBy(How = How.CssSelector, Using = "span[id='email-err']")]
        private IWebElement emailErrorText { get; set; }
        [FindsBy(How = How.CssSelector, Using = "span[id='message-err']")]
        private IWebElement messageErrorText { get; set; }
        #endregion

        public ContactPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        #region Action
        public void AddContact(string foreName = null, string surName = null, string email = null, string telephone = null, string message = null)
        {
            if (foreName != null)
            {
                ForenameTextBox.SendKeys(foreName);
            }
            if (surName != null)
            {
                SurnameTextBox.SendKeys(surName);
            }
            if (email != null)
            {
                EmailTextBox.SendKeys(email);
            }
            if (telephone != null)
            {
                TelephoneTextBox.SendKeys(telephone);
            }
            if (message != null)
            {
                MessageTextBox.SendKeys(message);
            }
        }

        public ContactSuccessPage SubmitContact()
        {
            SubmitBtn.Click();
            return new ContactSuccessPage(_driver);
        }

        public List<string> GetErrorMessage()
        {
            List<string> errorMegs = new List<string>();
            if (forenameErrorText != null)
            {
                errorMegs.Add(forenameErrorText.Text);
            }
            if (emailErrorText !=null)
            {
                errorMegs.Add(emailErrorText.Text);
            }
            if (messageErrorText !=null)
            {
                errorMegs.Add(messageErrorText.Text);
            }
            return errorMegs;
        }
        #endregion
    }
}

