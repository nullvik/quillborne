using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using quillborne.Services;
using quillborne.Themes.Services;
using quillborne.ViewModels;
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
        // Themes
        services.AddSingleton<IThemeInstaller, ThemeInstaller>();
        services.AddSingleton<IThemeService, ThemeService>();

        // Windows
        services.AddSingleton<IWindowService, WindowService>();

        // ViewModels
        services.AddSingleton<EditorViewModel>();
        services.AddTransient<NavigationBarViewModel>();
        services.AddTransient<SettingsViewModel>();
        services.AddTransient<MainViewModel>();
    }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime
            is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var installer =
                Services.GetRequiredService<IThemeInstaller>();

            installer.InstallBundledThemes();

            var themeService =
                Services.GetRequiredService<IThemeService>();

            themeService.LoadThemes();

            var mainViewModel =
                Services.GetRequiredService<MainViewModel>();

            desktop.MainWindow = new MainWindow
            {
                DataContext = mainViewModel
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
