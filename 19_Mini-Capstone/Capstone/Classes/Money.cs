using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    
    public class Money
    {
        public decimal Balance { get; private set; } = 0.00M;

        FileAccess file = new FileAccess();

        public bool AddMoney(string cash)
        {
            if (Balance + int.Parse(cash) > 1500)
            {
                return false;
            }
            else
            {
              
                Balance += int.Parse(cash);
                string line = $"Add Money: ${cash} {Balance.ToString("C")}";
                file.LogWriter(line);
                return true;
            }
        }

        public void SubtractMoney(decimal amount)
        {
            Balance -= amount;
        }

        public Dictionary<string, int> MakeChange(decimal balance)
        {
            Dictionary<string, int> change = new Dictionary<string, int>();
            file.LogWriter($"GIVE CHANGE: {balance.ToString("C")} $0.00");
            string totalBalance = balance.ToString();
            string[] currency = totalBalance.Split(".");
            int coins = int.Parse(currency[1]);
            if (balance % 50 >= 0)
            {
                int fifties = (int)(balance / 50);
                balance -= fifties * 50;
                change.Add("Fifties", fifties);
            }
            if (balance % 20 >= 0)
            {
                int twenties = (int)(balance / 20);
                balance -= twenties * 20;
                change.Add("Twenties", twenties);
            }
            if (balance % 10 >= 0)
            {
                int tens = (int)(balance / 10);
                balance -= tens * 10;
                change.Add("Tens", tens);
            }
            if (balance % 5 >= 0)
            {
                int fives = (int)(balance / 5);
                balance -= fives * 5;
                change.Add("Fives", fives);
            }
            if (balance % 1 >= 0)
            {
                int ones = (int)(balance / 1);
                balance -= ones;
                change.Add("Ones", ones);
            }

            if (coins % 25 >= 0)
            {
                int quarters = coins / 25;
                coins -= quarters * 25;
                change.Add("Quarters", quarters);
            }
            if (coins % 10 >= 0)
            {
                int dimes = coins / 10;
                coins -= dimes * 10;
                change.Add("Dimes", dimes);
            }
            if (coins % 5 >= 0)
            {
                int nickles = coins / 5;
                coins -= nickles * 5;
                change.Add("Nickles", nickles);
            }

            return change;
        }

    }

    //public void 
}

