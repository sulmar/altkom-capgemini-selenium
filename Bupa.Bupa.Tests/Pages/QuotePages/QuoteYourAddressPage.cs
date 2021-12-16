using OpenQA.Selenium;

namespace Bupa.Bupa.Tests.Pages
{
    public class QuoteYourAddressPage : QuotePage
    {
        public QuoteYourAddressPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement PostcodeField => driver.FindElement(By.Id("Prospect_ApplicantDetails_ContactDetails_Postcode"));
        private IWebElement AddressItem => driver.FindElement(By.ClassName("ui-menu-item"));
        private IWebElement AcceptCheckBox => driver.FindElement(By.ClassName("terms-checkbox"));

        public void Fill(string postCode, bool isUKResident)
        {
            wait.Until(_ => PostcodeField.Displayed);
            PostcodeField.SendKeys(postCode);

            wait.Until(_ => AddressItem.Displayed);

            AddressItem.Click();

            if (isUKResident)
                AcceptCheckBox.Click();


        }
    }


}
