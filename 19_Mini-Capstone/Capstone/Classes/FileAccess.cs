using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class FileAccess
    {
         // all files for this application should in this directory
        // you will likley need to create it on your computer
        string filePath = @"C:\Catering\cateringsystem.csv";
        public List<CateringItem> FileRead()
        {
            List<CateringItem> cateringItems = new List<CateringItem>();
            try 
            {
                using(StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();

                        string[] lineSplit = line.Split("|");

                        CateringItem CI = new CateringItem(lineSplit[0], lineSplit[1], 
                            lineSplit[2], Decimal.Parse(lineSplit[3]));

                        cateringItems.Add(CI);
                        
                    }   
                }
            }

            catch(IOException ex)
            {
                Console.WriteLine("Error reading the file" + ex.Message);
            }
            return cateringItems;
        }
        
        
        
    




        

        // This class should contain any and all details of access to files
    }
}
