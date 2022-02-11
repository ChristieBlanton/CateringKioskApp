using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class CateringItem
    {
        // This class should contain the definition for one catering item
        public CateringItem(string productType, string productCode, string productName, 
            decimal price  )
        {
            ProductType = productType;
            ProductCode = productCode;
            ProductName = productName;
            Price = price;
            Quantity = 25;
        }

        public string ProductType { get; private set; }

        public string ProductCode { get; private set; }

        public string ProductName { get; private set; }

        public decimal Price { get; private set; }

        public int Quantity { get; set; } 
    }
}
