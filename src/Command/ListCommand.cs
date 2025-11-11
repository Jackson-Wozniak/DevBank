using DevBank.Console;
using DevBank.Exception;
using DevBank.Model;
using DevBank.Repository;

namespace DevBank.Command;

public class ListCommand : ICommand
{
    private readonly IRepository _repository;
    private readonly IConsole _console;

    protected ListCommand(IRepository repository, IConsole console)
    {
        _repository = repository;
        _console = console;
    }

    public static ListCommand Create()
    {
        return new ListCommand(new JsonRepository(), new SystemConsole());
    }

    public static ListCommand Create(IRepository r, IConsole c)
    {
        return new ListCommand(r, c);
    }

    public void Execute(string[] args)
    {
        List<Entry> entries;
        if (args.Length == 1)
        {
            entries = _repository.FindAll();
        
            _console.WriteLine($"Found {entries.Count} entries:");
            _console.WriteLine("");
            foreach (var entry in entries)
            {
                _console.WriteLine($"\"{entry.Message}\"");
                _console.WriteLine($"    tags: [{string.Join(", ", entry.Tags)}]");
                _console.WriteLine($"    created on: {entry.CreatedAt:f}");
            }

            return;
        }
        
        if (args[1].ToLower() != "-t" && args[1].ToLower() != "--tags")
        {
            _console.WriteLine(ExceptionStrings.InvalidListFormatException);
            return;
        }

        var tags = args.Skip(1).ToList();
        entries = _repository.FindByTags(tags);
        
        _console.WriteLine($"Found {entries.Count} entries:");
        _console.WriteLine("");
        foreach (var entry in entries)
        {
            _console.WriteLine($"\"{entry.Message}\"");
            _console.WriteLine($"    tags: [{string.Join(", ", entry.Tags)}]");
            _console.WriteLine($"    created on: {entry.CreatedAt:f}");
        }
    }
}