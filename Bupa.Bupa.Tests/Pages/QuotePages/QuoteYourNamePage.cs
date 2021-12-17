using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Bupa.Bupa.Tests.Pages
{

    public class QuoteYourNamePage : QuotePage
    {
        public QuoteYourNamePage(IWebDriver driver) : base(driver)
        {
        }

        private SelectElement TitleCodeField => driver.FindElement(By.Id("Prospect_ApplicantDetails_TitleCode")).AsSelectElement();
        
        // private IWebElement FirstNameField => driver.FindElement(By.Id("Prospect_ApplicantDetails_FirstName"));
        private IWebElement FirstNameField => driver.FindElement(By.Id("Prospect_ApplicantDetails_FirstName"), 5);

        private IWebElement LastNameField => driver.FindElement(By.Id("Prospect_ApplicantDetails_LastName"));
        

        // Selenium.Support
        public void Fill(string titleCode, string firstname, string lastname)
        {
            FirstNameField.SendKeys(firstname);
            LastNameField.SendKeys(lastname);
            TitleCodeField.SelectByText(titleCode);
        }

        public void Fill(TitleCodes titleCode, string firstname, string lastname)
        {
            FirstNameField.SendKeys(firstname);
            LastNameField.SendKeys(lastname);

            TitleCodeField.SelectByValue(((int)titleCode).ToString());
        }
    }

    public enum TitleCodes
    {
        Mr = 36,
        Miss = 35,
        Mrs = 37,
        Ms = 38,
        Dr = 15,
        Professor = 43,
        Reverend = 46
    }


}
