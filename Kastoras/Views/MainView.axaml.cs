using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Kastoras.ViewModels;

namespace Kastoras.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        Console.WriteLine($"Clicked by {sender.GetHashCode()} with type {sender.GetType().Name}");
    }
}