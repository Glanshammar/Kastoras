using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Kastoras.Views;

public partial class LoginView : UserControl
{
    public LoginView()
    {
        InitializeComponent();
    }
    
    private void OnRegisterClick(object? sender, RoutedEventArgs e)
    {
        Console.WriteLine("OnRegisterClick");
    }
}