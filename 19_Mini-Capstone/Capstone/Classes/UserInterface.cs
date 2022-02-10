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

        public void RunInterface()
        {
            catering.GetMenu();
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
            bool done = false;
            while (!done)
            {
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        //AddMoney();
                        break;
                    case "2":
                        //SelectProducts();
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
    }
}
