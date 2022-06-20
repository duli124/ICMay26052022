using ICMay2022.Pages;
using ICMay2022.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace ICMay2022.StepDefinitions
{
    [Binding]
    public class TMFeatureSteps : CommonDriver

    {
        [Given(@"I logged into TurnUp portal succesfully")]
        public void GivenILoggedIntoTurnUpPortalSuccesfully()
        {
            driver = new ChromeDriver();
            // Login page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.loginActions(driver);
        }

        [When(@"I navigate to time and material page")]
        public void WhenINavigateToTimeAndMaterialPage()
        {
            HomePage homepageObj = new HomePage();
            homepageObj.GoToTMPage(driver);
        }

        [When(@"I create a time and material record")]
        public void WhenICreateATimeAndMaterialRecord()
        {
            TMPage tmPageObj = new TMPage();
            tmPageObj.createNewTMRecord(driver);
        }

        [Then(@"the record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully()
        {
            TMPage tmPageObj = new TMPage();
            string newcode = tmPageObj.GetNewCode(driver);
            string typeCode = tmPageObj.GetNewTypeCode(driver);
            string description = tmPageObj.GetNewDescription(driver);
            string price = tmPageObj.GetNewPrice(driver);
            //Example 2
            Assert.That(newcode == "DT100", "Actual code and expected code do not match.");
            Assert.That(typeCode == "M", "Actual type code and expected type code do not match.");
            Assert.That(description == "DT100", "Actual description and expected description do not match.");
            Assert.That(price == "$120.00", "Actual price and expected price do not match.");
        }

        [When(@"I update '(.*)', '(.*)','(.*)' on an existing time and material record")]
        public void WhenIUpdateOnAnExistingTimeAndMaterialRecord(string p0, string p1, string p2)
        {
            TMPage tmPageObj = new TMPage();
            tmPageObj.EditTM(driver, p0, p1, p2);
        }

        [Then(@"the record should have the updated '(.*)', '(.*)','(.*)'")]
        public void ThenTheRecordShouldHaveTheUpdated(string p0, string p1, string p2)
        {
            TMPage tmPageObj = new TMPage();
            string editedDescription = tmPageObj.GetEditedDescription(driver);
            string editedCode = tmPageObj.GetEditedCode(driver);
            string editedPrice = tmPageObj.GetEditedPrice(driver);
            Assert.That(editedDescription == p0, "Actual description and expected description do not match.");
            Assert.That(editedCode == p1, "Actual type code and expected type code do not match.");
            Assert.That(editedPrice == p2, "Actual price and expected price do not match.");
        }


    }
}
