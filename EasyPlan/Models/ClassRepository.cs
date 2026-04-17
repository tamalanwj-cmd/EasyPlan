using System.Collections.ObjectModel;
using System.Text.Json;

namespace EasyPlan.Models;

public static class ClassRepository
{
    private static string filePath = Path.Combine(FileSystem.AppDataDirectory, "classes.json");

    // ONE shared list
    public static ObservableCollection<ClassItem> Classes { get; } = new();

    public static void LoadClasses()
    {
        if (!File.Exists(filePath))
            return;

        string json = File.ReadAllText(filePath);
        var items = JsonSerializer.Deserialize<List<ClassItem>>(json);

        if (items == null)
            return;

        Classes.Clear();

        foreach (var item in items)
            Classes.Add(item);
    }

    public static void SaveClasses()
    {
        string json = JsonSerializer.Serialize(Classes);
        File.WriteAllText(filePath, json);
    }
}