using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Bupa.Bupa.Tests.Pages
{
    // Selenium.WebDriver
    public abstract class BasePage
    {
        protected readonly IWebDriver driver;

        // Explicit Wait
        protected WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;

            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Implit Wait (niejawne oczekiwanie)
            // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //  maksymalny czas oczekiwania
        }

        public string Title => driver.Title;

        public void GoToUrl(string url) => driver.Navigate().GoToUrl(url);

    }
}
