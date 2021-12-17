using FluentAssertions;
using OpenQA.Selenium;
using SauceDemo.Tests.Pages;
using System;
using TechTalk.SpecFlow;

namespace SauceDemo.SpecFlowTests.Steps
{
    [Binding]
    public class LoginSteps
    {
        private LoginPage loginPage;
        private InventoryPage inventoryPage;

        private readonly ScenarioContext scenarioContext;

        private IWebDriver driver;

        public LoginSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;

            driver = scenarioContext.Get<IWebDriver>("WebDriver");

            loginPage = new LoginPage(driver);
            inventoryPage = new InventoryPage(driver);
        }

        [Given(@"I navigate to homepage")]
        public void GivenINavigateToHomepage()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }
        
        [When(@"I enter (.*) and (.*)")]
        public void WhenIEnterAnd(string username, string password)
        {
            loginPage.Login(username, password);            
        }
        
        [When(@"I click on Login Button")]
        public void WhenIClickOnLoginButton()
        {
            loginPage.LoginButtonClick();
        }
        
        [When(@"I am logged")]
        [Then(@"I am logged")]
        public void ThenIAmLogged()
        {
            // ScenarioContext.Current.Pending();
        }

        [Then(@"I see Inventory Page\.")]
        public void ThenISeeInventoryPage()
        {
            inventoryPage.HasInventoryPage.Should().BeTrue();
        }


        [Then(@"I see error (.*)\.")]
        public void ThenISee(string errorMessage)
        {
            loginPage.ErrorMessage.Should().Be(errorMessage);
        }
    }
}
