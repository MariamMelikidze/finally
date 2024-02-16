using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON
{
    internal class Another
    {
        

        public void SomeMethod()
        {
            try
            {

                string[] filePaths = new string[]
                {
                    @"C:\Users\us store plus\source\repos\ConsoleApp3\ConsoleApp3\TEST2.JSON",
                    @"C:\Users\us store plus\source\repos\ConsoleApp3\ConsoleApp3\TEST3.JSON",
                    @"C:\Users\us store plus\source\repos\ConsoleApp3\ConsoleApp3\TEST4.JSON",
                    @"C:\Users\us store plus\source\repos\ConsoleApp3\ConsoleApp3\TEST.JSON"
                };

                TheUser_sLastFiveOperations.Last5OperationsForMultipleFiles(filePaths);

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}

