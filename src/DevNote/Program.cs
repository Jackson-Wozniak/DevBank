using System.CommandLine;
using DevNote.Commands;
using DevNote.Consoles;
using DevNote.Repositories;
using DevNote.Services;

namespace DevNote;

class Program
{
    public static void Main(string[] args)
    {
        var rootCommand = new RootCommand("DevNote CLI");
        var entryService = new EntryService(new JsonRepository());
        var systemConsole = new SystemConsole();
        
        rootCommand.Add(SaveCommand.Create(entryService, systemConsole));
        rootCommand.Add(ListCommand.Create(entryService, systemConsole));
        rootCommand.Add(FindCommand.Create(entryService, systemConsole));
        rootCommand.Add(ClearCommand.Create(entryService, systemConsole));

        rootCommand.Parse(args).Invoke();
    }
}
