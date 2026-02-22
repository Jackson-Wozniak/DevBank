namespace DevNote.Consoles;

public class SystemConsole : IConsole
{
    public void Write(string str) => Console.Write(str);
    public void WriteLine(string str) => Console.WriteLine(str);
}