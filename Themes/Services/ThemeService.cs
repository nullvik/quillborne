using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Avalonia;
using Avalonia.Media;
using quillborne.Themes.Models;

using System.Diagnostics;

namespace quillborne.Themes.Services;

public sealed class ThemeService : IThemeService
{
    private readonly List<ThemeDefinition> _themes = [];

    public IReadOnlyList<ThemeDefinition> Themes => _themes;

    public ThemeDefinition? CurrentTheme { get; private set; }

    public ThemeService()
    {
        Directory.CreateDirectory(ThemePaths.Directory);
    }

    public void LoadThemes()
    {
        _themes.Clear();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        foreach (var file in Directory.EnumerateFiles(
            ThemePaths.Directory,
            "*.json"))
        {
            try
            {
                var json = File.ReadAllText(file);

                var theme =
                    JsonSerializer.Deserialize<ThemeDefinition>(json, options);

                if (theme is not null)
                    _themes.Add(theme);
            }
            catch (Exception)
            {
                // TODO: Log invalid theme
            }
        }
    }

    public void ApplyTheme(string themeId)
    {
        var theme = _themes.FirstOrDefault(
            x => x.Id.Equals(
                themeId,
                StringComparison.OrdinalIgnoreCase));

        if (theme is null)
            return;

        CurrentTheme = theme;

        ApplyResources(theme);
    }

    private static void ApplyResources(ThemeDefinition theme)
    {
        if (Application.Current is null)
            return;

        var resources = Application.Current.Resources;
        var colors = theme.Colors;

        resources["BackgroundBrush"] = Brush(colors.Background);
        resources["SurfaceBrush"] = Brush(colors.Surface);
        resources["SurfaceAltBrush"] = Brush(colors.SurfaceAlt);

        resources["TextPrimaryBrush"] = Brush(colors.TextPrimary);
        resources["TextSecondaryBrush"] = Brush(colors.TextSecondary);
        resources["TextMutedBrush"] = Brush(colors.TextMuted);

        resources["BorderBrush"] = Brush(colors.Border);
        resources["BorderStrongBrush"] = Brush(colors.BorderStrong);

        resources["HighlightBrush"] = Brush(colors.Highlight);
        resources["HighlightHoverBrush"] = Brush(colors.HighlightHover);
        resources["HighlightSoftBrush"] = Brush(colors.HighlightSoft);

        resources["SelectionBrush"] = Brush(colors.Selection);
        resources["CursorBrush"] = Brush(colors.Cursor);

        resources["SuccessBrush"] = Brush(colors.Success);
        resources["WarningBrush"] = Brush(colors.Warning);
        resources["ErrorBrush"] = Brush(colors.Error);
    }

    private static SolidColorBrush Brush(string hex)
    {
        return new SolidColorBrush(Color.Parse(hex));
    }
}
