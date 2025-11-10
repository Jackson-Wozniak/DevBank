using DevBank.Model;

namespace DevBank.Repository;

public interface IRepository
{
    void SaveEntry(Entry entry);
    List<Entry> FindEntriesByDescription(string phrase);
    List<Entry> FindEntriesByTags(List<string> tags);
    List<Entry> FindAllEntries(int? count);
}