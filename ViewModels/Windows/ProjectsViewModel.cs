using System.Collections.Generic;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace quillborne.ViewModels.Windows;

public partial class ProjectsViewModel : ObservableObject
{
    [RelayCommand]
    private void NewProject()
    {
        // Spawn input for project name
        // Check name against rules
        // Create project with name
        // Open project in main window
    }

    [RelayCommand]
    private void OpenProject()
    {
        // Open project in main window
    }
}
