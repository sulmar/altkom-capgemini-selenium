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

        private static string GetSortByPriceValue(SortOrder sortOrder) => sortOrder == SortOrder.Ascending ? "lohi" : "hilo";
        private static string GetSortByNameValue(SortOrder sortOrder) => sortOrder == SortOrder.Ascending ? "az" : "za";


        public void SortByPrice(SortOrder sortOrder)
        {
            productSortComboBox.SelectByValue(GetSortByPriceValue(sortOrder));
        }

        public void SortByName(SortOrder sortOrder)
        {
            productSortComboBox.SelectByValue(GetSortByNameValue(sortOrder));
        }

        
    }

    public enum SortOrder
    {
        Ascending,
        Descending
    }


}
