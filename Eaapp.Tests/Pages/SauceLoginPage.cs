using OpenQA.Selenium;

namespace Eaapp.Tests.Pages
{
    public class SauceLoginPage : BaseLoginPage
    {
        public SauceLoginPage(IWebDriver driver) : base(driver)
        {
        }

        protected override By UserNameSelector => By.Name("user-name");
        protected override By PassswordSelector => By.Name("password");
        protected override By ButtonLoginSelector => By.Name("login-button");

        protected override string Url => "https://www.saucedemo.com/";
    }
}
