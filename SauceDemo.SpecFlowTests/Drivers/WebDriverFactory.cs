using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;

namespace SauceDemo.SpecFlowTests.Drivers
{
    public class WebDriverFactory
    {
        public static IWebDriver GetDriver(BrowserTypes browserType)
        {
            dynamic driverOptions = new { BrowserNameValue = "Chrome 1.0" }; // TODO: pobierz z pliku konfiguracyjnego

            switch (browserType)
            {
                case BrowserTypes.Chrome: return new ChromeDriver(driverOptions);
                case BrowserTypes.Edge: return new EdgeDriver(driverOptions);
                case BrowserTypes.IE: return new InternetExplorerDriver(driverOptions);
                case BrowserTypes.Firefox: return new FirefoxDriver(driverOptions);

                default: throw new NotSupportedException($"Not supported {browserType}");
            }
        }
    }
}
