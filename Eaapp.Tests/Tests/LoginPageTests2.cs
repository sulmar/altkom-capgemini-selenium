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
    public class SauceLoginPageTests
    {

    }

   [TestClass]
    public class EaappLoginPageTests
    {
        private readonly IWebDriver driver;

        public EaappLoginPageTests()
        {
            driver = new ChromeDriver();
        }

        [TestMethod]
        public void Login_AsAdmin_ShouldDisplaysEmployeeDetails()
        {
            // Arrange
            EaappLoginPage loginPage = new EaappLoginPage(driver);
            HomePage homePage = new HomePage(driver);

            // Act
            loginPage.Login("admin", "password");
            loginPage.ButtonLoginClick();

            // Assert
            Assert.IsTrue(homePage.HasEmployeeDetailsLink);
        }

        [TestMethod]
        public void Login_AsStandardUser_ShouldDisplaysEmployeeDetails()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Login_AsProblemUser_ShouldDisplaysEmployeeDetails()
        {
            Assert.Fail();
        }


        [TestCleanup]
        public void Dispose()
        {
            driver.Quit();
        }
    }

}
