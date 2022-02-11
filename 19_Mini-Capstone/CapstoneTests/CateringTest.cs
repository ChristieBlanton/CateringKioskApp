using Capstone;
using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class CateringTest
    {
        [TestMethod]
        public void Check_that_catering_object_is_created()
        {
            // Arrange 
            Catering catering = new Catering();

            // Act

            //Assert
            Assert.IsNotNull(catering);
        }
        [TestMethod]
        public void SubtractMoneyTest()
        {
            Money money = new Money();
            money.AddMoney("100");
            money.SubtractMoney(50m);

            Assert.AreEqual(50, money.Balance);


        }
    }

    
    
}
