using System;
using System.Globalization;
using System.Threading;

namespace IJSExampleConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var cultureInfo = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;


            Console.WriteLine("Welkom!");
            Console.WriteLine("Please enter a command");

            var commandHandler = new CommandHandler();
            var command = Console.ReadLine();

            while (!command.StartsWith("exit")) {

                if (command == "clear") {
                    Console.Clear();
                    command = Console.ReadLine();
                    continue;
                };

                if (command == "calc 1") {
                    command = "calc -c (9+5*((10+4)/(8-6)))-2";
                }
                else if (command == "calc 2") {
                    command = "calc -c (((2-22.5)*-2+5)*-1*(25/5-7.5))-73";
                }


                commandHandler.RunCommand(command);
                command = Console.ReadLine();
            }

            Console.WriteLine("Bye bye.. please come again...");
            Thread.Sleep(1500);
        }
    }
}