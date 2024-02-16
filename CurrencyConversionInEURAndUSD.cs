using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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

                double euroRate = 0.86;
                double dollarRate = 1.12;

                foreach (var transaction in testClass.TransactionHistory)
                {
                    double balanceInEuro = Math.Round(transaction.Amount * euroRate, 2);
                    double balanceInDollar = Math.Round(transaction.Amount * dollarRate, 2);
                    transaction.AmountEUR = (int)balanceInEuro;
                    transaction.AmountUSD = (int)balanceInDollar;

                    Console.WriteLine($"Balance in Euro: {balanceInEuro}");
                    Console.WriteLine($"Balance in Dollar: {balanceInDollar}");
                }

                string updatedJsonString = JsonConvert.SerializeObject(testClass, Formatting.Indented);
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



