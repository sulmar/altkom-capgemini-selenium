using Bupa.Bupa.Tests.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Bupa.Bupa.Tests
{
    [TestClass]
    public class QuotePageTests
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
        public void Navigate_GetAQuoteLinkClick_ShouldGetAQute()
        {
            QuoteYourNamePage quoteYourNamePage = new QuoteYourNamePage(driver);

            driver.Manage().Window.Maximize();

            homePage.GoToUrl(url);

            // Act
            if (homePage.HasAcceptCookiesButton)
                homePage.AcceptCookiesButtonClick();

            homePage.GetAQuoteLinkClick();

            // quoteYourNamePage.Fill("Dr", "John", "Smith");

            quoteYourNamePage.Fill(TitleCodes.Miss, "Ann", "Smith");

            
            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile("quote-your-name.png", ScreenshotImageFormat.Png);

        }
    }
}
