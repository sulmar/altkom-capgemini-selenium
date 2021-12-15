using OpenQA.Selenium;

namespace Bupa.Bupa.Tests.Pages
{
    // Selenium.WebDriver
    public abstract class BasePage
    {
        protected readonly IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string Title => driver.Title;

        public void GoToUrl(string url) => driver.Navigate().GoToUrl(url);

    }
}
