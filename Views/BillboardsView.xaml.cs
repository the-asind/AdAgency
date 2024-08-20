using System.Windows;
using AdAgency.ViewModels;

namespace AdAgency.Views;

public partial class BillboardsView : Window
{
    public BillboardsView()
    {
        InitializeComponent();
        DataContext = new BillboardViewModel();
    }
}