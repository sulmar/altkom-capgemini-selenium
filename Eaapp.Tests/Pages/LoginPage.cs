using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eaapp.Tests.Pages
{

    public static class IWebElementExtensions
    {
        // Metoda rozszerzająca (Extension Method)
        public static void LogAndClick(this IWebElement element)
        {
            // TODO: Log

            element.Click();
        }
    }
}
