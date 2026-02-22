using System.CommandLine;
using DevNote.Consoles;
using DevNote.Repositories;
using DevNote.Models;
using DevNote.Services;

namespace DevNote.Commands;

public class ListCommand
{
    private readonly EntryService _entryService;
    private readonly IConsole _console;

    private ListCommand(EntryService entryService, IConsole console)
    {
        _entryService = entryService;
        _console = console;
    }

    public static Command Create(EntryService entryService, IConsole c)
    {
        return new ListCommand(entryService, c).CreateCommand();
    }

    private Command CreateCommand()
    {
        var command = new Command("list", "Print entries ordered by date");

        var countOption = new Option<int?>("--count", "-c");
        command.Options.Add(countOption);
        
        command.SetAction(result =>
        {
            int count = result.GetValue(countOption) ?? 25;
            
            Execute(count);
        });

        return command;
    }

    private void Execute(int maxEntries)
    {
        List<Entry> entries = _entryService.FindEntries()
            .OrderByDescending(e => e.CreatedAt)
            .Take(maxEntries)
            .ToList();
        
        _console.WriteLine($"Found ({entries.Count}) most recent entries:");
        _console.WriteLine("");
        foreach (var entry in entries)
        {
            _console.WriteLine($"\"{entry.Content}\"");
            _console.WriteLine($"    tags: [{string.Join(", ", entry.Tags)}]");
            _console.WriteLine($"    created on: {entry.CreatedAt:f}");
            _console.WriteLine("");
        }
    }
}