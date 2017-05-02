using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace IJSExampleConsoleApp.Commands {
    public abstract class Command: ICommand {
        
        public virtual string Key { get; }

        public virtual Dictionary<string, Subcommand> Subcommands { get; }

        public virtual void Run(string command) {
            if (command.StartsWith("--help") || command.StartsWith("help") || command.StartsWith("-h") || string.IsNullOrWhiteSpace(command)) {
                ShowHelp();
                return;
            }

            var subcommand = command.Split(' ').First();
            var input = command.Replace(subcommand, "").Trim();

            if (Subcommands.ContainsKey(subcommand)) {
                Subcommands[subcommand].Action.Invoke(input);
            }
            else {
                ConsoleEx.WriteEmptyLine();
                ConsoleEx.WriteSeperatorLine();
                ConsoleEx.WriteLine($"command of {subcommand} is not valid.");
                ConsoleEx.WriteLine("please use --help or -h for more information");
                ConsoleEx.WriteSeperatorLine();
                ConsoleEx.WriteEmptyLine();
            }
        }

        public virtual void ShowHelp() {
            ConsoleEx.WriteEmptyLine();
            ConsoleEx.WriteSeperatorLine();
            ConsoleEx.WriteLine($"|Help for {Key} command");
            ConsoleEx.WriteSeperatorLine();

            foreach (var subcommand in Subcommands) {
                ConsoleEx.WriteLine(subcommand.Value.ToString());
            }
            ConsoleEx.WriteEmptyLine();
        }

        
    }
}
