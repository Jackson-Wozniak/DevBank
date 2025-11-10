using DevBank.Console;
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
        throw new NotImplementedException();
    }
}