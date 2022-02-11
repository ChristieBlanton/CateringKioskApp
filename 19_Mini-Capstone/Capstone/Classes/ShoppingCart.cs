using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes 
{
    class ShoppingCart :CateringItem
    {
        public ShoppingCart(string productType, string productCode, string productName,
            decimal price, int quantity) : base(productType, productCode, productName, price)
        {
            BuyingQuantity = quantity;
        }

        public int BuyingQuantity { get; set; }
    }
}
