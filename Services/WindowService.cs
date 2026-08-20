using System;
using Microsoft.Extensions.DependencyInjection;
using quillborne.ViewModels.Windows;
using quillborne.Views.Windows;

namespace quillborne.Services;

public sealed class WindowService(
    IServiceProvider services) : IWindowService
{
    public void ShowSettingsWindow()
    {
        var viewModel = services.GetRequiredService<SettingsViewModel>();

        var window = new SettingsWindow
        {
            DataContext = viewModel
        };

        window.Show();
    }

    public void ShowProjectsWindow()
    {
        var viewModel = services.GetRequiredService<ProjectsViewModel>();

        var window = new ProjectsWindow
        {
            DataContext = viewModel
        };

        window.Show();
    }
}
