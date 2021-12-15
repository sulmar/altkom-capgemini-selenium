using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bupa.Bupa.Tests.Pages
{

    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {

        }
        
        public IWebElement AcceptCookiesButton => driver.FindElement(By.Id("onetrust-accept-btn-handler"));

        public bool HasAcceptCookiesButton => wait.Until(driver => AcceptCookiesButton.Displayed); // Explicit Wait

        public void AcceptCookiesButtonClick() => AcceptCookiesButton.Click();

        private IWebElement HealthLink => driver.FindElement(By.LinkText("Health"));

        public bool HasHealthLink => HealthLink.Enabled;

        public void HealthLinkClick() => HealthLink.Click();
    }
}
