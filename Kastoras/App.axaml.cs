using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Layout;
using Avalonia.Markup.Xaml;
using Kastoras.ViewModels;
using Kastoras.Views;

namespace Kastoras;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }
    
    public void UpdateUserColors(Color customBackground, Color customSecondary, Color buttonColor)
    {
        // Access the application resources
        var resources = Application.Current.Resources;

        // Update the colors
        resources["BackgroundColor"] = customBackground;
        resources["SecondaryColor"] = customSecondary;
        resources["ButtonColor"] = buttonColor;
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel()
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}

public class ButtonExtensions : AvaloniaObject
{
    public static readonly AttachedProperty<bool> IsStretchedProperty =
        AvaloniaProperty.RegisterAttached<ButtonExtensions, Button, bool>("IsStretched");

    // Getters and setters
    public static void SetIsStretched(Button element, bool value)
        => element.SetValue(IsStretchedProperty, value);

    public static bool GetIsStretched(Button element)
        => element.GetValue(IsStretchedProperty);

    // Static constructor to listen for property changes
    static ButtonExtensions()
    {
        IsStretchedProperty.Changed.AddClassHandler<Button>((button, e) =>
            OnIsStretchedChanged(button, (bool)e.NewValue!));
    }

    // Handle property change
    private static void OnIsStretchedChanged(Button button, bool isStretched)
    {
        button.HorizontalAlignment = isStretched ? HorizontalAlignment.Stretch : HorizontalAlignment.Center;
        button.VerticalAlignment = isStretched ? VerticalAlignment.Stretch : VerticalAlignment.Center;
    }
}