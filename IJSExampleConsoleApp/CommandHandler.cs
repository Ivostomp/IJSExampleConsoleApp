using IJSExampleConsoleApp.Commands;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace IJSExampleConsoleApp
{
    public class CommandHandler
    {
        private List<Command> _Commands = new List<Command>() {
            new PrimenumberCommand(),
            new PalindromeCommand(),
            new StackCommand(),
            new QueueCommand(),
            new GreatestCommonDivider(),
            new CalculatorCommand(),
        };

        public void RunCommand(string input) {

            var commandText = input.Split(' ').FirstOrDefault();
            var commandInput = input.Replace(commandText, "").Trim();

            var command = _Commands.FirstOrDefault(q => q.Key == commandText);

            if (command == null) {
                Console.WriteLine($"Cannot find command: {commandText}");
                return;
            }

            command.Run(commandInput);

        }

    }
}
