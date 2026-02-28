using System.CommandLine;
using DevNote.CLI.Consoles;
using DevNote.CLI.Services;

namespace DevNote.CLI.Commands;

public class ClearCommand
{
    private readonly EntryService _entryService;
    private readonly IConsole _console;

    private ClearCommand(EntryService entryService, IConsole console)
    {
        _entryService = entryService;
        _console = console;
    }

    public static Command Create(EntryService entryService, IConsole c)
    {
        return new ClearCommand(entryService, c).CreateCommand();
    }

    private Command CreateCommand()
    {
        var command = new Command("clear", "Clears all entries");
        
        command.SetAction(_ => Execute());

        return command;
    }

    private void Execute()
    {
        var count = _entryService.ClearEntries();
        
        _console.WriteLine($"Cleared ({count}) entries.");
        _console.WriteLine("");
    }
}