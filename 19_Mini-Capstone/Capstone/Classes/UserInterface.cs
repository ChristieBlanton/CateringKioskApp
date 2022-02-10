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

        public FileAccess fileAccess = new FileAccess();

        private List<CateringItem> catItems = new List<CateringItem>();

        

        fileAccess.FileRead();
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

        }

        public void OrderMenu()
        {

        }
    }
}
