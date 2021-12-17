using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SauceDemo.SpecFlowTests.Drivers
{
    public class SeleniumDriver
    {
        private readonly ScenarioContext scenarioContext;

        public SeleniumDriver(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;            
        }

        public void Setup()
        {
            IWebDriver driver = new ChromeDriver();

            scenarioContext.Set(driver, key: "WebDriver");

            driver.Manage().Window.Maximize();
        }
    }
}
