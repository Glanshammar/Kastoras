using Avalonia.Controls;
using Kastoras.ViewModels;

namespace Kastoras.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}