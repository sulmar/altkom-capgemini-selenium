using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Bupa.Bupa.Tests.Pages
{

    public class QuoteYourNamePage : QuotePage
    {
        public QuoteYourNamePage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement TitleCodeField => driver.FindElement(By.Id("Prospect_ApplicantDetails_TitleCode"));
        private IWebElement FirstNameField => driver.FindElement(By.Id("Prospect_ApplicantDetails_FirstName"));
        private IWebElement LastNameField => driver.FindElement(By.Id("Prospect_ApplicantDetails_LastName"));

        public SelectElement TitleCodeComboBox => new SelectElement(TitleCodeField);
    


        // Selenium.Support
        public void Fill(string titleCode, string firstname, string lastname)
        {
            FirstNameField.SendKeys(firstname);
            LastNameField.SendKeys(lastname);

            TitleCodeComboBox.SelectByText(titleCode);
        }

        public void Fill(TitleCodes titleCode, string firstname, string lastname)
        {
            FirstNameField.SendKeys(firstname);
            LastNameField.SendKeys(lastname);

            TitleCodeComboBox.SelectByValue(((int)titleCode).ToString());
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
