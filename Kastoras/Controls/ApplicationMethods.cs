using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace Kastoras.Controls;

public class ApplicationMethods : UserControl
{
    public static void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        Console.WriteLine($"Clicked by {sender?.GetHashCode()} with type {sender?.GetType().Name}");
    }
    
    public static void DarkMode(object sender, RoutedEventArgs e)
    {
        Color backgroundColor = Color.Parse("#1A2232");
        Color secondaryColor = Color.Parse("#13151B");
        Color buttonColor = Color.Parse("#247CFF");

        App app = (App)(Application.Current ?? throw new InvalidOperationException("Application.Current is null"));
        app.UpdateUserColors(backgroundColor, secondaryColor, buttonColor);
    }
    
    public static void LightMode(object sender, RoutedEventArgs e)
    {
        Color backgroundColor = Color.Parse("#E0FBFC");
        Color secondaryColor = Color.Parse("#3D5A80");
        Color buttonColor = Color.Parse("#247CFF");

        App app = (App)(Application.Current ?? throw new InvalidOperationException("Application.Current is null"));
        app.UpdateUserColors(backgroundColor, secondaryColor, buttonColor);
    }

    public static void ChangeColor(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }
}