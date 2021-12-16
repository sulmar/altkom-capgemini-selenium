using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Bupa.Bupa.Tests.Pages
{
    public class QuoteCoverForPage : QuotePage
    {
        public QuoteCoverForPage(IWebDriver driver) : base(driver)
        {
        }
        private IWebElement greatingsElement => driver.FindElement(By.XPath("//h1[contains(@class, 'main-heading')]/span[1]"));

        public string Greatings => greatingsElement.Text;

        private IWebElement CoverCodeField => driver.FindElement(By.Id("Prospect_CoverDetail_CoverCode"));

        private IWebElement CoverMenuItem => driver.FindElement(By.ClassName("ui-menu-item"));

        private SelectElement CoverComboBox => new SelectElement(CoverCodeField);
        

        public void Fill(string cover)
        {
            CoverComboBox.SelectByText(cover);
        }

        public void Fill(Cover cover)
        {
            wait.Until(p => CoverCodeField.Displayed);

            CoverCodeField.Click();

            wait.Until(p => CoverMenuItem.Displayed);

            CoverComboBox.SelectByValue(((int)cover).ToString());
        }

        public enum Cover
        {
            JustMe = 1,
            MeAndMyPartner = 2,
            MeAndMyChildren = 4
        }

    }


}
