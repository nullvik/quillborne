using CommunityToolkit.Mvvm.ComponentModel;

namespace quillborne.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public EditorViewModel Editor { get; } = new();

    public NavigationBarViewModel NavigationBar { get; }

    public MainViewModel()
    {
        NavigationBar = new NavigationBarViewModel(Editor);
    }
}
