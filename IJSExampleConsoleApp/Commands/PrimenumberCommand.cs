using IJSExampleConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IJSExampleConsoleApp.Commands {
    public class PrimenumberCommand : Command {
        public override string Key {
            get => "prime";
        }

        public override Dictionary<string, Subcommand> Subcommands {
            get => new Dictionary<string, Subcommand>() {
                    { "-l",  new Subcommand(){ Key = "-l", Description = "List all prime numbers to given value", Action = ListPrimeNumbersTo } },
                    { "-c", new Subcommand(){Key = "-c", Description = "Calculates if given number is a prime number", Action = IsPrimeNumber } }
                };
        }

        public override void Run(string command) => base.Run(command);

        private void ListPrimeNumbersTo(string input) {
            ConsoleEx.WriteEmptyLine();
            if(!int.TryParse(input, out int number)) {
                Console.WriteLine($"input ({input}) is not a number...");
                return;
            }

            var primenumbers = new List<PrimeNumber>();
            for (var i = number; i > 0; i--) {
                var primenumber = new PrimeNumber(i);

                if (primenumber.IsPrimenumber)
                    primenumbers.Add(primenumber);
            }

            primenumbers.ForEach(pn => {
                Console.WriteLine(pn.Value);
            });

            ConsoleEx.WriteSeperatorLine();
            ConsoleEx.WriteLine($"{primenumbers.Count} primenumbers to {number}");
            ConsoleEx.WriteSeperatorLine();
            ConsoleEx.WriteEmptyLine();
        }

        private void IsPrimeNumber(string input) {
            ConsoleEx.WriteEmptyLine();
            if (!int.TryParse(input, out int number)) {
                Console.WriteLine($"input ({input}) is not a number...");
                return;
            }

            var primenumber = new PrimeNumber(number);
            var msg = primenumber.IsPrimenumber ? "is a prime number" : "is NOT a prime number";

            ConsoleEx.WriteSeperatorLine();
            ConsoleEx.WriteLine($"number {number} {msg}");
            ConsoleEx.WriteLine($"{number} is divisible by {primenumber.Options.Length} options ({string.Join(", ", primenumber.Options)})");
            ConsoleEx.WriteSeperatorLine();
            ConsoleEx.WriteEmptyLine();
        }
    }
}
