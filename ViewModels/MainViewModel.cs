using CommunityToolkit.Mvvm.ComponentModel;

namespace just_fucking_write.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial string Greeting { get; set; } = "Welcome to Just Fucking Write!";
}
