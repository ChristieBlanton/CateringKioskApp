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

        public void ShoppingCartTest()
        {
            Catering testCatering = new Catering();
            Money testMoney = new Money();
            decimal result = testCatering.ShoppingCart("A2", 2, 0m);

            Assert.AreEqual(-5 , result);

            result = testCatering.ShoppingCart("A2", 26, 1500m);

            Assert.AreEqual(-4, result);

            testCatering.ShoppingCart("A2",25, 1500m );
            result = testCatering.ShoppingCart("A2", 1, 1500);

            Assert.AreEqual(-3, result);

            result = testCatering.ShoppingCart("D1",3,100);

            Assert.AreEqual(7.65m, result);


            

        }




    }



}
