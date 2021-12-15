using OpenQA.Selenium;

namespace Eaapp.Tests.Pages
{
    public abstract class BaseLoginPage : BasePage
    {
        protected abstract By UserNameSelector { get; }
        protected abstract By PassswordSelector { get; }
        protected abstract By LoginButttonSelector { get;  }

        public IWebElement UserNameField => driver.FindElement(UserNameSelector);
        public IWebElement PasswordField => driver.FindElement(PassswordSelector);
        public IWebElement LoginButton => driver.FindElement(LoginButttonSelector);

        protected abstract string Url { get;  }

       

        protected BaseLoginPage(IWebDriver driver) : base(driver)
        {
            driver.Navigate().GoToUrl(Url);
        }

        public void Login(string username, string password)
        {
            UserNameField.SendKeys(username);
            PasswordField.SendKeys(password);
        }

        public void LoginButtonClick() => LoginButton.LogAndClick();


    }
}
