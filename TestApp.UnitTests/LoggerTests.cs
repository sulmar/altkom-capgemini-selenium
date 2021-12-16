using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Fundamentals;

namespace TestApp.UnitTests
{

    [TestClass]
    public class LoggerTests
    {
        // Method_Scenario_ExpectedBehavior

        private const string NotEmptyMessage = "a";
        private readonly string EmptyMessage = string.Empty;
        private const string WhitespaceMessage = " ";

        private Logger logger;

        [TestInitialize]
        public void Setup()
        {
            // Arrange
            logger = new Logger();
        }

        [TestMethod]
        public void Log_NotEmptyMessage_ShouldSetLastMessage()
        {
            // Act
            logger.Log(NotEmptyMessage);

            // Assert
            Assert.AreEqual(NotEmptyMessage, logger.LastMessage);
        }

        [TestMethod]
        public void Log_EmptyMessage_ShouldThrowArgumentNullException()
        {
            // Act
            Action act = ()=> logger.Log(EmptyMessage);

            // Assert
            Assert.ThrowsException<ArgumentNullException>(act);
            
        }

        [TestMethod]
        public void Log_WhitespaceMessage_ShouldThrowArgumentNullException()
        {
            // Act
            Action act = () => logger.Log(WhitespaceMessage);

            // Assert
            Assert.ThrowsException<ArgumentNullException>(act);
        }

        [TestMethod]
        public void Log_NullMessage_ShouldThrowArgumentNullException()
        {
            // Act
            Action act = () => logger.Log(null);

            // Assert
            Assert.ThrowsException<ArgumentNullException>(act);
        }

        [TestMethod]
        public void Log_NotEmptyMessage_ShouldRaiseMessageLoggedEvent()
        {
            // Arrange
            DateTime logDate = DateTime.MinValue;
            logger.MessageLogged += (sender, args) => { logDate = args; };

            // Act
            logger.Log(NotEmptyMessage);

            // Assert
            Assert.AreNotEqual(DateTime.MinValue, logDate);
        }
    }
}
