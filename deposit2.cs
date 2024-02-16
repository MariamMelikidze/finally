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

                // Read existing JSON content
                string jsonString = File.ReadAllText(filePath);
                testclass testClass = JsonConvert.DeserializeObject<testclass>(jsonString);

                // Add the deposit amount to the current balance
                testClass.amount += depositAmount;

                // Create a new Transaction object for the deposit
                Transaction depositTransaction = new Transaction
                {
                    TransactionDate = DateTime.Now.ToString("yyyy-MM-dd"), // Set transaction date to current date
                    TransactionType = "Deposit", // Set transaction type to deposit
                    Amount = depositAmount, // Set the deposit amount
                    AmountUSD = 0, // If needed, set other currency amounts
                    AmountEUR = 0
                };

                // Add the deposit transaction to the transaction history list
                testClass.TransactionHistory.Add(depositTransaction);

                // Serialize the updated testClass object back to JSON
                string updatedJsonString = JsonConvert.SerializeObject(testClass, Formatting.Indented);

                // Write the updated JSON string to the file, overwriting the existing content
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

