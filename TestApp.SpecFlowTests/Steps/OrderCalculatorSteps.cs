using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;
using TestApp.Fundamentals;

namespace TestApp.SpecFlowTests.Steps
{
    [Binding]
    public class OrderCalculatorSteps
    {
        private OrderCalculator orderCalculator;
        private int result;

        private readonly ScenarioContext _scenarioContext;

        public OrderCalculatorSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

            _scenarioContext.Add("firstname", "John");            

            orderCalculator = new OrderCalculator();
        }

        [Given(@"the total amount net is (.*)")]
        public void GivenTheTotalAmountNetIs(int totalAmountNet)
        {
            orderCalculator.TotalAmountNet = totalAmountNet;
        }
        
        [Given(@"the tax ratio is (.*)")]
        public void GivenTheTaxRatioIs(int taxRatio)
        {
            orderCalculator.TaxRatio = taxRatio;
        }
        
        [When(@"the user click Calculate button")]
        public void WhenTheUserClickCalculateButton()
        {
            string firstname = _scenarioContext.Get<string>("firstname");

            this.result = orderCalculator.Calculate();
        }
        
        [Then(@"the total amount gross should be (.*)")]
        public void ThenTheTotalAmountGrossShouldBe(int totalAmountGross)
        {
            // Assert.AreEqual(expected: totalAmountGross, actual: result);

            result.Should().Be(totalAmountGross);
        }
    }
}
