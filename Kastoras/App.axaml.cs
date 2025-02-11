using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Controls.ApplicationLifetimes;
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
    public static readonly AttachedProperty<IImage> IconSourceProperty =
        AvaloniaProperty.RegisterAttached<ButtonExtensions, Button, IImage>("IconSource");

    public static readonly AttachedProperty<bool> IsStretchedProperty =
        AvaloniaProperty.RegisterAttached<ButtonExtensions, Button, bool>("IsStretched");

    // Getters and setters
    public static void SetIconSource(Button element, IImage value) 
        => element.SetValue(IconSourceProperty, value);
    
    public static IImage GetIconSource(Button element) 
        => element.GetValue(IconSourceProperty);
    
    public static void SetIsStretched(Button element, bool value) 
        => element.SetValue(IsStretchedProperty, value);
    
    public static bool GetIsStretched(Button element) 
        => element.GetValue(IsStretchedProperty);
}