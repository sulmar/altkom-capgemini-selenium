using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemo.Tests.Pages;

namespace SauceDemo.Tests
{
    [TestClass]
    public class InventoryTests
    {
        private IWebDriver driver;

        private const string url = "https://www.saucedemo.com/";

        private LoginPage loginPage;
        private InventoryPage inventoryPage;

        [TestInitialize]
        public void Initialize()
        {
            // Install-Package Selenium.WebDriver.ChromeDriver
            driver = new ChromeDriver();

            //Arrange
            loginPage = new LoginPage(driver);
            inventoryPage = new InventoryPage(driver);
            driver.Navigate().GoToUrl(url);

            loginPage.Login("standard_user", "secret_sauce");
            loginPage.LoginButtonClick();
        }

        [DataRow(SortOrder.Ascending)]
        [DataRow(SortOrder.Descending)]
        [DataTestMethod]
        public void Sort_SelectByPriceOrder_ShouldProductsSortedByPrice(SortOrder sortOrder)
        {
            //Act
            inventoryPage.SortByPrice(sortOrder);

            //Assert
            Assert.Fail();
        }

        [DataRow(SortOrder.Ascending)]
        [DataRow(SortOrder.Descending)]
        [DataTestMethod]
        public void Sort_SelectByNaeOrder_ShouldProductsSortedByName(SortOrder sortOrder)
        {
            //Act
            inventoryPage.SortByName(sortOrder);

            //Assert
            Assert.Fail();
        }

        [TestCleanup]
        public void CleanUp()
        {
            // driver.Quit();
        }

    }
}
