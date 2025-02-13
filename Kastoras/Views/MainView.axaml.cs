using Avalonia.Controls;
using Kastoras.ViewModels;
using Kastoras.Controls;

namespace Kastoras.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}