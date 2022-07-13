using JupiterAutomation.BaseClass;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterAutomation.PageObjects
{
    public class ShopPage : PageBase
    {
        private IWebDriver _driver;

        #region WebElement
        [FindsBy(How = How.XPath,Using = "//h4[text()='Teddy Bear']/following-sibling::p/descendant::a[text()='Buy']")]
        private IWebElement TeddyBearBuyBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//h4[text()='Stuffed Frog']/following-sibling::p/descendant::a[text()='Buy']")]
        private IWebElement StuffedFrogBuyBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//h4[text()='Handmade Doll']/following-sibling::p/descendant::a[text()='Buy']")]
        private IWebElement HandmadeDollBuyBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//h4[text()='Fluffy Bunny']/following-sibling::p/descendant::a[text()='Buy']")]
        private IWebElement FluffyBunnyBuyBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//h4[text()='Smiley Bear']/following-sibling::p/descendant::a[text()='Buy']")]
        private IWebElement SmileyBearBuyBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//h4[text()='Funny Cow']/following-sibling::p/descendant::a[text()='Buy']")]
        private IWebElement FunnyCowBuyBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//h4[text()='Valentine Bear']/following-sibling::p/descendant::a[text()='Buy']")]
        private IWebElement ValentineBearBuyBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//h4[text()='Smiley Face']/following-sibling::p/descendant::a[text()='Buy']")]
        private IWebElement SmileyFaceBuyBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//h4[text()='Teddy Bear']/following-sibling::p/descendant::span]")]
        private IWebElement TeddyBearPrice { get; set; }

        [FindsBy(How = How.XPath, Using = "//h4[text()='Stuffed Frog']/following-sibling::p/descendant::span]")]
        private IWebElement StuffedFrogPrice { get; set; }

        [FindsBy(How = How.XPath, Using = "//h4[text()='Handmade Doll']/following-sibling::p/descendant::span]")]
        private IWebElement HandmadeDollPrice { get; set; }

        [FindsBy(How = How.XPath, Using = "//h4[text()='Fluffy Bunny']/following-sibling::p/descendant::span]")]
        private IWebElement FluffyBunnyPrice { get; set; }

        [FindsBy(How = How.XPath, Using = "//h4[text()='Smiley Bear']/following-sibling::p/descendant::span]")]
        private IWebElement SmileyBearPrice { get; set; }

        [FindsBy(How = How.XPath, Using = "//h4[text()='Funny Cow']/following-sibling::p/descendant::span]")]
        private IWebElement FunnyCowBuyPrice { get; set; }

        [FindsBy(How = How.XPath, Using = "//h4[text()='Valentine Bear']/following-sibling::p/descendant::span]")]
        private IWebElement ValentineBearPrice { get; set; }

        [FindsBy(How = How.XPath, Using = "//h4[text()='Smiley Face']/following-sibling::p/descendant::span]")]
        private IWebElement SmileyFaceBuyPrice { get; set; }
        #endregion

        public ShopPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        #region Action
        public void BuyFunnyCow()
        {
            FunnyCowBuyBtn.Click();
        }

        public void BuyFluffyBunny()
        {
            FluffyBunnyBuyBtn.Click();
        }

        public void BuySmileyBear()
        {
            SmileyBearBuyBtn.Click();
        }

        public void BuySmileyFace()
        {
            SmileyFaceBuyBtn.Click();
        }

        public void BuyTeddyBear()
        {
            TeddyBearBuyBtn.Click();
        }

        public void BuyStuffedFrog()
        {
            StuffedFrogBuyBtn.Click();
        }

        public void BuyHandmadeDoll()
        {
            HandmadeDollBuyBtn.Click();
        }

        public void BuyValentineBear()
        {
            ValentineBearBuyBtn.Click();
        }
        #endregion
    }
}
