using JSON;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Serilog;
using System;
using System.IO;

internal class Program

{
    
    static testclass testClass;

    static void Main(string[] args)
    {
        string logFilePath = @"C:\Users\us store plus\source\repos\ConsoleApp3\ConsoleApp3\text.txt"; // Specify your desired log file path

        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(logFilePath, rollingInterval: RollingInterval.Day)
            .CreateLogger();

        //CreateHostBuilder(args).Build().Run();
        //var configuration = new ConfigurationBuilder()
        //.SetBasePath(AppContext.BaseDirectory)
        //.AddJsonFile("appsettings.json")
        //.Build();

        //Log.Logger = new LoggerConfiguration()
        //    .ReadFrom.Configuration(configuration)
        //    .CreateLogger();

        

        //try
        //{
        //     CreateHostBuilder(args).Build().Run();
        //}
        //catch (Exception ex)
        //{
        //    Log.Fatal(ex, "Application failed");
        //}
        //finally
        //{
        //    Log.CloseAndFlush();
        //}
        string filePath = @"C:\Users\us store plus\source\repos\ConsoleApp3\ConsoleApp3\TEST.JSON";

        Console.WriteLine("Enter your card number: ");
        int enteredcardNumber;
        if (!int.TryParse(Console.ReadLine(), out enteredcardNumber))
        {
            Console.WriteLine("Invalid card number format.");
            return;
        }

        try
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string stringContent = sr.ReadToEnd();
                testClass = JsonConvert.DeserializeObject<testclass>(stringContent);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message,  "An error occurred while reading JSON file.");
            return;
        }

        if (testClass.CardDetails == null)
        {
            Console.WriteLine("Invalid card details. Try again.");
            return;
        }

        if (testClass.CardDetails.CardNumber != enteredcardNumber)
        {
            Console.WriteLine("Invalid card number. Try again.");
            return;
        }

        if (testClass.CardDetails.ExpirationDate < DateTime.Now)
        {
            Console.WriteLine("The card has expired.");
            return;
        }

        Console.WriteLine("The card is valid.");
        Console.WriteLine("Enter your CVC: ");
        if (!int.TryParse(Console.ReadLine(), out int enteredCVC))
        {
            Console.WriteLine("Invalid CVC format.");
            return;
        }

        if (testClass.CardDetails.CVC != enteredCVC.ToString())
        {
            Console.WriteLine("The card CVC is not correct");
            return;
        }

        Console.WriteLine("You have been successfully verified!");

        // Call MyMethod in Class1
        Class1 class1Instance = new Class1();
        bool successfulVerification = true;
        class1Instance.MyMethod(successfulVerification);

        // Add new transaction to the testclass object
        AddTransaction();

        // Serialize the testclass object back to JSON and write it to the file
        try
        {
            string updatedJsonString = JsonConvert.SerializeObject(testClass, Formatting.Indented);
            File.WriteAllText(filePath, updatedJsonString);
            Console.WriteLine("Transaction added to transaction history.");
        }
        catch (Exception ex)
        {
            Console.WriteLine( "An error occurred while writing to JSON file.");
        }
        CreateHostBuilder(args).Build().Run();
    }

    static void AddTransaction()
    {
        // Create a new Transaction object
        Transaction newTransaction = new Transaction
        {
            TransactionDate = DateTime.Now.ToString("yyyy-MM-dd"),
            TransactionType = "SomeTransactionType",
            Amount = 100,
            AmountUSD = 0,
            AmountEUR = 0
        };

        // Add the new transaction to the transaction history list
        testClass.TransactionHistory.Add(newTransaction);
    }
    static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .UseSerilog();
    

}

