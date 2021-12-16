using OpenQA.Selenium;
using System;

namespace Bupa.Bupa.Tests.Pages
{

    public class QuoteYourDobPage : QuotePage
    {
        public QuoteYourDobPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement DateOfBirthDayField => driver.FindElement(By.Id("Prospect_ApplicantDetails_Day"));
        private IWebElement DateOfBirthMonthField => driver.FindElement(By.Id("Prospect_ApplicantDetails_Month"));
        private IWebElement DateOfBirthYearField => driver.FindElement(By.Id("Prospect_ApplicantDetails_Year"));

        public void Fill(DateTime dateOfBirth)
        {
            wait.Until(driver => DateOfBirthDayField.Displayed);

            DateOfBirthDayField.SendKeys(dateOfBirth.Day.ToString());
            DateOfBirthMonthField.SendKeys(dateOfBirth.Month.ToString());
            DateOfBirthYearField.SendKeys(dateOfBirth.Year.ToString());
        }

    }


}
