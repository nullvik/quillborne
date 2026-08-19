using System;
using Microsoft.Extensions.DependencyInjection;
using quillborne.ViewModels;
using quillborne.Views;

namespace quillborne.Services;

public sealed class WindowService(
    IServiceProvider services) : IWindowService
{
    public void ShowSettingsWindow()
    {
        var viewModel =
            services.GetRequiredService<SettingsViewModel>();

        var window = new SettingsWindow
        {
            DataContext = viewModel
        };

        window.Show();
    }
}
