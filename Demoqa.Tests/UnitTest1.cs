using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Demoqa.Tests
{
    [TestClass]
    public class AlertTests
    {
        [TestMethod]
        public void Alert_ClickButton_ShouldDisplayAlertMessage()
        {
            // Arrange
            IWebDriver driver = new ChromeDriver();

            AlertPage alertPage = new AlertPage(driver);

            // Act
            alertPage.ClickAlertButton();

            // Assert
            Assert.AreEqual("You clicked a button", alertPage.AlertMessage);

            alertPage.AlertConfirm();

        }
    }


    public abstract class BasePage
    {
        protected readonly IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string Title => driver.Title;

    }

    public class AlertPage : BasePage
    {
        private IWebElement AlertButton => driver.FindElement(By.Id("alertButton"));

        public AlertPage(IWebDriver driver) : base(driver)
        {
            driver.Navigate().GoToUrl("https://demoqa.com/alerts");
        }

        public void ClickAlertButton() => AlertButton.Click();

        private IAlert alert => driver.SwitchTo().Alert();

        public string AlertMessage => alert.Text;

        public void AlertConfirm() => alert.Accept();


    }
}
