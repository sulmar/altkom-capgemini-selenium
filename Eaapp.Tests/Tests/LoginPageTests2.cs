using Eaapp.Tests.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;


namespace Eaapp.Tests
{
 
    [TestClass]
    public class SauceLoginPageTests
    {
        private IWebDriver driver;
        private SauceLoginPage loginPage;
        private HomePage homePage;

        [TestInitialize]
        public void Initialize()
        {
            driver = new ChromeDriver();
            loginPage = new SauceLoginPage(driver);
            homePage = new HomePage(driver);
        }
    }

   [TestClass]
    public class EaappLoginPageTests
    {
        private IWebDriver driver;
        private EaappLoginPage loginPage;
        private HomePage homePage;


        [TestInitialize]
        public void Initialize()
        {
            driver = new ChromeDriver();
            loginPage = new EaappLoginPage(driver);
            homePage = new HomePage(driver);
        }

        [TestMethod]
        public void Login_AsAdmin_ShouldDisplaysEmployeeDetails()
        {
            // Arrange
            // Act
            loginPage.Login("admin", "password");
            loginPage.LoginButtonClick();

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
        public void Cleanup()
        {
            driver.Quit();
        }
    }

}
