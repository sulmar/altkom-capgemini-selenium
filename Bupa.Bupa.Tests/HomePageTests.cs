using Bupa.Bupa.Tests.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
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

            Assert.IsTrue(homePage.IsActiveHealthMenu);
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

        [TestMethod]
        public void Navigate_GetAQuoteLinkClick_ShouldGetAQute()
        {
            QuoteYourNamePage quoteYourNamePage = new QuoteYourNamePage(driver);

            homePage.GoToUrl(url);

            // Act
            if (homePage.HasAcceptCookiesButton)
                homePage.AcceptCookiesButtonClick();

            homePage.GetAQuoteLinkClick();

            // quoteYourNamePage.Fill("Dr", "John", "Smith");

            quoteYourNamePage.Fill(TitleCodes.Miss, "Ann", "Smith");
        }


        [TestCleanup]
        public void Cleanup()
        {
         //   driver.Quit();
        }
    }


    [TestClass]
    public class PowerFactoryTests
    {
        [TestMethod]
        public void Create_ValidTitleCodes_ReturnValue()
        {
            PowerFactory powerFactory = new PowerFactory();

            var result = powerFactory.Create(TitleCodes.Miss);

            Assert.AreEqual(200, result);
        }
    }


    [AttributeUsage(AttributeTargets.Field)]
    public class PowerAttribute : Attribute
    {
        public int Value { get; set; }

        public PowerAttribute(int value, int life)
        {
            Value = value;
        }
    }

    public class PowerFactory
    {

        public int Create(TitleCodes titleCodes)
        {
            // System.Reflection

            throw new NotImplementedException();

            // var attributes = titleCodes.GetType().GetCustomAttributes(typeof); 
            
            
            //var powerAttribute = attributes.OfType<PowerAttribute>().SingleOrDefault();

            //return powerAttribute.Value;


        }
    }
}
