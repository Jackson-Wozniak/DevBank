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
    
    public void SaveEntry(Entry entry)
    {
        
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
        throw new NotImplementedException();
    }
}