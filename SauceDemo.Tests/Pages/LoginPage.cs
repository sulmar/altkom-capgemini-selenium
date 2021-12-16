using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemo.Tests.Pages
{

    class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement UserNameField => driver.FindElement(By.Id("user-name"));
        public IWebElement PasswordField => driver.FindElement(By.Id("password"));
        public IWebElement LoginButton => driver.FindElement(By.Id("login-button"));
        public IWebElement ErrorMessage => driver.FindElement(By.XPath("//h3[@data-test='error']"));

        public void Login(string userName, string password)
        {
            UserNameField.SendKeys(userName);
            PasswordField.SendKeys(password);
        }
        public void LoginButtonClick()
        {
            LoginButton.Click();
        }

    }
}
