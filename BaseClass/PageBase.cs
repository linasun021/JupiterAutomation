using JupiterAutomation.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support;
using SeleniumExtras.PageObjects;

namespace JupiterAutomation.BaseClass
{
    public class PageBase
    {
        private IWebDriver _driver;

        [FindsBy(How = How.LinkText, Using = "Home")]
        private IWebElement HomeLink { get; set; }


        [FindsBy(How = How.PartialLinkText, Using = "Cart")]
        private IWebElement CartLink { get; set; }


        [FindsBy(How = How.LinkText, Using = "Shop")]
        private IWebElement ShopLink { get; set; }


        [FindsBy(How = How.LinkText, Using = "Contact")]
        private IWebElement ContactLink { get; set; }


        [FindsBy(How = How.LinkText, Using = "Login")]
        private IWebElement LoginLink { get; set; }

        public PageBase(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            _driver = driver;
        }
        public HomePage NavigateToHome()
        {
            HomeLink.Click();
            return new HomePage(_driver);
        }
        public ShopPage NavigateToShop()
        {
            ShopLink.Click();
            return new ShopPage(_driver);
        }

        public ContactPage NavigateToContact()
        {
            ContactLink.Click();
            return new ContactPage(_driver);

        }

        public LoginPage NavigateToLogin()
        {
            LoginLink.Click();
            return new LoginPage(_driver);

        }

        public CartPage NavigateToCart()
        {
            CartLink.Click();
            return new CartPage(_driver);
        }
    }
}
