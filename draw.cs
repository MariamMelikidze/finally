using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON
{
    internal class Draw
    {
        

        public static void Withdraw()
        {
            try
            {

                Console.WriteLine("Enter withdrawal amount:");
                if (!int.TryParse(Console.ReadLine(), out int withdrawalAmount) || withdrawalAmount <= 0)
                {
                    Console.WriteLine("Invalid withdrawal amount. Please enter a positive integer.");
                    return;
                }

                string filePath = @"C:\Users\us store plus\source\repos\ConsoleApp3\ConsoleApp3\TEST4.JSON";
                string jsonString = File.ReadAllText(filePath);
                testclass testClass = JsonConvert.DeserializeObject<testclass>(jsonString);

                if (testClass.amount < withdrawalAmount)
                {
                    Console.WriteLine("Insufficient balance for withdrawal.");
                    return;
                }

                // Create a new withdrawal transaction
                Transaction withdrawalTransaction = new Transaction
                {
                    TransactionDate = DateTime.Now.ToString("yyyy-MM-dd"),
                    TransactionType = "Withdrawal",
                    Amount = withdrawalAmount,
                    AmountUSD = 0,
                    AmountEUR = 0
                };

                // Add the withdrawal transaction to the transaction history list
                testClass.TransactionHistory.Add(withdrawalTransaction);

                // Update the account balance
                testClass.amount -= withdrawalAmount;

                // Serialize the updated testClass object back to JSON
                string updatedJsonString = JsonConvert.SerializeObject(testClass, Formatting.Indented);

                // Write the updated JSON string to the file
                File.WriteAllText(filePath, updatedJsonString);

                Console.WriteLine("Withdrawal successful.");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while processing the withdrawal: " + ex.Message);
            }
        }
    }


}
