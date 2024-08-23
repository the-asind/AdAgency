using System.Windows;
using System.Windows.Controls;
using AdAgency.Data;
using AdAgency.ViewModels;

namespace AdAgency.Views;

public partial class AdminPanel : Window
{
    private readonly string _username;
    public AdminPanel(string username)
    {
        _username = username;
        InitializeComponent();
        var context = new AdAgencyContext();
        DataContext = new AdminPanelViewModel(context, username);
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        ((AdminPanelViewModel)DataContext).SaveDbTableData();
    }

    private void DbComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ((AdminPanelViewModel)DataContext).LoadDbTableData();
    }

    private void CreateAccountButton_Click(object sender, RoutedEventArgs e)
    {
        var username = usernameTextBox.Text;
        var password = passwordBox.Password;
        var role = ((ComboBoxItem)roleComboBox.SelectedItem).Content.ToString();
        int? renterId = null;
        if (renterID.Text != "")
            renterId = int.Parse(renterID.Text);
        ((AdminPanelViewModel)DataContext).CreateAccount(username, password, role, renterId);
    }

    private void BackToMain_OnClick(object sender, RoutedEventArgs e)
    {
        if (_username == null) return;
        var mainWindow = new MainView(_username);
        mainWindow.Show();
        if (Application.Current.MainWindow != null)
            Application.Current.MainWindow.Close();
        Application.Current.MainWindow = mainWindow;
    }
}