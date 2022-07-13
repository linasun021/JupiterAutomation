using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using JupiterAutomation.ComponentHelper;
using JupiterAutomation.Settings;
using JupiterAutomation.PageObjects;
using JupiterAutomation.CustomException;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace JupiterAutomation
{
    [TestClass]
    public class SmokeTests
    {
        private HomePage homepage;

        [TestInitialize]
        public void InitTest()
        {
            homepage = new HomePage(ObjectRepository.WebDriver);
        }
        [TestMethod]
        public void TestContactReqiredFiledsAbsentError()
        {
            //1.From the home page go to contact page
            ContactPage contactPage = homepage.NavigateToContact();
            //2.Click submit button
            contactPage.SubmitContact();
            //3.Validate errors
            List<string> errorMsgs = contactPage.GetErrorMessage();
            if (errorMsgs.Count >= 1)
            {
                Assert.AreEqual("Forename is required", errorMsgs[0]);
                Assert.AreEqual("Email is required", errorMsgs[1]);
                Assert.AreEqual("Message is required", errorMsgs[2]);
            }
            //4.Populate mandatory fields
            contactPage.AddContact(foreName: "test1", email: "test1@gmail.com", message: "this is test message");
            //5.Validate errors are gone
            Assert.ThrowsException<NoSuchElementException>(() => contactPage.GetErrorMessage());
        }

        [TestMethod]
        public void TestContactSubmission()
        {
            //Note: Run this test 5 times to ensure 100% pass rate
            //We can using scenario outline in BDD mode to implement run same scenario mutiple times with different data,hard code here temporarily
            for (int i = 0; i < 5; i++)
            {
                //1.From the home page go to contact page
                ContactPage contactPage = homepage.NavigateToContact();
                //2.Populate mandatory fields
                contactPage.AddContact(foreName: "test1", email: "test1@gmail.com", message: "this is test message");
                //3.Click submit button
                ContactSuccessPage successPage = contactPage.SubmitContact();
                //4.Validate successful submission message
                Assert.AreEqual(String.Format("Thanks test1, we appreciate your feedback."), successPage.GetAlterSuccessText());
                successPage.NavigateToHome();
            }
        }

        [TestMethod]
        public void TestPutItemsToCart()
        {
            //1.From the home page go to shop page
            ShopPage shopPage = homepage.StartShopping();
            //2.Click buy button 2 times on “Funny Cow”
            for (int i = 0; i < 2; i++)
            {
                shopPage.BuyFunnyCow();
            }
            //3.Click buy button 1 time on “Fluffy Bunny”
            shopPage.BuyFluffyBunny();
            //4.Click the cart menu
            CartPage cartPage = shopPage.NavigateToCart();
            //5.Verify the items are in the cart
            Assert.AreEqual(2, cartPage.GetFunnyCowQty());
            Assert.AreEqual(1, cartPage.GetFluffyBunnyQty());

            //Empty Cart in case impact other test
            cartPage.EmptyCart();
        }
        [TestMethod]
        public void TestPriceInCart()
        {
            ShopPage shopPage = homepage.StartShopping();
            //1.Buy 2 Stuffed Frog, 5 Fluffy Bunny, 3 Valentine Bear
            for (int i = 0; i < 2; i++)
            {
                shopPage.BuyStuffedFrog();
            }
            for (int i = 0; i < 5; i++)
            {
                shopPage.BuyFluffyBunny();
            }
            for (int i = 0; i < 3; i++)
            {
                shopPage.BuyValentineBear();
            }
            //2.Go to the cart page
            CartPage cartPage = shopPage.NavigateToCart();

            //3.Verify the price for each product
            Assert.AreEqual(10.99, cartPage.GetStuffedFrogPrice());
            Assert.AreEqual(9.99, cartPage.GetFluffyBunnyPrice());
            Assert.AreEqual(14.99, cartPage.GetValentineBearPrice());

            //4.Verify that each product’s sub total = product price * quantity
            Assert.AreEqual(10.99 * 2, cartPage.GetStuffedFrogSubTotal());
            Assert.AreEqual(9.99 * 5, cartPage.GetFluffyBunnySubTotal());
            Assert.AreEqual(14.99 * 3, cartPage.GetValentineBearSubTotal());

            //5.Verify that total = sum(sub totals)
            Assert.AreEqual(10.99 * 2 + 9.99 * 5 + 14.99 * 3, cartPage.GetTotalPrice());
            //Empty Cart in case impact other test
            cartPage.EmptyCart();
        }

        [TestCleanup]
        public void CleanTest()
        {
            if (homepage != null)
            {
                homepage.NavigateToHome();
            }
        }
    }
    
}
