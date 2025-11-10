using DevBank.Model;

namespace DevBank.Repository;

public class JsonRepository : IRepository
{
    public void SaveEntry(Entry entry)
    {
        
    }

    public List<Entry> FindEntriesByDescription(string phrase)
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