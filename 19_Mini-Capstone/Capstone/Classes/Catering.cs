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

        }



    }
}
