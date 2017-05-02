using System;
using System.Collections.Generic;
using System.Text;

namespace IJSExampleConsoleApp.Commands
{
    public class Subcommand : ISubcommand {
        public string Key { get; set; }
        public string Description { get; set; }
        public SubcommandDelegate Action { get; set; }

        public delegate void SubcommandDelegate(string input);

        public override string ToString() => $"{Key}\t\t\t{Description}";
    }
}
