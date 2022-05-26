using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Assignment2DuliSelenium
{
    [TestClass]
    public class AutomationPractice
    {
        public IWebDriver driver;
        public WebDriverWait wait;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://automationpractice.com");

        }

        [TestMethod]
        public void ValidatesAvailablityOfLinks()
        {
            IReadOnlyList<IWebElement> links = driver.FindElements(By.TagName("a"));
            int validLinksCount = 0;

            foreach (var url in links)
            {
                if (url.GetAttribute("href").Contains("http:") || url.GetAttribute("href").Contains("https:"))
                {
                    validLinksCount++;
                }
                else
                {
                    Console.WriteLine($"Invalid link: {url.GetAttribute("href")}");
                }
            }

            Assert.IsTrue(validLinksCount > 0);
            Console.WriteLine($"Number of valid link: {validLinksCount}");
        }

        [TestMethod]
        public void CorrectnessOfPurchaseThreeItems()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(300));

            // Select 1st item and Click Add
            driver.FindElement(By.XPath("//*[@id='homefeatured']/li[1]/div/div[2]/div[2]/a[1]/span")).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='homefeatured']/li[1]/div/div[2]/div[2]/a[1]/span")));

            //Continue shopping
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='layer_cart']/div[1]/div[2]/div[4]/span")));
            driver.FindElement(By.XPath("//*[@id='layer_cart']/div[1]/div[2]/div[4]/span")).Click();

            // Select 2nd item and Click Add
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='homefeatured']/li[2]/div/div[2]/div[2]/a[1]/span")));
            driver.FindElement(By.XPath("//*[@id='homefeatured']/li[2]/div/div[2]/div[2]/a[1]/span")).Click();

            //Continue shopping
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='layer_cart']/div[1]/div[2]/div[4]/span")));
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id='layer_cart']/div[1]/div[2]/div[4]/span")).Click();

            // Select 3rd item and Click Add
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='homefeatured']/li[3]/div/div[2]/div[2]/a[1]/span")));
            driver.FindElement(By.XPath("//*[@id='homefeatured']/li[3]/div/div[2]/div[2]/a[1]/span")).Click();

            // Proceed to checkout
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='layer_cart']/div[1]/div[2]/div[4]/a/span")));
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id='layer_cart']/div[1]/div[2]/div[4]/a/span")).Click();

            // find calculation result text
            var resultText = driver.FindElement(By.XPath("//*[@id='total_price']"));
            Thread.Sleep(3000);

            // write result text to string
            double result = double.Parse(resultText.Text.Replace("$", ""));

            //get the price of the first item
            var firstItemPrice = driver.FindElement(By.XPath("//*[@id='product_price_1_1_0']/span"));
            string firstItemPrice21 = firstItemPrice.Text.Replace("$", "");

            //get the price of the second item
            var secondItemPrice1 = driver.FindElement(By.XPath("//*[@id='product_price_2_7_0']/span"));
            string secondItemPrice21 = secondItemPrice1.Text.Replace("$", "");

            // get the price of the third item
            var thirdItemPrice = driver.FindElement(By.XPath("//*[@id='product_price_3_13_0']/span"));
            string thirdItemPrice1 = thirdItemPrice.Text.Replace("$", "");

            // get the price of the shipping cost
            var shippingCost = driver.FindElement(By.XPath("//*[@id='total_shipping']"));
            string shippingCost1 = shippingCost.Text.Replace("$", "");

            double expectedtotal = double.Parse(firstItemPrice21) + double.Parse(secondItemPrice21) +
                double.Parse(thirdItemPrice1) + double.Parse(shippingCost1);

            Assert.AreEqual(result, expectedtotal);
        }

        [TestMethod]
        public void CorrectnessOfPurchaseThreeAndRmoveTwo()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(160));

            // Select 1st item and Click Add
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='homefeatured']/li[1]/div/div[2]/div[2]/a[1]/span")));
            driver.FindElement(By.XPath("//*[@id='homefeatured']/li[1]/div/div[2]/div[2]/a[1]/span")).Click();

            //Continue shopping
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='layer_cart']/div[1]/div[2]/div[4]/span")));
            driver.FindElement(By.XPath("//*[@id='layer_cart']/div[1]/div[2]/div[4]/span")).Click();

            // Select 2nd item and Click Add
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='homefeatured']/li[2]/div/div[2]/div[2]/a[1]/span")));
            driver.FindElement(By.XPath("//*[@id='homefeatured']/li[2]/div/div[2]/div[2]/a[1]/span")).Click();

            //Continue shopping
            Thread.Sleep(4000);
            driver.FindElement(By.XPath("//*[@id='layer_cart']/div[1]/div[2]/div[4]/span")).Click();

            // Select 3rd item and Click Add
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='homefeatured']/li[3]/div/div[2]/div[2]/a[1]/span")));
            driver.FindElement(By.XPath("//*[@id='homefeatured']/li[3]/div/div[2]/div[2]/a[1]/span")).Click();

            // Proceed to checkout
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id='layer_cart']/div[1]/div[2]/div[4]/a/span")).Click();

            //get the price of the first item
            var firstItemPrice = driver.FindElement(By.XPath("//*[@id='product_price_1_1_0']/span"));
            string firstItemPrice21 = firstItemPrice.Text.Replace("$", "");

            //get the price of the second item
            var secondItemPrice1 = driver.FindElement(By.XPath("//*[@id='product_price_2_7_0']/span"));
            string secondItemPrice21 = secondItemPrice1.Text.Replace("$", "");

            // get the price of the third item
            var thirdItemPrice = driver.FindElement(By.XPath("//*[@id='product_price_3_13_0']/span"));
            string thirdItemPrice1 = thirdItemPrice.Text.Replace("$", "");

            // get the price of the shipping cost
            var shippingCost = driver.FindElement(By.XPath("//*[@id='total_shipping']"));
            string shippingCost1 = shippingCost.Text.Replace("$", "");

            double total = double.Parse(firstItemPrice21) + double.Parse(secondItemPrice21) +
                double.Parse(thirdItemPrice1) + double.Parse(shippingCost1);

            // Delete first Item
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='1_1_0_0']/i")));
            driver.FindElement(By.XPath("//*[@id='1_1_0_0']/i")).Click();

            // Delete Second Item
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='2_7_0_0']/i")));
            driver.FindElement(By.XPath("//*[@id='2_7_0_0']/i")).Click();

            //Expected total after deletions of two items
            double exptotalAftDeletion = total - double.Parse(firstItemPrice21) - double.Parse(secondItemPrice21);

            // find Total result text
            Thread.Sleep(3000);
            var resultText = driver.FindElement(By.XPath("//*[@id='total_price']"));

            // write result text to string
            double actual = double.Parse(resultText.Text.Replace("$", ""));

            Assert.AreEqual(actual, exptotalAftDeletion);
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
