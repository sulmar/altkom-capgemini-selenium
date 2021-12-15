using OpenQA.Selenium;
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

        public bool HasAcceptCookiesButton => AcceptCookiesButton.Displayed;

        public void AcceptCookiesButtonClick() => AcceptCookiesButton.Click();


    }
}
