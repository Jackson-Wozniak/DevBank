using DevNote.CLI.Models;

namespace DevNote.CLI.Repositories;

public interface IRepository
{
    int DeleteAll();
    void Save(Entry entry);
    List<Entry> FindAll();
}