using System.Collections.ObjectModel;
using System.Text.Json;
using Microsoft.Maui.Storage;

namespace EasyPlan.Models;

public static class ClassRepository
{
    private const string StorageKey = "SavedClasses";

    public static ObservableCollection<ClassItem> Classes { get; private set; } = new();

    // Save list to device
    public static void SaveClasses()
    {
        string json = JsonSerializer.Serialize(Classes);
        Preferences.Set(StorageKey, json);
    }

    // Load list from device
    public static void LoadClasses()
    {
        string json = Preferences.Get(StorageKey, "");

        if (!string.IsNullOrWhiteSpace(json))
        {
            var loaded = JsonSerializer.Deserialize<ObservableCollection<ClassItem>>(json);

            if (loaded != null)
                Classes = loaded;
        }
    }
}