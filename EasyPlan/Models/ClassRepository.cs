using System.Collections.ObjectModel;
using System.Text.Json;
using Microsoft.Maui.Storage;

namespace EasyPlan.Models;

public static class ClassRepository
{
    private const string StorageKey = "SavedClasses";

    public static ObservableCollection<ClassItem> Classes { get; private set; } = new();

    public static void SaveClasses()
    {
        string json = JsonSerializer.Serialize(Classes);
        Preferences.Set(StorageKey, json);
    }

    public static void LoadClasses()
    {
        string json = Preferences.Get(StorageKey, "");

        if (!string.IsNullOrWhiteSpace(json))
        {
            var loadedClasses = JsonSerializer.Deserialize<ObservableCollection<ClassItem>>(json);

            if (loadedClasses != null)
            {
                Classes = loadedClasses;
            }
        }
    }
}