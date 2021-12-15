using Bupa.Bupa.Tests.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
            Assert.IsTrue(homePage.HasAcceptCookiesButton);

            // Assert
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
