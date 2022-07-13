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
    public class CartPage : PageBase
    {
        private IWebDriver _driver;

        #region WebElement
        [FindsBy(How = How.XPath, Using = "//td[contains(text(),'Funny Cow')]")]
        private IWebElement FunnyCow { get; set; }

        [FindsBy(How = How.XPath, Using = "//td[contains(text(),'Funny Cow')]/following-sibling::td[2]/input")]
        private IWebElement FunnyCowQty { get; set; }

        [FindsBy(How = How.XPath, Using = "//td[contains(text(),'Fluffy Bunny')]")]
        private IWebElement FluffyBunny { get; set; }

        [FindsBy(How = How.XPath, Using = "//td[contains(text(),'Fluffy Bunny')]/following-sibling::td[2]/input")]
        private IWebElement FluffyBunnyQty { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//td[contains(text(),'Fluffy Bunny')]/following-sibling::td[1]")]
        private IWebElement FluffyBunnySinglePrice { get; set; }

        [FindsBy(How = How.XPath, Using = "//td[contains(text(),'Fluffy Bunny')]/following-sibling::td[3]")]
        private IWebElement FluffyBunnySubTotal{ get; set; }

        [FindsBy(How = How.XPath, Using = "//td[contains(text(),'Valentine Bear')]/following-sibling::td[2]/input")]
        private IWebElement ValentineBearQty { get; set; }

        [FindsBy(How = How.XPath, Using = "//td[contains(text(),'Valentine Bear')]/following-sibling::td[1]")]
        private IWebElement ValentineBearSinglePrice { get; set; }

        [FindsBy(How = How.XPath, Using = "//td[contains(text(),'Valentine Bear')]/following-sibling::td[3]")]
        private IWebElement ValentineBearSubTotal { get; set; }

        [FindsBy(How = How.XPath, Using = "//td[contains(text(),'Stuffed Frog')]/following-sibling::td[2]/input")]
        private IWebElement StuffedFrogQty { get; set; }

        [FindsBy(How = How.XPath, Using = "//td[contains(text(),'Stuffed Frog')]/following-sibling::td[1]")]
        private IWebElement StuffedFrogSinglePrice { get; set; }

        [FindsBy(How = How.XPath, Using = "//td[contains(text(),'Stuffed Frog')]/following-sibling::td[3]")]
        private IWebElement StuffedFrogSubTotal { get; set; }

        [FindsBy(How = How.XPath, Using = "//strong[@class = 'total ng-binding']")]
        private IWebElement ChartTotalPrice { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Empty Cart']")]
        private IWebElement EmptyCartBtn { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//a[@class='btn btn-success']")]
        private IWebElement EmptySuccessBtn { get; set; }
        #endregion
        public CartPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        #region Action
        public int GetFunnyCowQty()
        {
            return int.Parse(FunnyCowQty.GetAttribute("value"));
        }

        public int GetFluffyBunnyQty()
        {
            return int.Parse(FluffyBunnyQty.GetAttribute("value"));
        }

        public int GetValentineBearQty()
        {
            return int.Parse(ValentineBearQty.GetAttribute("value"));
        }
        public int GetStuffedFrogQty()
        {
            return int.Parse(StuffedFrogQty.GetAttribute("value"));
        }

        public double GetFluffyBunnyPrice()
        {
            return double.Parse(FluffyBunnySinglePrice.Text.Trim('$'));
        }

        public double GetValentineBearPrice()
        {
            return double.Parse(ValentineBearSinglePrice.Text.Trim('$'));
        }
        public double GetStuffedFrogPrice()
        {
            return double.Parse(StuffedFrogSinglePrice.Text.Trim('$'));
        }

        public double GetFluffyBunnySubTotal()
        {
            return double.Parse(FluffyBunnySubTotal.Text.Trim('$'));
        }

        public double GetValentineBearSubTotal()
        {
            return double.Parse(ValentineBearSubTotal.Text.Trim('$'));
        }
        public double GetStuffedFrogSubTotal()
        {
            return double.Parse(StuffedFrogSubTotal.Text.Trim('$'));
        }

        public double GetTotalPrice()
        {
            return double.Parse(ChartTotalPrice.Text.Split(':')[1].Trim());
        }

        public void EmptyCart()
        {
            EmptyCartBtn.Click();
            EmptySuccessBtn.Click();
        }
        #endregion
    }
}
