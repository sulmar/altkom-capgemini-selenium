using Bupa.Bupa.Tests.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

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
            QuoteCoverForPage quoteCoverForPage = new QuoteCoverForPage(driver);
            QuoteYourDobPage quoteYourDobPage = new QuoteYourDobPage(driver);
            QuoteYourAddress quoteYourAddress = new QuoteYourAddress(driver);
            QuoteSmokingStatus quoteSmokingStatus = new QuoteSmokingStatus(driver);

            driver.Manage().Window.Maximize();

            homePage.GoToUrl(url);

            // Act
            if (homePage.HasAcceptCookiesButton)
                homePage.AcceptCookiesButtonClick();

            homePage.GetAQuoteLinkClick();

            quoteYourNamePage.Fill(TitleCodes.Dr, "John", "Smith");

            // Utworzenie zrzutu ekranu i zapis na dysk
            //ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            //Screenshot screenshot = screenshotDriver.GetScreenshot();
            //screenshot.SaveAsFile("quote-your-name.png", ScreenshotImageFormat.Png);

            quoteYourNamePage.NextButtonClick();

            Assert.AreEqual("Great to meet you John.", quoteCoverForPage.Greatings);

            

            quoteCoverForPage.Fill(QuoteCoverForPage.Cover.JustMe);

            quoteCoverForPage.NextButtonClick();

            quoteYourDobPage.Fill(DateTime.Parse("1990-12-31"));

            quoteYourDobPage.NextButtonClick();

            quoteYourAddress.Fill("EC2R 7HJ", isUKResident: true);

            quoteYourAddress.NextButtonClick();

            quoteSmokingStatus.Fill(true);

            quoteSmokingStatus.NextButtonClick();





        }
    }
}
