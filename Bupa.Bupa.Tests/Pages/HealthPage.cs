using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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

    public class QuoteYourNamePage : BasePage
    {
        public QuoteYourNamePage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement TitleCodeField => driver.FindElement(By.Id("Prospect_ApplicantDetails_TitleCode"));
        public IWebElement FirstNameField => driver.FindElement(By.Id("Prospect_ApplicantDetails_FirstName"));
        public IWebElement LastNameField => driver.FindElement(By.Id("Prospect_ApplicantDetails_LastName"));

        public SelectElement TitleCodeComboBox => new SelectElement(TitleCodeField);


        // Selenium.Support
        public void Fill(string titleCode, string firstname, string lastname)
        {
            FirstNameField.SendKeys(firstname);
            LastNameField.SendKeys(lastname);

            TitleCodeComboBox.SelectByText(titleCode);
            
        }

        public void Fill(TitleCodes titleCode, string firstname, string lastname)
        {
            FirstNameField.SendKeys(firstname);
            LastNameField.SendKeys(lastname);

            TitleCodeComboBox.SelectByValue(((int)titleCode).ToString());
        }
    }

   
    public enum TitleCodes
    {        
        [Power(100, 3)]
        Mr = 36,

        [Power(200, 2)]
        Miss = 35
    }


    

}
