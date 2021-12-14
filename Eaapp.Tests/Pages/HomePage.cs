using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eaapp.Tests.Pages
{

    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement EmployeeDetailsLink => driver.FindElement(By.LinkText("Employee Details"));

        public bool HasEmployeeDetailsLink => EmployeeDetailsLink.Displayed;

    }
}
