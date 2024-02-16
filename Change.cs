using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace JSON
{
    internal class Change
    {
        

        public static void ChangeYourPin()
        {
            try
            {

                Console.WriteLine("Enter your previous pin:");
                if (!int.TryParse(Console.ReadLine(), out int previousPin))
                {
                    Console.WriteLine("Invalid input. Please enter a valid pin.");
                    return;
                }

                Console.WriteLine("Enter your new pin:");
                if (!int.TryParse(Console.ReadLine(), out int newPin))
                {
                    Console.WriteLine("Invalid input. Please enter a valid pin.");
                    return;
                }

                string filePath = @"C:\Users\us store plus\source\repos\ConsoleApp3\ConsoleApp3\TEST3.JSON";

                if (!File.Exists(filePath))
                {
                    Console.WriteLine("JSON file does not exist.");
                    return;
                }

                string jsonString = File.ReadAllText(filePath);
                testclass testClass = JsonConvert.DeserializeObject<testclass>(jsonString);
                testClass.PIN = newPin;
                string updatedJsonString = JsonConvert.SerializeObject(testClass, Formatting.Indented);
                File.WriteAllText(filePath, updatedJsonString);

                Console.WriteLine("Pin has been updated successfully.");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating the PIN in the JSON file: " + ex.Message);
            }
        }
    }

}








