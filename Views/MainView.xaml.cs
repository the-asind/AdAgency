using System.Windows;
using AdAgency.Data;
using AdAgency.ViewModels;

namespace AdAgency.Views;

public partial class MainView : Window
{
    public MainView(string username)
    {
        InitializeComponent();
        var context = new AdAgencyContext();
        DataContext = new MainViewModel(context, username);
    }
    
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        if (DataContext is not MainViewModel viewModel) return;
        switch (viewModel.Role)
        {
            case MainViewModel.UserRole.Admin:
                ConfiguratorButton.Visibility = Visibility.Collapsed;
                RenterButton.Visibility = Visibility.Collapsed;
                renterOutput.Visibility = Visibility.Collapsed;
                AuditGrid.Visibility = Visibility.Visible;
                break;
            case MainViewModel.UserRole.Renter:
                AdminButton.Visibility = Visibility.Collapsed;
                ConfiguratorButton.Visibility = Visibility.Collapsed;
                RenterGrid.Visibility = Visibility.Collapsed;
                break;
            case MainViewModel.UserRole.Configurator:
                AdminButton.Visibility = Visibility.Collapsed;
                RenterButton.Visibility = Visibility.Collapsed;
                renterOutput.Visibility = Visibility.Collapsed;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}