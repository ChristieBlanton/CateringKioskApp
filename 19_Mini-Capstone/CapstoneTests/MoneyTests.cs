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
        public void AddMoneyTest()
        {
            Money money = new Money();
            money.AddMoney("100");


            Assert.AreEqual(100, money.Balance);

            bool result = money.AddMoney("1501");

            Assert.AreEqual(false, result);
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
            Capstone.Money money = new Money();
            Dictionary<string, int> test = new Dictionary<string, int>();
            test.Add("Fifties", 10);
            test.Add("Twenties", 1);
            test.Add("Tens", 1);
            test.Add("Fives", 1);
            test.Add("Ones", 4);
            test.Add("Quarters", 3);
            test.Add("Dimes", 1);
            test.Add("Nickles", 1);

            Dictionary<string, int> result = money.MakeChange(539.90m);

            CollectionAssert.AreEquivalent(test, result);
        }
    }
}
