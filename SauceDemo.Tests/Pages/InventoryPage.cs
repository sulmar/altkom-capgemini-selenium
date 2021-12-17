using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
        public bool HasInventoryPage => inventoryContainer.Displayed;

        private IWebElement titleHeader => driver.FindElement(By.XPath("//span[@class='title']"));

        public string Title => titleHeader.Text;

        private IWebElement productSortContainer => driver.FindElement(By.ClassName("product_sort_container"));

        // Install-Package Selenium.Support
        private SelectElement productSortComboBox => new SelectElement(productSortContainer);

        private static string GetSortByPriceValue(Order order) => order == Order.Ascending ? "lohi" : "hilo";
        private static string GetSortByNameValue(Order order) => order == Order.Ascending ? "az" : "za";

        public void SortByPrice(Order order) => productSortComboBox.SelectByValue(GetSortByPriceValue(order));
        public void SortByName(Order order) => productSortComboBox.SelectByValue(GetSortByNameValue(order));

        private IEnumerable<IWebElement> inventoryItemNameElements => driver.FindElements(By.ClassName("inventory_item_name"));
        public IEnumerable<string> inventoryItemNames => inventoryItemNameElements.Select(element => element.Text);

        private IEnumerable<IWebElement> inventoryItemPriceElements => driver.FindElements(By.ClassName("inventory_item_price"));

        private IEnumerable<IWebElement> inventoryItemElements => driver.FindElements(By.ClassName("inventory_item"));

        private IEnumerable<InventoryItem> inventoryItems => inventoryItemElements.Select(item => new InventoryItem
        {
            Name = item.FindElement(By.ClassName("inventory_item_name")).Text,
            Price = decimal.Parse(item.FindElements(By.ClassName("inventory_item_price"))[1].Text)
        });

        public IEnumerable<decimal> inventoryItemPrices => inventoryItems.Select(item => item.Price);

    }

    public class InventoryItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public enum Order
    {
        Ascending,
        Descending
    }


}
