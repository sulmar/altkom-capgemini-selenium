using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemo.SpecFlowTests.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SauceDemo.SpecFlowTests.Hooks
{
    [Binding]
    public sealed class Hook
    {
        private readonly ScenarioContext scenarioContext;

        private readonly IWebDriver driver;

        public Hook(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;

            driver = scenarioContext.Get<IWebDriver>("WebDriver");
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}
