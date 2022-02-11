using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Catering
    {
        // This class should contain all the "work" for catering

        private List<CateringItem> items = new List<CateringItem>();

        private List<ShoppingCart> shoppingCart = new List<ShoppingCart>();

        private FileAccess fileAccess = new FileAccess();

        
        public Catering()
        {
            List<CateringItem> CI = fileAccess.FileRead();

            foreach (CateringItem item in CI)
            {
                items.Add(item);
            }
            OrganizeList();
        }

        public void OrganizeList()
        {
            List<string> order = new List<string>();

            List<CateringItem> result = new List<CateringItem>();

            foreach (CateringItem item in items)
            {
                order.Add(item.ProductCode);
            }
            order.Sort();
            foreach (string item in order)
            {
                foreach (CateringItem cateringItem in items)
                {
                    if (item == cateringItem.ProductCode)
                    {
                        result.Add(cateringItem);
                        break;
                    }

                }
            }
            items = result;
        }

        public void DisplayMenu()
        {
            foreach (CateringItem item in items)
            {
                Console.WriteLine($"{item.ProductCode.PadRight(17)}{item.ProductName.PadRight(25)}{item.Quantity.ToString().PadRight(10)}{item.Price:C}");
            }
        }

        public decimal ShoppingCart(string inputItem, int inputQuantity, decimal balance)
        {
            foreach (CateringItem item in items)
            {
                if (item.ProductCode == inputItem)
                {
                    if (item.Quantity > inputQuantity && (item.Price * inputQuantity) <= balance)
                    {
                        
                        ShoppingCart test = new ShoppingCart(item.ProductType, item.ProductCode,
                            item.ProductName, item.Price, inputQuantity);
                        shoppingCart.Add(test);
                        item.Quantity -= inputQuantity;
                        return item.Price * inputQuantity;
                    }
                }
            }
            return -1.0m;
        }






        }



    }

