using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bupa.Bupa.Tests.Pages
{
    public class HealthPage : BasePage
    {
        public HealthPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement Header => driver.FindElement(By.LinkText("Health insurance"));


        public bool HasHeader => wait.Until(driver=> Header.Displayed);

    }

   
    


    

}
