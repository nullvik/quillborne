using System.Collections.Generic;
using System.Threading.Tasks;
using quillborne.Services.Themes.Models;

namespace quillborne.Services.Themes.Services;

public interface IThemeService
{
    IReadOnlyList<ThemeDefinition> Themes { get; }

    ThemeDefinition? CurrentTheme { get; }

    void LoadThemes();

    void ApplyTheme(string themeId);
}
