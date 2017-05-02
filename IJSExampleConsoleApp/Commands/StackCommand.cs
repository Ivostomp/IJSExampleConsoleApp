using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace IJSExampleConsoleApp.Commands
{
    public class StackCommand : Command
    {
        private Stack<string> _stack = new Stack<string>();

        public override string Key => "stack";

        public override Dictionary<string, Subcommand> Subcommands => new Dictionary<string, Subcommand>() {
            { "-l", new Subcommand(){Key = "-l", Description = "Lists all values in stack", Action = ListValues } },
            { "list", new Subcommand(){Key = "list", Description = "Lists all values in stack", Action = ListValues } },
            { "pop", new Subcommand(){Key = "pop", Description = "Pop value from the stack", Action = PopValue } },
            { "push", new Subcommand(){Key = "push", Description = "Pushes a value to the stack", Action = PushValue } },
            { "reset", new Subcommand(){Key = "reset", Description = "Resets stack to default values", Action = ResetStack } },
            { "clear", new Subcommand(){Key = "clear", Description = "Clears all values in stack", Action = ClearStack } }
        };

        public StackCommand() {
            Reinit();
        }

        public override void Run(string command) => base.Run(command);

        public void Reinit() {
            _stack.Clear();
            _stack.Push("Ik");
            _stack.Push("Eet");
            _stack.Push("Geen");
            _stack.Push("Bananen");
            _stack.Push("Vandaag");
        }

        public void ListValues(string input) {
            ConsoleEx.WriteEmptyLine();

            ConsoleEx.WriteSeperatorLine();
            ConsoleEx.WriteLine("Values withing Stack");
            ConsoleEx.WriteSeperatorLine();

            var stackAsArray = _stack.Reverse().ToArray();
            for (var i = (stackAsArray.Length - 1); i >= 0; i--) {
                ConsoleEx.WriteLine($"{i}. {stackAsArray[i]}");
            }

            ConsoleEx.WriteSeperatorLine();

            ConsoleEx.WriteEmptyLine();
        }

        public void PopValue(string input) {
            ConsoleEx.WriteEmptyLine();

            if (_stack.Count == 0) {
                ConsoleEx.WriteLine("Stack is empty");
                return;
            }

            var value = _stack.Pop();

            ConsoleEx.WriteLine($"Popped '{value}' from the stack");

            ConsoleEx.WriteEmptyLine();
        }

        public void PushValue(string input) {
            ConsoleEx.WriteEmptyLine();

            _stack.Push(input);

            ConsoleEx.WriteLine($"Pushed '{input}' to the stack");

            ConsoleEx.WriteEmptyLine();
        }

        public void ResetStack(string input) => Reinit();

        public void ClearStack(string input) => _stack.Clear();


    }
}
