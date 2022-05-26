using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace ICMay2022
{
    class Program
    {
        static IWebDriver driver;
        static void Main(string[] args)
        {
            //Launch the browser
            driver = new ChromeDriver();

            //Enter the url
            driver.Navigate().GoToUrl(" http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");

            // maximize the window
            driver.Manage().Window.Maximize();
            
            login();
            createTimeAndMaterialRecord();
        }
        public static void login()
        {
            //Find the username element
            IWebElement username = driver.FindElement(By.Id("UserName"));
            //enter the user name
            username.SendKeys("hari");
            // find the password element
            IWebElement password = driver.FindElement(By.Id("Password"));
            // enter the password
            password.SendKeys("123123");
            // find the loginButton element
            IWebElement loginBtn = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
            // click the button
            loginBtn.Click();
            //welcome lable
            IWebElement hariText = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));

            if (hariText.Text == "Hello hari!")
            {
                Console.WriteLine("Login successfully, Test pass");
            }
            else 
            {
                Console.WriteLine("Login, Test pass, Test fail");
            }
        }
        public static void createTimeAndMaterialRecord()
        {
         
            // find the Administartion tab
            IWebElement adminTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            // click on Administartion tab
            adminTab.Click();
            // finf Time & Materials from the drop down
            IWebElement timeAndMaterial = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            // click on Time and Material
            timeAndMaterial.Click();
            // find the create New button
            IWebElement createNewBtn = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            // click on crreate new button
            createNewBtn.Click();
            //find Type Code element and click
            IWebElement typeCode = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]"));
            typeCode.Click();
            // find material from the drop down
            //IWebElement material = driver.FindElement(By.XPath("//*[@id='TypeCode_option_selected']"));
            //material.Click();
            // find code element and enter the code
            IWebElement code = driver.FindElement(By.Id("Code"));
            code.SendKeys("DT001");
            // find Description element and enter the Description
            IWebElement description = driver.FindElement(By.Id("Description"));
            description.SendKeys("Stainless steel 1m bar");
            // find Price element and enter the price
            IWebElement price = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            price.SendKeys("150.00");
            // Find Save button element and click
            IWebElement save = driver.FindElement(By.Id("SaveButton"));
            save.Click();
            System.Threading.Thread.Sleep(2000);
            // scroll the web page down
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,200)");

            //go to the last page of the table
            IWebElement lastPgeArrow = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            lastPgeArrow.Click();

            IWebElement codeName = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[8]/td[1]"));
            if (codeName.Text == "DT001")
            {
                Console.WriteLine($"Hello, {codeName.Text} is equal to DT001.");
            }
            else
            {
                Console.WriteLine($"Hello, {codeName.Text} is not equal to DT001.");
                //*[@id="tmsGrid"]/div[3]/table/tbody/tr
            }

        }
    }
}