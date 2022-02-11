using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class UserInterface
    {
        // This class provides all user communications, but not much else.
        // All the "work" of the application should be done elsewhere

        // ALL instances of Console.ReadLine and Console.WriteLine should 
        // be in this class.
        // NO instances of Console.ReadLine or Console.WriteLIne should be
        // in any other class.

        private Catering catering = new Catering();
        private Money money = new Money();

        public void RunInterface()
        {

            bool done = false;
            while (!done)
            {
                MainMenu();

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CateringMenu();
                        break;
                    case "2":
                        OrderMenu();
                        break;
                    case "3":
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid choice.");
                        break;

                }
            }

        }
        public void MainMenu()
        {
            Console.WriteLine("(1) Display Catering Items");
            Console.WriteLine("(2) Order");
            Console.WriteLine("(3) Quit");
        }

        public void CateringMenu()
        {
            string code = "Product Code";
            string description = "Description";
            string quantity = "Qty";
            string price = "Price";
            Console.WriteLine($"{code.PadRight(17)}{description.PadRight(25)}{quantity.PadRight(10)}{price}");
            catering.DisplayMenu();
            Console.WriteLine();
            Console.WriteLine();
        }

        public void OrderMenu()
        {
            Console.WriteLine("(1) Add Money");
            Console.WriteLine("(2) Select Products");
            Console.WriteLine("(3) Complete Transaction");
            Console.WriteLine("Current Account Balance: " + money.Balance);
            bool done = false;
            while (!done)
            {
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddMoney();
                        break;
                    case "2":
                        SelectProducts();

                        break;
                    case "3":
                        //CompleteTransaction();
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid choice.");
                        break;

                }
            }
        }

        public void AddMoney()
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine("Please the denomination of money you'd like to add (1, 5, 10, etc.)");
                Console.WriteLine("Or press Q to return to previous menu.");
                string cash = Console.ReadLine();
                switch (cash)
                {
                    case "1":
                    case "5":
                    case "10":
                    case "20":
                    case "50":
                    case "100":
                        if (money.AddMoney(cash))
                        {
                            Console.WriteLine($"Your current balance is: {money.Balance:C}");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine($"The maximum balance is $1500. Your current balance is: {money.Balance:C}");
                            Console.WriteLine();

                        }
                        break;
                    case "q":
                    case "Q":
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid denomination.");
                        break;

                }
            }
            OrderMenu();
        }
        public void SelectProducts()
        {
            catering.DisplayMenu();

            Console.WriteLine();
            Console.WriteLine("Please select the item code: ");

            string inputItem = Console.ReadLine();

            Console.WriteLine("Please select a quantity: ");

            int inputQuantity = int.Parse(Console.ReadLine());

            if(catering.ShoppingCart(inputItem, inputQuantity) == -1.0m)
            {
                Console.WriteLine("Unable to process order.");
            }
            else
            {
                money.SubtractMoney(catering.ShoppingCart(inputItem, inputQuantity));
            }
            
               

            OrderMenu();
        }
    }
}
