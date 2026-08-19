using CommunityToolkit.Mvvm.ComponentModel;

namespace quillborne.ViewModels;

public partial class EditorViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial string EditorText { get; set; } = string.Empty; // Load from save file
}
