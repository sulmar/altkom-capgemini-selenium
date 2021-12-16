using Bupa.Bupa.Tests.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;
using System.Reflection;
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

            // Oczekiwanie a¿ strona zostanie w pe³ni za³adowana za pomoc¹ JavaScript
            // homePage.wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

            Assert.IsTrue(healthPage.Header.Displayed);

            // Assert
            Assert.IsTrue(healthPage.HasHeader);
        }

        [TestMethod]
        public void Navigate_HoverHealthLink_ShouldExpandHealthMenu()
        {
            homePage.GoToUrl(url);

            // Act
            if (homePage.HasAcceptCookiesButton)
                homePage.AcceptCookiesButtonClick();

            homePage.HealthLinkHover();

            // Assert
            Assert.AreEqual("menu-active", homePage.classHealthMenu);
            // Assert.IsTrue(homePage.IsActiveHealthMenu);
        }

        [TestMethod]
        public void Navigate_MoveToTravelLinkHover_ShouldExpandTravelMenu()
        {
            homePage.GoToUrl(url);

            // Act
            if (homePage.HasAcceptCookiesButton)
                homePage.AcceptCookiesButtonClick();

            homePage.MoveToTravelLinkHover();


        }

       


        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
