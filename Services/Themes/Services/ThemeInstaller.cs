using System;
using System.IO;
using System.Threading.Tasks;
using Avalonia.Platform;

namespace quillborne.Services.Themes.Services;

public sealed class ThemeInstaller : IThemeInstaller
{
    private static readonly string[] BundledThemes =
    [
        "default.json",
        "dark.json"
    ];

    public ThemeInstaller()
    {
        Directory.CreateDirectory(ThemePaths.Directory);
    }

    public void InstallBundledThemes()
    {
        foreach (var themeFile in BundledThemes)
        {
            InstallTheme(themeFile);
        }
    }

    private static void InstallTheme(string fileName)
    {
        var destination = Path.Combine(
            ThemePaths.Directory,
            fileName);

        if (File.Exists(destination))
            return;

        var uri = new Uri(
            $"avares://quillborne/Services/Themes/Bundled/{fileName}");

        using var source = AssetLoader.Open(uri);
        using var destinationStream = File.Create(destination);

        source.CopyTo(destinationStream);
    }
}
