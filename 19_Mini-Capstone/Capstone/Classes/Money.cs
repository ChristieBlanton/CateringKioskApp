using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    
    public class Money
    {
        public decimal Balance { get; private set; } 

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
                string line = $"Add Money: ${cash}.00 ${Balance}";
                file.LogWriter(line);
                return true;
            }
        }

        public void SubtractMoney(decimal amount)
        {
            Balance -= amount;
        }

        //public Dictionary<string, int> MakeChange(decimal balance)
        //{
        //    if (balance >= 50)
        //    {

        //    }
            
        //}
       
    }

    //public void 
}

