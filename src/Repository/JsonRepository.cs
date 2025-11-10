using System.Text;
using System.Text.Json;
using DevBank.Model;

namespace DevBank.Repository;

public class JsonRepository : IRepository
{
    private readonly string _dataFilePath;
    
    //defaults to file path but allows for injecting a json file for tests
    public JsonRepository(string file = "./Data/entries.json")
    {
        _dataFilePath = file;
    }

    private List<Entry> ReadEntriesFromFile()
    {
        var entries = JsonSerializer.Deserialize<List<Entry>>(File.ReadAllText(_dataFilePath));
        return entries ?? [];
    }

    private void WriteEntriesToFile(List<Entry> entries)
    {
        var entriesStr = JsonSerializer.Serialize(entries);
        File.WriteAllText(_dataFilePath, entriesStr, Encoding.UTF8);
    }
    
    public void SaveEntry(Entry entry)
    {
        var entries = ReadEntriesFromFile();
        entries.Add(entry);
        WriteEntriesToFile(entries);
    }

    public List<Entry> FindEntriesByMessagePhrase(string phrase)
    {
        throw new NotImplementedException();
    }

    public List<Entry> FindEntriesByTags(List<string> tags)
    {
        throw new NotImplementedException();
    }

    public List<Entry> FindAllEntries(int? count)
    {
        var entries = ReadEntriesFromFile();
        if (count is null or < 0) return entries;
        return entries.Take(count.Value).ToList();
    }
}