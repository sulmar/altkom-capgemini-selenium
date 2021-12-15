using Bupa.Bupa.Tests.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace Bupa.Bupa.Tests
{
    [TestClass]
    public class HomePageTests
    {
        private HomePage homePage;
        private IWebDriver driver;

        private const string url = "https://www.bupa.co.uk/";

        [TestInitialize]
        public void Initialize()
        {
            // Selenium.WebDriver.ChromeDriver
            driver = new ChromeDriver();
            homePage = new HomePage(driver);
        }

        [TestMethod]
        public void Navigate_AcceptCookies_ShouldHealthLinkClickable()
        {
            // Arrange
            homePage.GoToUrl(url);

            // Act
            homePage.AcceptCookiesButtonClick();

            // Assert
            // Assert.IsTrue(homePage.)
        }

        [TestMethod]
        public void Navigate_ClickHealth_ShouldHealthSection()
        {
            // Arrange
            HealthPage healthPage = new HealthPage(driver);

            homePage.GoToUrl(url);

            // Act
            if (homePage.HasAcceptCookiesButton)
                homePage.AcceptCookiesButtonClick();            

            homePage.HealthLinkClick();

            // homePage.wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

            Assert.IsTrue(healthPage.Header.Displayed);

            // Assert
            Assert.IsTrue(healthPage.HasHeader);
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
