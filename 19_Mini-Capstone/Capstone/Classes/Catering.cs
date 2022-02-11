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
                if (item.ProductCode == inputItem.ToUpper())
                {
                    if (item.Quantity >= inputQuantity && (item.Price * inputQuantity) <= balance)
                    {

                        ShoppingCart test = new ShoppingCart(item.ProductType, item.ProductCode,
                            item.ProductName, item.Price, inputQuantity);
                        shoppingCart.Add(test);
                        item.Quantity -= inputQuantity;
                        fileAccess.LogWriter($"{inputQuantity} {item.ProductName} {item.ProductCode} ${item.Price * inputQuantity} ${balance - (item.Price * inputQuantity)}");
                        return item.Price * inputQuantity;
                    }
                    else if (item.Quantity == 0)
                    {
                        //sold out
                        return -3;
                    }
                    else if (inputQuantity > item.Quantity)
                    {
                        //insufficient stock
                        return -4;
                    }
                    else if (balance < inputQuantity * item.Price)
                    {
                        //insufficient funds
                        return -5;
                    }
                }

            }
            return -2;
        }

        public void Receipt()
        {
            decimal total = 0;

            foreach (ShoppingCart item in shoppingCart)
            {
                total += (item.BuyingQuantity * item.Price);
                if (item.ProductType.Equals("A"))
                {
                    Console.WriteLine($"{item.BuyingQuantity.ToString().PadRight(5)} Appetizer    {item.ProductName.PadRight(25)} {item.Price.ToString("C").PadLeft(10)} {(item.BuyingQuantity * item.Price).ToString("C").PadLeft(10)}   You might need extra plates.");
                }
                else if (item.ProductType.Equals("B"))
                {
                    Console.WriteLine($"{item.BuyingQuantity.ToString().PadRight(5)} Beverage     {item.ProductName.PadRight(25)} {item.Price.ToString("C").PadLeft(10)} {(item.BuyingQuantity * item.Price).ToString("C").PadLeft(10)}   Don't forget ice.");
                }
                else if (item.ProductType.Equals("D"))
                {
                    Console.WriteLine($"{item.BuyingQuantity.ToString().PadRight(5)} Dessert      {item.ProductName.PadRight(25)} {item.Price.ToString("C").PadLeft(10)} {(item.BuyingQuantity * item.Price).ToString("C").PadLeft(10)}   Coffee goes with dessert.");
                }
                else if (item.ProductType.Equals("E"))
                {
                    Console.WriteLine($"{item.BuyingQuantity.ToString().PadRight(5)} Entree       {item.ProductName.PadRight(25)} {item.Price.ToString("C").PadLeft(10)} {(item.BuyingQuantity * item.Price).ToString("C").PadLeft(10)}   Did you remember dessert?");
                }
            }
            Console.WriteLine();
            Console.WriteLine($"TOTAL: ${total}");
        }




    }
}





