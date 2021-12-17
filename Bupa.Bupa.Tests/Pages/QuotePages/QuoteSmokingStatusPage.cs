using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Bupa.Bupa.Tests.Pages
{
    public class QuoteSmokingStatusPage : QuotePage
    {
        public QuoteSmokingStatusPage(IWebDriver driver) : base(driver)
        {
        }

        private IReadOnlyList<IWebElement> SmokeButtons => driver.FindElements(By.ClassName("you-smoke-btn"));

        private IWebElement YesButton => SmokeButtons.First();
        private IWebElement NoButton => SmokeButtons.Last();


        public void Fill(bool smoke)
        {
            if (smoke)
            {
                YesButton.Click();
            }
            else
            {
                NoButton.Click();
            }
        }

    }


}
