namespace DevBank.Command;

public interface ICommand
{
    void Execute(string[] args);
}