namespace DevBank.Model;

public class Entry
{
    public List<string> Tags { get; set; } = [];
    public string Message { get; set; }
    public DateTime CreatedAt { get; set; }

    public Entry(string message, List<string> tags, DateTime createdAt)
    {
        Tags.AddRange(tags);
        Message = message;
        CreatedAt = createdAt;
    }
}