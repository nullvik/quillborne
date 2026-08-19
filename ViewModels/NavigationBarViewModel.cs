using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using quillborne.Services;
using System;

namespace quillborne.ViewModels;

public partial class NavigationBarViewModel(EditorViewModel editor, IWindowService windowService) : ViewModelBase
{
    // File Commands
    [RelayCommand]
    private void NewFile()
    {
        // Create new file in project destination
    }

    [RelayCommand]
    private void OpenFile()
    {
        // Spawn File Dialogue
    }

    [RelayCommand]
    private void SaveFile()
    {
        Console.WriteLine(editor.EditorText);
    }

    [RelayCommand]
    private void ExportFile()
    {
        // Conversion to a couple of file formats
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
        windowService.ShowSettingsWindow();
    }

    [RelayCommand]
    private void AboutOptions()
    {

    }
}
