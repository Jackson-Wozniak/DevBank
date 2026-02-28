using DevNote.CLI.Models;
using DevNote.CLI.Repositories;
using DevNote.CLI.Services;

namespace DevNote.CLI.Tests.Services;

[Collection("Tests")]
public class EntryServiceTests : IDisposable
{
    private readonly string _filePath;
    private readonly EntryService _entryService;
    
    public EntryServiceTests()
    { 
        var tempDir = Path.Combine(Path.GetTempPath(), "DevNoteTests");
        Directory.CreateDirectory(tempDir);
        _filePath = Path.Combine(tempDir, "entries.json");
        
        if (File.Exists(_filePath)) File.Delete(_filePath);
        File.WriteAllText(_filePath, "");

        _entryService = new EntryService(new JsonRepository(_filePath));
    }
    
    public void Dispose()
    {
        if (File.Exists(_filePath)) File.Delete(_filePath);
    }

    [Fact]
    public void SearchEntries_MatchingContent_ReturnsMultiple()
    {
        _entryService.ClearEntries();
        _entryService.SaveEntry(new Entry("Content M", [], DateTime.Now));
        _entryService.SaveEntry(new Entry("Content C", [], DateTime.Now));
        _entryService.SaveEntry(new Entry("Content E", [], DateTime.Now));
        _entryService.SaveEntry(new Entry("Content A", [], DateTime.Now));
        _entryService.SaveEntry(new Entry("Not Matching", [], DateTime.Now));
        var entries = _entryService.SearchEntries(new SearchParams("Content"));
        Assert.Equal(4, entries.Count);
    }

    [Fact]
    public void SearchEntries_EmptyContent_ReturnsAll()
    {
        _entryService.ClearEntries();
        _entryService.SaveEntry(new Entry("Content", [], DateTime.Now));
        _entryService.SaveEntry(new Entry("Test", [], DateTime.Now));
        _entryService.SaveEntry(new Entry("Different", [], DateTime.Now));
        var entries = _entryService.SearchEntries(new SearchParams(""));
        Assert.Equal(3, entries.Count);
    }
    
    [Fact]
    public void SearchEntries_MatchingTags_Returns()
    {
        _entryService.ClearEntries();
        _entryService.SaveEntry(new Entry("Content", ["Tag"], DateTime.Now));
        _entryService.SaveEntry(new Entry("Content", ["Tag"], DateTime.Now));
        _entryService.SaveEntry(new Entry("Content", ["Tag"], DateTime.Now));
        _entryService.SaveEntry(new Entry("Content", ["Tag"], DateTime.Now));
        _entryService.SaveEntry(new Entry("Content", ["Not Matching"], DateTime.Now));
        var entries = _entryService.SearchEntries(new SearchParams("")
        {
            Tags = ["Tag"]
        });
        Assert.Equal(4, entries.Count);
    }
    
    [Fact]
    public void SearchEntries_MatchingProject_Returns()
    {
        _entryService.ClearEntries();
        _entryService.SaveEntry(new Entry("Content", ["Tag"], DateTime.Now){Project = "test project"});
        _entryService.SaveEntry(new Entry("Content", ["Tag"], DateTime.Now));
        _entryService.SaveEntry(new Entry("Content", ["Tag"], DateTime.Now));
        _entryService.SaveEntry(new Entry("Content", ["Tag"], DateTime.Now));
        _entryService.SaveEntry(new Entry("Content", ["Not Matching"], DateTime.Now));
        var entries = _entryService.SearchEntries(new SearchParams("")
        {
            Project = "test project"
        });
        Assert.Single(entries);
    }
}