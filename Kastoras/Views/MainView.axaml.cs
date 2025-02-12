using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
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
    
    private void DarkMode(object sender, RoutedEventArgs e)
    {
        // Hex values for dark mode
        Color backgroundColor = Color.Parse("#1A2232");  // Dark background hex
        Color secondaryColor = Color.Parse("#13151B");   // Dark secondary color hex
        Color buttonColor = Color.Parse("#247CFF");   // Dark secondary color hex

        // Update the application colors
        App app = (App)Application.Current;
        app.UpdateUserColors(backgroundColor, secondaryColor, buttonColor);
    }
    
    private void LightMode(object sender, RoutedEventArgs e)
    {
        // Hex values for light mode
        Color backgroundColor = Color.Parse("#E0FBFC");  // Light background hex
        Color secondaryColor = Color.Parse("#3D5A80");   // Light secondary color hex
        Color buttonColor = Color.Parse("#247CFF");   // Light secondary color hex

        // Update the application colors
        App app = (App)Application.Current;
        app.UpdateUserColors(backgroundColor, secondaryColor, buttonColor);
    }
}