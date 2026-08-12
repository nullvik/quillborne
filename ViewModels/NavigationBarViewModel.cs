using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using quillborne.Services;

namespace quillborne.ViewModels;

public partial class NavigationBarViewModel(EditorViewModel editor, IWindowService windowService) : ViewModelBase
{
    // File Commands
    [RelayCommand]
    private void NewFile()
    {

    }

    [RelayCommand]
    private void OpenFile()
    {

    }

    [RelayCommand]
    private void SaveFile()
    {
        editor.EditorText = string.Empty;
    }

    [RelayCommand]
    private void ExportFile()
    {

    }

    // Edit Commands
    [RelayCommand]
    private void UndoEdit()
    {

    }

    [RelayCommand]
    private void RedoEdit()
    {

    }

    [RelayCommand]
    private void CutEdit()
    {

    }

    [RelayCommand]
    private void CopyEdit()
    {

    }

    [RelayCommand]
    private void PasteEdit()
    {

    }

    // View Commands
    [RelayCommand]
    private void SidebarView()
    {

    }

    [RelayCommand]
    private void OutlineView()
    {

    }

    [RelayCommand]
    private void WordCountView()
    {

    }

    // Search Commands
    [RelayCommand]
    private void FindSearch()
    {

    }

    [RelayCommand]
    private void ReplaceSearch()
    {

    }

    // Options Commands
    [RelayCommand]
    private void SettingsOptions()
    {
        windowService.ShowSettings();
    }

    [RelayCommand]
    private void AboutOptions()
    {

    }
}
