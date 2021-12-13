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
    public class MarkdownFormatterTests
    {
        private const string NotEmptyContent = "abc";
        private readonly string EmptyContent = string.Empty;

        private MarkdownFormatter markdownFormatter;

        [TestInitialize]
        public void Setup()
        {
            // Arrange
            markdownFormatter = new MarkdownFormatter();
        }


        [DataRow("a")]
        [DataRow("abc")]
        [DataRow("Lorem ipsum")]
        [DataTestMethod]
        public void FormatAsBold_NotEmptyContent_ShouldReturnsContentEncloseDoubleAsterix(string content)
        {
            // Act
            var result = markdownFormatter.FormatAsBold(NotEmptyContent);

            // Assert
            // Assert.AreEqual("**abc**", result);

            // Install-Package FluentAssertions
            // result.Should().Be("**abc**");

            result.Should()
                .StartWith("**")
                .And.Be(content)
                .And.EndWith("**");
        }

        [TestMethod]
        public void FormatAsBold_EmptyContent_ShouldThrowsArgumentNullException()
        {
            // Act
            Action act = () =>  markdownFormatter.FormatAsBold(EmptyContent);

            // Assert
            // Assert.ThrowsException<ArgumentNullException>(act);

            act.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void FormatAsBold_NullContent_ShouldThrowsArgumentNullException()
        {
            // Act
            Action act = () => markdownFormatter.FormatAsBold(null);

            // Assert
            // Assert.ThrowsException<ArgumentNullException>(act);

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
