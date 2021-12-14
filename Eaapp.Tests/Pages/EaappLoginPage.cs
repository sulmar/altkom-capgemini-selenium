using OpenQA.Selenium;

namespace Eaapp.Tests.Pages
{
    public class EaappLoginPage : BaseLoginPage
    {
        public EaappLoginPage(IWebDriver driver) : base(driver)
        {
        }

        protected override By UserNameSelector => By.Id("UserName");
        protected override By PassswordSelector => By.Id("Password");
        protected override By ButtonLoginSelector => By.XPath("//input[@type='submit' and @value='Log in']");

        protected override string Url => "http://eaapp.somee.com/Account/Login";
    }
}
