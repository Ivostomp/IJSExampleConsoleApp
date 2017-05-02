using System;
using System.Collections.Generic;
using System.Text;
using static IJSExampleConsoleApp.Commands.Command;

namespace IJSExampleConsoleApp.Commands
{
    public interface ICommand
    {
        string Key { get; }
        Dictionary<string, Subcommand> Subcommands { get; }
        void Run(string command);
        void ShowHelp();
    }

    
}
