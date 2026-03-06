using DevNote.Shared.Models;

namespace DevNote.Shared.Repositories;

public interface IRepository
{
    int DeleteAll();
    void Save(Entry entry);
    List<Entry> FindAll();
}