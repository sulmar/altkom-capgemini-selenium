using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
        private IWebElement TravelLink => driver.FindElement(By.LinkText("Travel"));

        public bool HasHealthLink => HealthLink.Enabled;

        private string classHealthMenu => HealthLink.GetAttribute("class");
        public bool IsActiveHealthMenu => classHealthMenu == "menu-active";

        private string classTravelMenu => TravelLink.GetAttribute("class");
        public bool IsActiveTravelMenu => classTravelMenu == "menu-active";

        private IWebElement GetAQuoteLink => driver.FindElement(By.LinkText("Get a quote"));


        public void HealthLinkClick() => HealthLink.Click();
        public void GetAQuoteLinkClick() => GetAQuoteLink.Click();

        public void HealthLinkHover()
        {            

            // var inventoryItems = driver.FindElements(By.ClassName("intentory-item"));

            // foreach(IWebElement inventoryItem in inventoryItems)
            //{
            //    IWebElement itemPrice = inventoryItem.FindElement(By.ClassName("inventory-item-price"));
            //}

            //inventoryItems
            //    .Select(item=>item.FindElement(By.ClassName("inventory-item-price"))
            //    .Select(item => decimal.Parse( item.Text.Replace("$", string.Empty))
                
            Actions builder = new Actions(driver);
            builder.MoveToElement(HealthLink).Perform();

            // Assert
            
        }

        public void MoveToTravelLinkHover()
        {
            Actions builder = new Actions(driver);
            // Łączenie wielu akcji
            builder
                .MoveToElement(HealthLink)
                .MoveByOffset(350, 0)
                .Perform();

        }
    }
}
