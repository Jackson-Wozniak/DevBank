using DevNote.Models;
using DevNote.Repositories;

namespace DevNote.Services;

public class EntryService
{
    private readonly IRepository _repository;
    private const int MaxEntries = 100;

    public EntryService(IRepository repository)
    {
        _repository = repository;
    }

    public int ClearEntries()
    {
        return _repository.DeleteAll();
    }

    public void SaveEntry(Entry entry)
    {
        _repository.Save(entry);
    }

    public List<Entry> FindEntries()
    {
        return _repository.FindAll().Take(MaxEntries).ToList();
    }

    public List<Entry> SearchEntries(SearchParams searchParams)
    {
        return _repository.FindAll();
    }
}