using ICMay2022.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICMay2022.Utilities
{
    public class CommonDriver
    {
        public IWebDriver driver;
        LoginPage loginPageObj = new LoginPage();

        [OneTimeSetUp]
        public void LoginActions()
        {
            driver = new ChromeDriver();
            // Login page object initialisation and definition

            loginPageObj.loginActions(driver);    
        }
        [OneTimeTearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}
