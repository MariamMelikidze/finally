using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON
{
    internal class Check
    {

        public static void CheckBalance()
        {
            try
            {

                string filePath = @"C:\Users\us store plus\source\repos\ConsoleApp3\ConsoleApp3\TEST.JSON";

                if (!File.Exists(filePath))
                {
                    Console.WriteLine("JSON file does not exist.");
                    return;
                }

                string jsonString = File.ReadAllText(filePath);
                Transaction testClass = JsonConvert.DeserializeObject<Transaction>(jsonString);

                int balance = testClass.Amount;
                Console.WriteLine($"Your balance: {balance}");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while checking balance: " + ex.Message);
            }
        }
    }
}   

