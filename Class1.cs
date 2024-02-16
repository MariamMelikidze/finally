using JSON.JSON;
using Serilog;
using Serilog.Events;

namespace JSON
{
    public class Class1
    {
        

        public bool SuccessfulVerification { get; internal set; }

        public void MyMethod(bool successfulVerification)
        {
            if (!successfulVerification)
            {
                Console.WriteLine("Verification failed. Exiting...");
                return;
            }

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1. Change your pin");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Check Balance");
                Console.WriteLine("5. Currency conversion");
                Console.WriteLine("6. Last 5 operations");
                Console.WriteLine("7. Exit");
                Console.WriteLine("Enter your choice:");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Change.ChangeYourPin();
                            break;
                        case 2:
                            deposit2.Deposit();
                            break;
                        case 3:
                            Draw.Withdraw();
                            break;
                        case 4:
                            Check.CheckBalance();
                            break;
                        case 5:
                            CurrencyConversionInEURAndUSD.CurrencyConversion(@"C:\Users\us store plus\source\repos\ConsoleApp3\ConsoleApp3\TEST.JSON");
                            break;
                        case 6:
                            string[] filePaths = new string[]
                            {
                                @"C:\Users\us store plus\source\repos\ConsoleApp3\ConsoleApp3\TEST2.JSON",
                                @"C:\Users\us store plus\source\repos\ConsoleApp3\ConsoleApp3\TEST3.JSON",
                                @"C:\Users\us store plus\source\repos\ConsoleApp3\ConsoleApp3\TEST4.JSON",
                                @"C:\Users\us store plus\source\repos\ConsoleApp3\ConsoleApp3\TEST.JSON"
                            };
                            TheUser_sLastFiveOperations.Last5OperationsForMultipleFiles(filePaths);
                            break;
                        case 7:
                            exit = true;
                            Console.WriteLine("Exiting the application. Goodbye!");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }
    }
}








