using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Fundamentals;

namespace TestApp.UnitTests
{
    // TODO: napisz testy jednostkowe do klasy Rent i metody CanReturn()

    [TestClass]
    public class RentTests
    {
        [TestMethod]
        public void CanReturn_UserIsAdmin_ShouldReturnTrue()
        {
            // Arrange
            Rent rent = new Rent();
            User rentee = new User();
            rent.Rentee = rentee;

            // Act
            var result = rent.CanReturn(new User { IsAdmin = true });

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanReturn_UserIsRentee_ShouldReturnTrue()
        {
            // Arrange
            Rent rent = new Rent();
            User rentee = new User();
            rent.Rentee = rentee;

            // Act
            var result = rent.CanReturn(rentee);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanReturn_UserIsNotRentee_ShouldReturnFalse()
        {
            // Arrange
            Rent rent = new Rent();
            User rentee = new User();
            rent.Rentee = rentee;

            // Act
            var result = rent.CanReturn(new User());

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))] // Assert
        public void CanReturn_UserIsEmpty_ShouldThrowArgumentNullException()
        {
            // Arrange
            Rent rent = new Rent();
            User rentee = new User();
            rent.Rentee = rentee;

            // Act
            var result = rent.CanReturn(null);

            // Assert
        }

        [TestMethod]
        public void CanReturn_UserIsEmpty_ShouldThrowArgumentNullException2()
        {
            // Arrange
            Rent rent = new Rent();
            User rentee = new User();
            rent.Rentee = rentee;

            // Act
            Action act = () => rent.CanReturn(null);

            // Assert
            Assert.ThrowsException<ArgumentNullException>(act);

        }
    }
}
