using Bupa.Bupa.Tests.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bupa.Bupa.Tests
{
    [TestClass]
    public class PowerFactoryTests
    {
        [TestMethod]
        public void Create_ValidTitleCodes_ReturnValue()
        {
            PowerFactory powerFactory = new PowerFactory();

            var result = powerFactory.Create(TitleCodes.Miss);

            Assert.AreEqual(200, result);
        }
    }
}
