namespace DevBank.Model;

public class Entry
{
    public List<string> Tags { get; set; } = [];
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }

    public Entry(List<string> tags, string description, DateTime createdAt)
    {
        Tags.AddRange(tags);
        Description = description;
        CreatedAt = createdAt;
    }
}