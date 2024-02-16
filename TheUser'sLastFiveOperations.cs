using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Serilog;

namespace JSON
{
    internal class TheUser_sLastFiveOperations
    {
        

        public static void Last5OperationsForMultipleFiles(string[] filePaths)
        {
            try
            {

                List<Transaction> allTransactions = new List<Transaction>();

                foreach (string filePath in filePaths)
                {
                    if (!File.Exists(filePath))
                    {
                        Console.WriteLine($"JSON file does not exist: {filePath}");
                        continue;
                    }

                    string jsonString = File.ReadAllText(filePath);
                    testclass testClass = JsonConvert.DeserializeObject<testclass>(jsonString);

                    if (testClass.TransactionHistory == null || testClass.TransactionHistory.Count == 0)
                    {
                        Console.WriteLine($"No transaction history found in file: {filePath}");
                        continue;
                    }

                    allTransactions.AddRange(testClass.TransactionHistory);
                }

                if (allTransactions.Count == 0)
                {
                    Console.WriteLine("No transactions found in any of the files.");
                    return;
                }

                // Sort all transactions by date in descending order
                var sortedTransactions = allTransactions.OrderByDescending(t => t.TransactionDate);

                // Take the first five transactions
                var lastFiveTransactions = sortedTransactions.Take(5);

                Console.WriteLine("Last 5 transactions :");
                foreach (var transaction in lastFiveTransactions)
                {
                    Console.WriteLine($"Date: {transaction.TransactionDate}, Type: {transaction.TransactionType}, Amount: {transaction.Amount}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving the last 5 operations: " + ex.Message);
            }
        }
    }
}

