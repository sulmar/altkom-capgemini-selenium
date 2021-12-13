using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestApp.Fundamentals;

namespace TestApp.UnitTests
{
    [TestClass]
    public class MathCalculatorTests
    {
        private MathCalculator mathCalculator;

        [TestInitialize]    // BeforeTest
        public void Setup()
        {
            // Arrange
            mathCalculator = new MathCalculator();
        }

        // Method_Scenario_ExpectedBehavior
        [TestMethod]
        public void Add_PassValidArguments_ShouldReturnTheSumOfArguments()
        {
            // Act
            int result = mathCalculator.Add(1, 2);

            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Max_FirstArgumentIsGreaterThanSecondArgument_ShouldReturnFirstArgument()
        {
            // Act
            int result = mathCalculator.Max(2, 1);

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Max_SecondArgumentIsGreaterThanFirstArgument_ShouldReturnSecondArgument()
        {
            // Act
            int result = mathCalculator.Max(1, 2);

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Max_FirstAndSecondArgumentIsEquals_ShouldReturnsTheSameArgument()
        {
            // Act
            int result = mathCalculator.Max(1, 1);

            // Assert
            Assert.AreEqual(1, result);
        }


    }
}
