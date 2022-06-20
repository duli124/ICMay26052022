using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ICMay2022.Pages
{
    public class LoginPage
    {
        public void loginActions(IWebDriver driver)
        {
            // maximize window
            driver.Manage().Window.Maximize();

            // launch turn up portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");

            try
            {
                // identify username textbox and enter valid username
                IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
                usernameTextbox.SendKeys("hari");

                // identify password textbox and enter valid password
                IWebElement passwrodTextbox = driver.FindElement(By.Id("Password"));
                passwrodTextbox.SendKeys("123123");

                // identify log in button and click
                IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
                loginButton.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("TurnUp portal page did not launch.", ex.Message);
            }

        }
    }
}
