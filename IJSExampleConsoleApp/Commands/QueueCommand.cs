using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace IJSExampleConsoleApp.Commands
{
    public class QueueCommand : Command
    {
        private Queue<string> _queue = new Queue<string>();

        public override string Key => "queue";

        public override Dictionary<string, Subcommand> Subcommands => new Dictionary<string, Subcommand>() {
            { "-l", new Subcommand(){Key = "-l", Description = "Lists all values in queue", Action = ListValues } },
            { "list", new Subcommand(){Key = "list", Description = "Lists all values in queue", Action = ListValues } },
            { "pop", new Subcommand(){Key = "pop", Description = "Pop value from the queue", Action = PopValue } },
            { "push", new Subcommand(){Key = "push", Description = "Pushes a value to the queue", Action = PushValue } },
            { "reset", new Subcommand(){Key = "reset", Description = "Resets queue to default values", Action = ResetStack } },
            { "clear", new Subcommand(){Key = "clear", Description = "Clears all values in queue", Action = ClearStack } }
        };

        public QueueCommand() {
            Reinit();
        }

        public override void Run(string command) => base.Run(command);

        public void Reinit() {
            _queue.Clear();
            _queue.Enqueue("Ik");
            _queue.Enqueue("Eet");
            _queue.Enqueue("Geen");
            _queue.Enqueue("Bananen");
            _queue.Enqueue("Vandaag");
        }

        public void ListValues(string input) {
            ConsoleEx.WriteEmptyLine();

            ConsoleEx.WriteSeperatorLine();
            ConsoleEx.WriteLine("Values withing Stack");
            ConsoleEx.WriteSeperatorLine();

            var stackAsArray = _queue.Reverse().ToArray();
            for (var i = (stackAsArray.Length - 1); i >= 0; i--) {
                ConsoleEx.WriteLine($"{i}. {stackAsArray[i]}");
            }

            ConsoleEx.WriteSeperatorLine();
            ConsoleEx.WriteEmptyLine();
        }

        public void PopValue(string input) {
            ConsoleEx.WriteEmptyLine();

            if (_queue.Count == 0) {
                ConsoleEx.WriteLine("queue is empty");
                return;
            }

            var value = _queue.Dequeue();

            ConsoleEx.WriteLine($"Popped '{value}' from the queue");
            ConsoleEx.WriteEmptyLine();
        }

        public void PushValue(string input) {
            ConsoleEx.WriteEmptyLine();

            _queue.Enqueue(input);

            ConsoleEx.WriteLine($"Pushed '{input}' to the queue");
            ConsoleEx.WriteEmptyLine();
        }

        public void ResetStack(string input) => Reinit();

        public void ClearStack(string input) => _queue.Clear();


    }
}
