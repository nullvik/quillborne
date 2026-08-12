using CommunityToolkit.Mvvm.ComponentModel;

namespace quillborne.ViewModels;

public partial class MainViewModel(EditorViewModel editor, NavigationBarViewModel navigationBar) : ViewModelBase
{
    public EditorViewModel Editor { get; } = editor;

    public NavigationBarViewModel NavigationBar { get; } = navigationBar;
}
