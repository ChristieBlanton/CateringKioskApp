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
            Console.WriteLine();
            Console.WriteLine("(1) Add Money");
            Console.WriteLine("(2) Select Products");
            Console.WriteLine("(3) Complete Transaction");
            Console.WriteLine("Current Account Balance: " + money.Balance);
            Console.WriteLine();
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
                        CompleteTransaction();
                        done = true;
                        Environment.Exit(0);
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
                            Console.WriteLine($"Your current balance is: {money.Balance.ToString("C")}");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine($"The maximum balance is $1500. Your current balance is: {money.Balance.ToString("C")}");
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
            CateringMenu();

            Console.WriteLine();
            Console.WriteLine("Please select the item code: ");

            string inputItem = Console.ReadLine();
            int inputQuantity = 0;
            Console.WriteLine("Please select a quantity: ");
            try
            {
                 inputQuantity = int.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Please enter a valid quantity." + ex.Message);
                Console.WriteLine();
                SelectProducts();
            }
           
            
            decimal result = catering.ShoppingCart(inputItem, inputQuantity, money.Balance);
            
            switch (result)
            {
                case -1:
                    Console.WriteLine("An error occured with processing. Please try again.");
                    Console.WriteLine();
                    break;
                case -2:
                    Console.WriteLine("Please select a valid code.");
                    Console.WriteLine();
                    break;
                case -3:
                    Console.WriteLine("This item is SOLD OUT.");
                    Console.WriteLine();
                    break;
                case -4:
                    Console.WriteLine("There is insufficient stock for the quantity requested.");
                    Console.WriteLine();
                    break;
                case -5:
                    Console.WriteLine("There are insufficient funds for the requested purchase.");
                    Console.WriteLine();
                    break;
                default:
                    Console.WriteLine("Item was added to the cart.");
                    Console.WriteLine();
                    money.SubtractMoney(result);
                    break;
            }
            OrderMenu();
        }

        public void CompleteTransaction()
        {
            catering.Receipt();
            Console.WriteLine();

            Dictionary<string, int> change = money.MakeChange(money.Balance);
            money.SubtractMoney(money.Balance);
            Console.Write("You received ");
            foreach (KeyValuePair<string, int> kvp in change)
            {
                if (kvp.Value > 0)
                {
                    Console.Write($"({kvp.Value}) {kvp.Key}   ");
                }
            }
            Console.WriteLine(" in change");
            Console.WriteLine();
            RunInterface();
        }
    }
}
