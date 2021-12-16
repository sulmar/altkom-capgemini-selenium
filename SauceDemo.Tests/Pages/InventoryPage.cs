using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemo.Tests.Pages
{
    public class InventoryPage : BasePage
    {
        public InventoryPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement inventoryContainer => driver.FindElement(By.Id("inventory_container"));
        public bool HasInventoryContainer => inventoryContainer.Displayed;

        private IWebElement titleHeader => driver.FindElement(By.XPath("//span[@class='title']"));

        public string Title => titleHeader.Text;
    }
}
