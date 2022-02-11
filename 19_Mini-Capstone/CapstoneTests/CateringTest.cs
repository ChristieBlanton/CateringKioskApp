using Capstone;
using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
        [TestMethod]
        public void MakeChangeTest()
        {
            Money money = new Money();
            Dictionary<string, int> test = new Dictionary<string, int>();
            test.Add("Fifties", 4 );
            test.Add("Twenties", 2);

            Dictionary<string, int> result = money.MakeChange(240);

            CollectionAssert.AreEquivalent(test, result);
        }
    }

    
    
}
