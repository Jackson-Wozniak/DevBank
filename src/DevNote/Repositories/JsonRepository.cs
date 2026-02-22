using System.Text;
using System.Text.Json;
using DevNote.Helpers;
using DevNote.Models;

namespace DevNote.Repositories;

public class JsonRepository : IRepository
{
    private readonly string _dataFilePath = JsonRepositoryHelper.GetDataPath();
    private readonly JsonSerializerOptions _options = new() { WriteIndented = true };

    private List<Entry> ReadFromFile()
    {
        var fileContent = File.ReadAllText(_dataFilePath);
        if (string.IsNullOrWhiteSpace(fileContent)) return [];
        var entries = JsonSerializer.Deserialize<List<Entry>>(fileContent);
        return entries ?? [];
    }

    private void WriteToFile(List<Entry> entries)
    {
        var entriesStr = JsonSerializer.Serialize(entries, _options);
        File.WriteAllText(_dataFilePath, entriesStr, Encoding.UTF8);
    }

    public int DeleteAll()
    {
        var count = ReadFromFile().Count;
        File.WriteAllText(_dataFilePath, "");
        return count;
    }
    
    public void Save(Entry entry)
    {
        var entries = ReadFromFile();
        entries.Add(entry);
        WriteToFile(entries);
    }

    public List<Entry> FindAll()
    {
        return ReadFromFile();
    }
}