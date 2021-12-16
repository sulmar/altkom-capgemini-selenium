﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemo.Tests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemo.Tests
{
    [TestClass]
    public class LoginPageTests
    {
        // Install-Package Selenium.WebDriver
        private IWebDriver driver;

        private const string url = "https://www.saucedemo.com/";

        [TestInitialize]
        public void Initialize()
        {
            // Install-Package Selenium.WebDriver.ChromeDriver
            driver = new ChromeDriver();
        }

        [TestMethod]
        public void Login_AsStandardUser_ShouldRedirectToInventoryPage()
        {
            //Arrange
            LoginPage loginPage = new LoginPage(driver);
            InventoryPage inventoryPage = new InventoryPage(driver);

            //Act
            driver.Navigate().GoToUrl(url);

            loginPage.Login("standard_user", "secret_sauce");
            loginPage.LoginButtonClick();

            //Assert
            Assert.AreEqual("PRODUCTS", inventoryPage.Title);
        }

        [TestMethod]
        public void Login_AsLockedOutUser_ShouldDisplayLockedOutMessage()
        {
            //Arrange
            LoginPage loginPage = new LoginPage(driver);

            //Act
            driver.Navigate().GoToUrl(url);

            loginPage.Login("locked_out_user", "secret_sauce");            
            loginPage.LoginButtonClick();

            //Assert
            Assert.AreEqual("Epic sadface: Sorry, this user has been locked out.", loginPage.ErrorMessage.Text);
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }

    }
}