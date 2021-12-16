using OpenQA.Selenium;
using System;

namespace Bupa.Bupa.Tests.Pages
{
    public class QuoteStartDatePage : QuotePage
    {
        public QuoteStartDatePage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement PolicyStartDateField => driver.FindElement(By.Id("pm_datepicker"));

        public void Fill(DateTime dateOfBirth)
        {
            wait.Until(driver => PolicyStartDateField.Displayed);

            PolicyStartDateField.SendKeys(dateOfBirth.ToString());
        }
    }


}
