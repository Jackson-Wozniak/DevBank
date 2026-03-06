namespace DevNote.Shared.Helpers;

public static class JsonRepositoryHelper
{
    public static string AppDataPath => GetAppDataPath();
    
    private static string GetAppDataPath()
    {
        string fileName = "entries.json";
        string path;
        
#if DEBUG
        string projectRoot = Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;
        path = Path.Combine(projectRoot, "App_Data");
#else
        string path = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "DevNote",
            "Data");
#endif
        
        Directory.CreateDirectory(path);
        string filePath = Path.Combine(path, fileName);
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "");
        }
        return filePath;
    }
}