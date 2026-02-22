namespace DevNote.Models;

public class SearchParams
{
    public string Content { get; set; }
    public string? Project { get; set; }
    public string? Language { get; set; }
    public bool IsStarred { get; set; }
    public List<string> Tags { get; set; } = [];
    
    public SearchParams(string content)
    {
        Content = content;
    }

    public bool EntryMatchesAll(Entry entry)
    {
        if (!entry.Content.Contains(Content, StringComparison.OrdinalIgnoreCase)) return false;
        if (!entry.IsStarred && IsStarred) return false;
        if (Project is not null && !string.Equals(entry.Project, Project, StringComparison.OrdinalIgnoreCase)) return false;
        if (Language is not null && !string.Equals(entry.Language, Language, StringComparison.OrdinalIgnoreCase)) return false;
        if (Tags.Count != 0 && !entry.Tags.Any(t => Tags.Contains(t, StringComparer.OrdinalIgnoreCase))) return false;
        return true;
    }
}