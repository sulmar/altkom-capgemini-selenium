using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestApp.Fundamentals;

namespace TestApp.UnitTests
{
    [TestClass]
    public class RentTests
    {
        private Rent rent;
        private User rentee;

        [TestInitialize]
        public void Setup()
        {
            // Arrange            
            rentee = new User();
            rent = new Rent { Rentee = rentee };            
        }

        [TestMethod]
        public void CanReturn_UserIsAdmin_ShouldReturnTrue()
        {
            // Act
            var result = rent.CanReturn(new User { IsAdmin = true });

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanReturn_UserIsRentee_ShouldReturnTrue()
        {
            // Act
            var result = rent.CanReturn(rentee);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanReturn_UserIsNotRentee_ShouldReturnFalse()
        {
            // Act
            var result = rent.CanReturn(new User());

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))] // Assert
        public void CanReturn_UserIsEmpty_ShouldThrowArgumentNullException()
        {
            // Act
            var result = rent.CanReturn(null);

            // Assert
        }

        [TestMethod]
        public void CanReturn_UserIsEmpty_ShouldThrowArgumentNullException2()
        {
            // Act
            Action act = () => rent.CanReturn(null);

            // Assert
            Assert.ThrowsException<ArgumentNullException>(act);

        }
    }
}
