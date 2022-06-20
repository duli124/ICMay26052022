using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICMay2022.Utilities
{
    public class WaitHelpers
    {
        // Generic functions to wait for element to be clickable
        public static void WaitToBeClikable(IWebDriver driver, string locator, string locatorValue, int second)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, second));
            
            if (locator == "Xpath")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(locatorValue)));
            }
            if (locator == "Id")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(locatorValue)));
            }
            if (locator == "CssSelector")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(locatorValue)));
            }
        }

        // Generic functions to wait for element to be clickable
        public static void WaitToBeVisible(IWebDriver driver, string locator, string locatorValue, int second)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, second));

            if (locator == "Xpath")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(locatorValue)));
            }
            if (locator == "Id")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(locatorValue)));
            }
            if (locator == "CssSelector")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(locatorValue)));
            }
        }
    }
}
