using DevNote.Models;
using DevNote.Repositories;

namespace DevNote.Tests.Repository;

[Collection("Tests")]
public class JsonRepositoryTests : IDisposable
{
    private readonly string _filePath;
    private readonly JsonRepository _repository;
    
    public JsonRepositoryTests()
    { 
        var tempDir = Path.Combine(Path.GetTempPath(), "DevNoteTests");
        Directory.CreateDirectory(tempDir);
        _filePath = Path.Combine(tempDir, "entries.json");
        
        if (File.Exists(_filePath)) File.Delete(_filePath);
        File.WriteAllText(_filePath, "");

       _repository = new  JsonRepository(_filePath);
    }

    public void Dispose()
    {
        if (File.Exists(_filePath)) File.Delete(_filePath);
    }

    [Fact]
    public void Save_NewEntry_SavesToFile()
    {
        _repository.DeleteAll();
        _repository.Save(new Entry("Content", [], DateTime.Now));
        Assert.Single(_repository.FindAll());
    }

    [Fact]
    public void DeleteAll_MultipleEntries_ClearsFile()
    {
        _repository.Save(new Entry("Content", [], DateTime.Now));
        _repository.Save(new Entry("Content", [], DateTime.Now));
        _repository.Save(new Entry("Content", [], DateTime.Now));
        _repository.Save(new Entry("Content", [], DateTime.Now));
        _repository.Save(new Entry("Content", [], DateTime.Now));
        Assert.Equal(5, _repository.FindAll().Count);
        _repository.DeleteAll();
        Assert.Empty(_repository.FindAll());
    }
    
    [Fact]
    public void FindAll_MultipleEntries_ReturnsCorrectAmount()
    {
        _repository.DeleteAll();
        _repository.Save(new Entry("Content", [], DateTime.Now));
        _repository.Save(new Entry("Content", [], DateTime.Now));
        _repository.Save(new Entry("Content", [], DateTime.Now));
        _repository.Save(new Entry("Content", [], DateTime.Now));
        _repository.Save(new Entry("Content", [], DateTime.Now));
        Assert.Equal(5, _repository.FindAll().Count);
    }
}