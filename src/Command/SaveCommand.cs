using DevBank.Console;
using DevBank.Repository;

namespace DevBank.Command;

public class SaveCommand : ICommand
{
    private readonly IRepository _repository;
    private readonly IConsole _console;

    protected SaveCommand(IRepository repository, IConsole console)
    {
        _repository = repository;
        _console = console;
    }

    public static SaveCommand Create()
    {
        return new SaveCommand(new JsonRepository(), new SystemConsole());
    }

    public static SaveCommand Create(IRepository r, IConsole c)
    {
        return new SaveCommand(r, c);
    }

    public void Execute(string[] args)
    {
        throw new NotImplementedException();
    }
}