using OpenQA.Selenium;

namespace SauceDemo.Tests.Pages
{
    public abstract class BasePage
    {
        protected readonly IWebDriver driver;
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
