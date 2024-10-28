using System.Windows;
using AdAgency.Data;
using AdAgency.ViewModels;

namespace AdAgency.Views;

public partial class RenterPanel : Window
{
    private readonly string _username;

    public RenterPanel(string username)
    {
        _username = username;
        InitializeComponent();
        var context = new AdAgencyContext();
        DataContext = new RenterPanelViewModel(context, username);
    }

    private void BackToMainMenu_Click(object sender, RoutedEventArgs e)
    {
        var mainWindow = new MainView(_username);
        mainWindow.Show();
        Application.Current.MainWindow?.Close();
        Application.Current.MainWindow = mainWindow;
    }
}