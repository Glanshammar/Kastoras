using System.Windows.Input;
using Kastoras.Controls;
using ReactiveUI;

namespace Kastoras.ViewModels;

public class MainViewModel : ViewModelBase
{
    public ICommand IconButtonCommand { get; }
    public ICommand LightModeCommand { get; }
    public ICommand DarkModeCommand { get; }
    public ICommand SingleColorCommand { get; }

    public MainViewModel()
    {
        IconButtonCommand = ReactiveCommand.Create(() => ApplicationMethods.Button_OnClick(null, new Avalonia.Interactivity.RoutedEventArgs()));
        LightModeCommand = ReactiveCommand.Create(() => ApplicationMethods.LightMode(null, new Avalonia.Interactivity.RoutedEventArgs()));
        DarkModeCommand = ReactiveCommand.Create(() => ApplicationMethods.DarkMode(null, new Avalonia.Interactivity.RoutedEventArgs()));
        SingleColorCommand = ReactiveCommand.Create(() => ApplicationMethods.ChangeColor(null, new Avalonia.Interactivity.RoutedEventArgs()));
    }
    
    public string Greeting { get; } = "Welcome to Kastoras!";
}