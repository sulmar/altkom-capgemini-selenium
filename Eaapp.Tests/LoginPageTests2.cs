using Eaapp.Tests.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eaapp.Tests
{
    [TestClass]
    public class LoginPageTests2
    {
        private readonly IWebDriver driver;

        private const string url = "http://eaapp.somee.com/Account/Login";

        public LoginPageTests2()
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl(url);
        }

        [TestMethod]
        public void Login_AsAdmin_ShouldDisplaysEmployeeDetails()
        {
            // Arrange
            LoginPage loginPage = new LoginPage(driver);
            HomePage homePage = new HomePage(driver);

            // Act
            loginPage.Login("admin", "password");
            loginPage.ButtonLoginClick();

            // Assert
            Assert.IsTrue(homePage.HasEmployeeDetailsLink);
        }

        [TestCleanup]
        public void Dispose()
        {
            driver.Quit();
        }
    }

}
