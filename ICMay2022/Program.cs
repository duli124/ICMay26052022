using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
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
            updateRecord();
            deleteTheRecord();
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
            code.SendKeys("CMT");
            // find Description element and enter the Description
            IWebElement description = driver.FindElement(By.Id("Description"));
            description.SendKeys("Cement");
            // find Price element and enter the price
            IWebElement price = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            price.SendKeys("150.00");
            // Find Save button element and click
            IWebElement save = driver.FindElement(By.XPath("//*[@id='SaveButton']"));
            save.Click();
            Thread.Sleep(2000);
            // scroll the web page down
            //IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            //js.ExecuteScript("window.scrollBy(0,200)");
            // click on go to last page button
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(2000);

            // check if material record has been created
            IWebElement newCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (newCode.Text == "CMT")
            {
                Console.WriteLine("New material record created successfully.");
            }
            else
            {
                Console.WriteLine("Material record hasn't been created.");
            }

        }

        public static void updateRecord()
        {
            // click edit button
            IWebElement editBtntbtn = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editBtntbtn.Click();

            //Change the code
            IWebElement code = driver.FindElement(By.Id("Code"));
            code.Clear();
            code.SendKeys("CMT001");

            // change the Description
            IWebElement description = driver.FindElement(By.Id("Description"));
            description.Clear();
            description.SendKeys("Cement new");

            // find Price element and enter the price
            IWebElement price2 = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            price2.SendKeys("5");
            //*[@id="TimeMaterialEditForm"]/div/div[4]/div/span[1]/span

            // Find Save button element and click
            IWebElement save = driver.FindElement(By.XPath("//*[@id='SaveButton']"));
            save.Click();
            Thread.Sleep(2000);
            //Goto the last page
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(2000);

            // check if material record has been created
            IWebElement newCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (newCode.Text == "CMT001")
            {
                Console.WriteLine("Edit the record");
            }
            else
            {
                Console.WriteLine("Not edit the record.");
            }


        }
        public static void deleteTheRecord()
        {
            //Goto the last page
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            // get the item count before delete
            IWebElement noOfItems = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/span[2]"));
            string text = noOfItems.Text;
            string[] textSplit = text.Split(" ");
            Console.Write("Number of items before delete the record: " + textSplit[4] + "  ");
            // click the delete button
            Thread.Sleep(1000);
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();
            Thread.Sleep(1000);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(1000);

            // get the item count before delete
            IWebElement noOfItems2 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/span[2]"));
            string text2 = noOfItems2.Text;
            string[] textSplit2 = text2.Split(" ");
            Console.Write("Number of items after delete the record: " + textSplit2[4]);


        }

    }
}