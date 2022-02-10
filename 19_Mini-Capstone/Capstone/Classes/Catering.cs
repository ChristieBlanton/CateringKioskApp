using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Catering
    {
        // This class should contain all the "work" for catering

        private List<CateringItem> items = new List<CateringItem>();

        private FileAccess fileAccess = new FileAccess();

        public void GetMenu()
        {
            List<CateringItem> CI = fileAccess.FileRead();
            foreach (CateringItem item in CI)
            {
                items.Add(item);
            }
        }

        public void DisplayMenu()
        {
            foreach (CateringItem item in items)
            {
                Console.WriteLine($"{item.ProductCode.PadRight(17)}{item.ProductName.PadRight(25)}{item.Quantity.ToString().PadRight(10)}{item.Price:C}");
            }
        }



    }
}
