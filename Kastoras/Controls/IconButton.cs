using System;
using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;

namespace Kastoras.Controls;

public class IconButton : TemplatedControl
{
    public static readonly StyledProperty<IImage> IconProperty =
        AvaloniaProperty.Register<IconButton, IImage>(nameof(Icon));

    public static readonly StyledProperty<object> TextProperty =
        AvaloniaProperty.Register<IconButton, object>(nameof(Text));
    
    public static readonly StyledProperty<HorizontalAlignment> HorizontalContentAlignmentProperty =
        AvaloniaProperty.Register<IconButton, HorizontalAlignment>(nameof(HorizontalContentAlignment));

    public static readonly StyledProperty<VerticalAlignment> VerticalContentAlignmentProperty =
        AvaloniaProperty.Register<IconButton, VerticalAlignment>(nameof(VerticalContentAlignment));
    
    public event EventHandler<RoutedEventArgs> Click;
    
    protected virtual void OnClick()
    {
        Click?.Invoke(this, new RoutedEventArgs());
    }

    // Add a method to trigger the click, e.g. from a tap gesture
    protected override void OnPointerReleased(PointerReleasedEventArgs e)
    {
        base.OnPointerReleased(e);
        if (e.InitialPressMouseButton == MouseButton.Left)
        {
            OnClick();
        }
    }
    
    public HorizontalAlignment HorizontalContentAlignment
    {
        get => GetValue(HorizontalContentAlignmentProperty);
        set => SetValue(HorizontalContentAlignmentProperty, value);
    }

    public VerticalAlignment VerticalContentAlignment
    {
        get => GetValue(VerticalContentAlignmentProperty);
        set => SetValue(VerticalContentAlignmentProperty, value);
    }

    public IImage Icon
    {
        get { return GetValue(IconProperty); }
        set { SetValue(IconProperty, value); }
    }

    public object Text
    {
        get { return GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }

    static IconButton()
    {
        TextProperty.Changed.AddClassHandler<IconButton>((s, e) => s.InvalidateFormattedText());
    }

    private FormattedText? _formattedText;

    private FormattedText CreateFormattedText()
    {
        return new FormattedText(
            Text?.ToString() ?? string.Empty,
            System.Globalization.CultureInfo.CurrentUICulture,
            Avalonia.Media.FlowDirection.LeftToRight,
            new Typeface(FontFamily, FontStyle, FontWeight),
            FontSize,
            Foreground);
    }

    private void InvalidateFormattedText()
    {
        _formattedText = null;
    }

    public override void Render(DrawingContext context)
    {
        _formattedText ??= CreateFormattedText();

        base.Render(context);
    }
}