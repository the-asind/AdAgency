using System.Windows;
using System.Windows.Input;
using AdAgency.Data;
using AdAgency.ViewModels;

namespace AdAgency.Views;

public partial class ConfigurePanel : Window
{
    private readonly string _username;

    public ConfigurePanel(string username)
    {
        _username = username;
        InitializeComponent();
        var context = new AdAgencyContext();
        DataContext = new ConfigurePanelViewModel(context, username);
    }

    private void BackToMainMenu_Click(object sender, RoutedEventArgs e)
    {
        var mainWindow = new MainView(_username);
        mainWindow.Show();
        if (Application.Current.MainWindow != null)
            Application.Current.MainWindow.Close();
        Application.Current.MainWindow = mainWindow;
    }

    private void UsefulArea_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        if (!double.TryParse(e.Text, out _)) e.Handled = true;
    }
}