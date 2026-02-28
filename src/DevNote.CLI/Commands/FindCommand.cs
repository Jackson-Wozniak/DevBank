using System.CommandLine;
using DevNote.CLI.Consoles;
using DevNote.CLI.Models;
using DevNote.CLI.Services;

namespace DevNote.CLI.Commands;

public class FindCommand
{
    private readonly EntryService _entryService;
    private readonly IConsole _console;

    private FindCommand(EntryService entryService, IConsole console)
    {
        _entryService = entryService;
        _console = console;
    }

    public static Command Create(EntryService entryService, IConsole c)
    {
        return new FindCommand(entryService, c).CreateCommand();
    }

    private Command CreateCommand()
    {
        var command = new Command("find", "Find matching entries");

        var contentArgument = new Argument<string>("content")
        {
            Arity = ArgumentArity.ZeroOrOne
        };
        
        var tagsOption = new Option<string[]>("--tags", "-t")
        {
            AllowMultipleArgumentsPerToken = true
        };
        var projectsOption = new Option<string>("--project", "-p");
        var langOption = new Option<string>("--lang");
        var starredOption = new Option<bool>("--star");
        
        command.Options.Add(tagsOption);
        command.Options.Add(projectsOption);
        command.Options.Add(langOption);
        command.Options.Add(starredOption);
        
        command.SetAction(result =>
        {
            string? content = result.GetValue(contentArgument);
            
            if (string.IsNullOrEmpty(content))
            {
                _console.WriteLine("Error: content is required");
                _console.WriteLine("Usage: DevNote find \"content\" [...]");
                return;
            }
            
            var tags = result.GetValue(tagsOption) ?? [];
            var project = result.GetValue(projectsOption);
            var language = result.GetValue(langOption);
            var starred = result.GetValue(starredOption);
            var searchParams = new SearchParams(content)
            {
                Tags = tags.ToList(),
                Project = project,
                Language = language,
                IsStarred =  starred,
            };
            Execute(searchParams);
        });

        return command;
    }

    private void Execute(SearchParams searchParams)
    {
        var entries = _entryService.SearchEntries(searchParams);
        
        _console.WriteLine($"Found ({entries.Count}) matching entries:");
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