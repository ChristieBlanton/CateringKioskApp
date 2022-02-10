using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Money
    {
        public decimal Balance { get; private set; } = 0;

        public bool AddMoney(string cash)
        {
            if (Balance + int.Parse(cash) > 1500)
            {
                return false;
            }
            else
            {
                Balance += int.Parse(cash);
                return true;
            }
        }
    }

    //public void 
}

