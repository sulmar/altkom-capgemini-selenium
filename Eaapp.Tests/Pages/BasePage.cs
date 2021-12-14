using OpenQA.Selenium;

namespace Eaapp.Tests.Pages
{
    public abstract class BasePage
    {
        protected readonly IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string Title => driver.Title;

    }
}
