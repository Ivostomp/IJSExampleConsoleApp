namespace IJSExampleConsoleApp.Commands {
    public interface ISubcommand {
        Subcommand.SubcommandDelegate Action { get; set; }
        string Description { get; set; }
        string Key { get; set; }
    }
}