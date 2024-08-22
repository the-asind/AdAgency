using System.Windows;
using System.Windows.Controls;
using AdAgency.Data;
using AdAgency.ViewModels;

namespace AdAgency.Views;

public partial class AdminPanel : Window
{
    public AdminPanel(string username)
    {
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
}