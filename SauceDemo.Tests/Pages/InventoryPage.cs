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
        public bool HasInventoryContainer => inventoryContainer.Displayed;

        private IWebElement titleHeader => driver.FindElement(By.XPath("//span[@class='title']"));

        public string Title => titleHeader.Text;

        private IWebElement productSortContainer => driver.FindElement(By.ClassName("product_sort_container"));

        // Install-Package Selenium.Support
        private SelectElement productSortComboBox => new SelectElement(productSortContainer);

        private static string GetSortByPriceValue(Order order) => order == Order.Ascending ? "lohi" : "hilo";
        private static string GetSortByNameValue(Order order) => order == Order.Ascending ? "az" : "za";

        public void SortByPrice(Order order) => productSortComboBox.SelectByValue(GetSortByPriceValue(order));
        public void SortByName(Order order) => productSortComboBox.SelectByValue(GetSortByNameValue(order));

    }

    public enum Order
    {
        Ascending,
        Descending
    }


}
