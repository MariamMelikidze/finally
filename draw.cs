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

                if (testClass.Amount < withdrawalAmount)
                {
                    Console.WriteLine("Insufficient balance for withdrawal.");
                    return;
                }

                
                Transaction withdrawalTransaction = new Transaction
                {
                    TransactionDate = DateTime.Now.ToString("yyyy-MM-dd"),
                    TransactionType = "Withdrawal",
                    Amount = withdrawalAmount,
                    AmountUSD = 0,
                    AmountEUR = 0
                };

                
                testClass.TransactionHistory.Add(withdrawalTransaction);

                testClass.Amount -= withdrawalAmount;

                string updatedJsonString = JsonConvert.SerializeObject(testClass, Formatting.Indented);

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
