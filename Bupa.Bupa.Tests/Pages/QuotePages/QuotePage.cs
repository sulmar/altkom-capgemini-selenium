using OpenQA.Selenium;

namespace Bupa.Bupa.Tests.Pages
{
    public abstract class QuotePage : BasePage
    {
        protected QuotePage(IWebDriver driver) : base(driver)
        {
        }

        protected IWebElement NextButton => driver.FindElement(By.XPath("//button[@type='submit']"));
        public void NextButtonClick() => NextButton.Click();

    }


}
