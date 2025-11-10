using DevBank.Console;
using DevBank.Repository;

namespace DevBank.Command;

public class FindCommand : ICommand
{
    private readonly IRepository _repository;
    private readonly IConsole _console;

    protected FindCommand(IRepository repository, IConsole console)
    {
        _repository = repository;
        _console = console;
    }

    public static FindCommand Create()
    {
        return new FindCommand(new JsonRepository(), new SystemConsole());
    }

    public static FindCommand Create(IRepository r, IConsole c)
    {
        return new FindCommand(r, c);
    }

    public void Execute(string[] args)
    {
        throw new NotImplementedException();
    }
}