using CommunityToolkit.Mvvm.ComponentModel;
using quillborne.ViewModels.Editor;
using quillborne.ViewModels.Navbar;

namespace quillborne.ViewModels;

public partial class MainViewModel(EditorViewModel editor, NavbarViewModel navbar) : ViewModelBase
{
    public EditorViewModel Editor { get; } = editor;
    public NavbarViewModel Navbar { get; } = navbar;
}
