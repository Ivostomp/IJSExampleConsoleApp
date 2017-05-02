using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace IJSExampleConsoleApp.Commands
{
    public class PalindromeCommand : Command {
        public override string Key {
            get => "palin";
        }

        public override Dictionary<string, Subcommand> Subcommands {
            get => new Dictionary<string, Subcommand>() {
                { "-c", new Subcommand(){Key = "-c", Description = "checks if word is a palindrome", Action = IsPalindrome } }
            };
        }

        public override void Run(string command) => base.Run(command);

        private void IsPalindrome(string input) {
            ConsoleEx.WriteEmptyLine();
            input = input.ToLower();
            var reverseInput = string.Join("", input.ToCharArray().Reverse());

            var areEqual = (input == reverseInput);
            var msg = areEqual ? "" : "NOT " ;

            ConsoleEx.WriteSeperatorLine();
            ConsoleEx.WriteLine($"{input} is {msg}a palindrome");
            ConsoleEx.WriteSeperatorLine();
        }
    }
}
