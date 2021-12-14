using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eaapp.Tests.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement UserNameField => driver.FindElement(By.Id("UserName"));
        public IWebElement PasswordField => driver.FindElement(By.Id("Password"));
        public IWebElement ButtonLogin => driver.FindElement(By.XPath("//input[@type='submit' and @value='Log in']"));

        public void Login(string username, string password)
        {
            UserNameField.SendKeys(username);
            PasswordField.SendKeys(password);            
        }

        public void ButtonLoginClick() => ButtonLogin.LogAndClick();       
    }

    public static class IWebElementExtensions
    {
        // Metoda rozszerzająca (Extension Method)
        public static void LogAndClick(this IWebElement element)
        {
            // TODO: Log

            element.Click();
        }
    }
}
