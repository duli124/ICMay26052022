using ICMay2022.Pages;
using ICMay2022.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ICMay2022
{
    [TestFixture]
    [Parallelizable]
    public class TM_Test: CommonDriver
    {
        
        HomePage homepageObj = new HomePage();
        TMPage tmPageObject = new TMPage();

        // Home page object initialisation and definition

        

        [Test, Order(1), Description("Create Time and material record")]
        public void CreatTM()
        {
            // TM page object initialisation and definition
            TMPage tmPageObject = new TMPage();
            // create a new record
            tmPageObject.createNewTMRecord(driver);
        }

        [Test, Order(2)]
        public void EditTM()
        {
            // edit a record
            tmPageObject.EditTM(driver,"s","t","r");
        }

        [Test, Order(3)]
        public void DeleteTM()
        {          
            // delete a record
            tmPageObject.DeleteTM(driver);
        }

        
    }
}








