using IJSExampleConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IJSExampleConsoleApp.Commands
{
    public class CalculatorCommand: Command
    {
        public override string Key => "calc";

        public override Dictionary<string, Subcommand> Subcommands {
            get => new Dictionary<string, Subcommand>() {
                { "-c", new Subcommand(){Key = "-c", Description = "calculates input", Action = Calculate } },
                { "-r", new Subcommand(){Key = "-r", Description = "run calculator", Action = RunCalculator } },
                { "run", new Subcommand(){Key = "run", Description = "run calculator", Action = RunCalculator } },
            };
        }

        public override void Run(string command) {
            if (string.IsNullOrWhiteSpace(command)) {

            }



            base.Run(command);
        }

        public CalculatorCommand() {

        }

        public void Calculate(string input) {
            ConsoleEx.WriteEmptyLine();
            ConsoleEx.WriteLine(input);

            var result = Calculator.Calculate(input);

            ConsoleEx.WriteSeperatorLine();
            ConsoleEx.WriteLine($"{input} = {result}");
            ConsoleEx.WriteEmptyLine();
        }

        public void RunCalculator(string input) {
            ConsoleEx.WriteLine("Please enter your sum");
            var command = Console.ReadLine();
            while (!command.StartsWith("exit")) {

                Calculate(command);

                command = Console.ReadLine();
            }
            return;
        }
    }
}
