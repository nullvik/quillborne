using System.Text.Json;
using System.IO;
using System;

namespace quillborne.Services.Settings;

public sealed class AppSettings
{
    public string Theme { get; set; } = "Dark";
    public double WindowHeight { get; set; } = 800;
    public double WindowWidth { get; set; } = 450;
    public string LastOpenedFile { get; set; } = "";
}

public sealed class SettingsService : ISettingsService
{
    private static readonly string SettingsPath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "quillborne",
        "settings.json");

    public AppSettings Load()
    {
        if (!File.Exists(SettingsPath))
            return new AppSettings();

        var json = File.ReadAllText(SettingsPath);
        return JsonSerializer.Deserialize<AppSettings>(json) ?? new AppSettings();
    }
}
