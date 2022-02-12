using Capstone;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class MoneyTests
    {
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
            Capstone.Money money = new Money();
            Dictionary<string, int> test = new Dictionary<string, int>();
            test.Add("Fifties", 4);
            test.Add("Twenties", 2);

            Dictionary<string, int> result = money.MakeChange(240);

            CollectionAssert.AreEquivalent(test, result);
        }
    }
}
