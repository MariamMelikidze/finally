using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON
{
    internal class deposit2
    {
        
        //private static readonly ILogger _logger;
        


        public static void Deposit()
        {
            try
            {
                Console.WriteLine("Starting deposit process.");

                Console.Write("Enter deposit amount:");
                if (!int.TryParse(Console.ReadLine(), out int depositAmount) || depositAmount <= 0)
                {
                    Console.Write("Invalid deposit amount. Please enter a positive integer.");
                    return;
                }
                //_logger.Information("This is an information message.");
                //_logger.Error("This is an error message.");
                

                string filePath = @"C:\Users\us store plus\source\repos\ConsoleApp3\ConsoleApp3\TEST2.JSON";

                if (!File.Exists(filePath))
                {
                    
                    Console.WriteLine("JSON file does not exist.");
                    return;
                }

                string jsonString = File.ReadAllText(filePath);
                testclass testClass = JsonConvert.DeserializeObject<testclass>(jsonString);
                testClass.amount += depositAmount;
                Transaction depositTransaction = new Transaction
                {
                    TransactionDate = DateTime.Now.ToString("yyyy-MM-dd"), 
                    TransactionType = "Deposit",
                    Amount = depositAmount, 
                    AmountUSD = 0, 
                    AmountEUR = 0
                };
                testClass.Amount += depositAmount;

                testClass.TransactionHistory.Add(depositTransaction);
                string updatedJsonString = JsonConvert.SerializeObject(testClass, Formatting.Indented);
                File.WriteAllText(filePath, updatedJsonString);
                Console.WriteLine("Deposit successful.");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while processing the deposit: " + ex.Message);
            }
   
    }   }
}

