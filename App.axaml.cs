using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using quillborne.Services;
using quillborne.Services.Themes.Services;
using quillborne.Services.Settings;
using quillborne.Services.Projects;
using quillborne.Services.Files;
using quillborne.ViewModels;
using quillborne.ViewModels.Windows;
using quillborne.ViewModels.Editor;
using quillborne.ViewModels.Navbar;
using quillborne.Views;

namespace quillborne;

public partial class App : Application
{
    public IServiceProvider Services { get; }

    public App()
    {
        var services = new ServiceCollection();

        ConfigureServices(services);

        Services = services.BuildServiceProvider();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // Projects, Settings, Files
        services.AddSingleton<IProjectService, ProjectService>();
        services.AddSingleton<ISettingsService, SettingsService>();
        services.AddSingleton<IFileService, FileService>();

        // Themes
        services.AddSingleton<IThemeInstaller, ThemeInstaller>();
        services.AddSingleton<IThemeService, ThemeService>();

        // Windows
        services.AddSingleton<IWindowService, WindowService>();

        // ViewModels
        services.AddSingleton<EditorViewModel>();
        services.AddTransient<NavbarViewModel>();
        services.AddTransient<SettingsViewModel>();
        services.AddTransient<ProjectsViewModel>();
        services.AddTransient<MainViewModel>();
    }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var settingsService = Services.GetRequiredService<ISettingsService>();

            var themeInstaller = Services.GetRequiredService<IThemeInstaller>();
            themeInstaller.InstallBundledThemes();

            var themeService = Services.GetRequiredService<IThemeService>();
            themeService.LoadThemes();
            themeService.LoadThemeFromSettings();

            var mainViewModel = Services.GetRequiredService<MainViewModel>();
            desktop.MainWindow = new MainWindow
            {
                DataContext = mainViewModel,
            };

            desktop.ShutdownMode = ShutdownMode.OnMainWindowClose;
        }

        base.OnFrameworkInitializationCompleted();
    }
}
