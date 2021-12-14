using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;

namespace Eaapp.Tests
{
    // Install-Package Selenium.WebDriver

    [TestClass]
    public class LoginPageTests
    {
        // Method_Scenario_ExpectedBehavior

        private const string url = "http://eaapp.somee.com/";

        [TestMethod]
        public void Login_AsAdmin_ShouldDisplaysEmployeeDetails()
        {
            // http://eaapp.somee.com/
            // login: admin
            // password: password

            // # Rêczna instalacja
            // 1. Pobieramy ChromeDriver ze strony http://chromedriver.storage.googleapis.com/index.html
            // 2. Wskazujemy folder
            // IWebDriver driver = new ChromeDriver(@"C:\temp\drivers");

            // # Automatyczna instalacja za pomoc¹ paczki NuGet
            // Install-Package Selenium.WebDriver.ChromeDriver
            IWebDriver driver = new ChromeDriver();

            // driver.get(url);
            driver.Navigate().GoToUrl(url);

            IWebElement loginLink = driver.FindElement(By.LinkText("Login"));

            Assert.IsTrue(loginLink.Displayed);

            loginLink.Click();

            // Click + Ctrl
            //Actions action = new Actions(driver);
            //action.KeyDown(Keys.Control).MoveToElement(loginLink).Click().Perform();

            // Prze³¹cza aktywn¹ zak³adkê
            // driver.SwitchTo().Window(driver.CurrentWindowHandle);            

            // loginLink.SendKeys(Keys.Control + 't');

            Assert.AreEqual("Login - Execute Automation Employee App", driver.Title);
            Assert.AreEqual("http://eaapp.somee.com/Account/Login", driver.Url);

            IWebElement usernameField = driver.FindElement(By.Id("UserName"));
            IWebElement paswordField = driver.FindElement(By.Id("Password"));

            usernameField.SendKeys("admin");
            paswordField.SendKeys("password");

            // XPath
            IWebElement loginButton = driver.FindElement(By.XPath("//input[@type='submit' and @value='Log in']"));

            loginButton.Click();

            IWebElement employeeDetailsLink = driver.FindElement(By.LinkText("Employee Details"));

            Assert.IsTrue(employeeDetailsLink.Displayed);

            // Zamyka wszystkie zak³adki
            // driver.Quit();

            // Zamyka tylko aktywn¹ zak³adkê
            driver.Close();
        }

        [TestMethod]
        public void Login_AsAdminNewTab_ShouldDisplaysEmployeeDetails()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);

            IWebElement loginLink = driver.FindElement(By.LinkText("Login"));

            // Click + Ctrl
            Actions action = new Actions(driver);
            action.KeyDown(Keys.Control).MoveToElement(loginLink).Click().Perform();
                  
           
            // Prze³¹cza aktywn¹ zak³adkê
            driver.SwitchTo().Window(driver.WindowHandles.Last());
          
            // Wait Implicit (niejawne oczekiwanie)
            // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            // wait (explicit)
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(d => d.WindowHandles.Count == 2);
            

            wait.Until( d => d.FindElement(By.Id("UserName")).Displayed);

            IWebElement usernameField = driver.FindElement(By.Id("UserName"));
            Assert.IsTrue(usernameField.Displayed);

            IWebElement paswordField = driver.FindElement(By.Id("Password"));
       

            usernameField.SendKeys("admin");
            paswordField.SendKeys("password");

            // XPath
            IWebElement loginButton = driver.FindElement(By.XPath("//input[@type='submit' and @value='Log in']"));

            loginButton.Click();

            IWebElement employeeDetailsLink = driver.FindElement(By.LinkText("Employee Details"));

            Assert.IsTrue(employeeDetailsLink.Displayed);

            // Zamyka wszystkie zak³adki
            // driver.Quit();

            // Zamyka tylko aktywn¹ zak³adkê
            driver.Close();
        }


        [TestMethod]
        public void Login_BadLinkName_ShouldThrowsNoSuchElementException()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl(url);

            Action act = () => driver.FindElement(By.LinkText("Abc"));

            Assert.ThrowsException<NoSuchElementException>(act);

            driver.Quit();
        }
    }
}
