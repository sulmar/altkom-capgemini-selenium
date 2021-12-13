using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Fundamentals;
using FluentAssertions;

namespace TestApp.UnitTests
{
    [TestClass]
    public class ReportFactoryTests
    {
        private const string UnknownType = "X";

        // P, LP, LF -> Osobowość prawna

        [DataRow("P")]
        [DataRow("LP")]
        [DataRow("LF")]
        [DataTestMethod]
        public void Create_TypeIsPOrLPOrLF_ShouldReturnLegalPersonalityReport(string type)
        {
            // Act
            var result = ReportFactory.Create(type);

            // Assert
            Assert.IsInstanceOfType(result, typeof(LegalPersonality));
            result.Should().BeOfType<LegalPersonality>();

        }

        // F -> Działalność fizyczna
        [TestMethod]
        public void Create_TypeIsF_ShouldReturnSoleTraderReport()
        {
            // Act
            var result = ReportFactory.Create("F");

            // Assert
            result.Should().BeOfType<SoleTraderReport>();
        }

        // nieznany -> NotSupportedException
        [TestMethod]
        public void Create_TypeIsUnknown_ShouldThrowNotSupportedException()
        {
            // Act
            Action act = () => ReportFactory.Create(UnknownType);

            // Assert
            act.Should().Throw<NotSupportedException>();
        }

        // pusty -> ArgumentNullException
        [TestMethod]
        public void Create_TypeIsEmpty_ShouldThrowArgumentNullException()
        {
            // Act
            Action act = () => ReportFactory.Create(string.Empty);

            // Assert
            act.Should().Throw<ArgumentNullException>();
        }

    }
}
