using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace JSON
{
    using Serilog;
    using System;
    using System.IO;
    using Newtonsoft.Json;

    namespace JSON
    {
        internal class CurrencyConversionInEURAndUSD
        {
           

            public static void CurrencyConversion(string filePath)
            {
                try
                {
                    

                    if (!File.Exists(filePath))
                    {
                        Console.WriteLine("JSON file does not exist.");
                        return;
                    }

                    string jsonString = File.ReadAllText(filePath);
                    testclass testClass = JsonConvert.DeserializeObject<testclass>(jsonString);

                    // Convert balance to Euro and Dollar using conversion rates
                    double euroRate = 0.86;  // 1 Lari = 0.86 Euro
                    double dollarRate = 1.12;  // 1 Lari = 1.12 Dollar

                    foreach (var transaction in testClass.TransactionHistory)
                    {
                        // Calculate the amount in Euro and Dollar for each transaction
                        double balanceInEuro = transaction.Amount * euroRate;
                        double balanceInDollar = transaction.Amount * dollarRate;

                        // Update the AmountEUR and AmountUSD properties of the transaction
                        transaction.AmountEUR = (int)balanceInEuro;
                        transaction.AmountUSD = (int)balanceInDollar;

                        Console.WriteLine($"Balance in GEL: {transaction.Amount}");
                        Console.WriteLine($"Balance in Euro: {balanceInEuro}");
                        Console.WriteLine($"Balance in Dollar: {balanceInDollar}");
                    }

                    // Serialize the updated testClass object back to JSON
                    string updatedJsonString = JsonConvert.SerializeObject(testClass, Formatting.Indented);

                    // Write the updated JSON string to the file
                    File.WriteAllText(filePath, updatedJsonString);

                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine("File not found: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while converting and updating balance: " + ex.Message);
                }
            }
        }
    }

}


