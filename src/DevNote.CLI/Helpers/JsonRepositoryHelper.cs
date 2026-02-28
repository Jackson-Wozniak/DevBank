namespace DevNote.CLI.Helpers;

public static class JsonRepositoryHelper
{
    public static string AppDataPath => GetAppDataPath();
    
    private static string GetAppDataPath()
    {
        string path = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "DevNote",
            "Data");
        
        Directory.CreateDirectory(path);
        string filePath = Path.Combine(path, "entries.json");
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "");
        }
        return filePath;
    }
}