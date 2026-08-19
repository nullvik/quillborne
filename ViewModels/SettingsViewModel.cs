using System.Collections.Generic;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using quillborne.Services.Themes.Models;
using quillborne.Services.Themes.Services;
using quillborne.Services.Settings;

namespace quillborne.ViewModels;

public partial class SettingsViewModel : ObservableObject
{
    private readonly IThemeService _themeService;

    public IReadOnlyList<ThemeDefinition> Themes =>
        _themeService.Themes;

    [ObservableProperty]
    public partial ThemeDefinition? SelectedTheme { get; set; }

    public SettingsViewModel(IThemeService themeService)
    {
        _themeService = themeService;
        SelectedTheme = _themeService.CurrentTheme;
    }

    [RelayCommand]
    private void ApplyTheme()
    {
        if (SelectedTheme is null)
            return;

        _themeService.ApplyTheme(SelectedTheme.Id);
    }
}
