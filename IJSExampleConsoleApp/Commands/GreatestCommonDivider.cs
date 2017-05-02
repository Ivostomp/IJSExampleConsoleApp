using IJSExampleConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace IJSExampleConsoleApp.Commands
{
    public class GreatestCommonDivider : Command
    {
        public override string Key => "gcd";

        public override Dictionary<string, Subcommand> Subcommands => new Dictionary<string, Subcommand>() {
            { "-d", new Subcommand(){Key = "-d", Description = "Gets greatest common divider", Action = CalculateGCD } },
        };

        public override void Run(string command) => base.Run(command);

        public GreatestCommonDivider() {

        }

        public void CalculateGCD(string input) {

            ConsoleEx.WriteEmptyLine();

            var values = input.Split(' ');

            var numValues = values.Select(q => int.Parse(q)).ToArray();
            
            ConsoleEx.WriteSeperatorLine();
            ConsoleEx.WriteLine($"Calculate GCD of {string.Join(",", numValues)}");
            ConsoleEx.WriteSeperatorLine();

            var gcd = Calculator.GCD(numValues);

            ConsoleEx.WriteLine($"GCD is: {gcd}");
            ConsoleEx.WriteLine($"Ratio is {string.Join(":", numValues.Select(num => num / gcd))}");

            ConsoleEx.WriteEmptyLine();

        }


    }
}
