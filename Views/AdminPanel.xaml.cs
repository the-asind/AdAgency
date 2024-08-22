using System.Windows;
using System.Windows.Controls;
using AdAgency.Data;
using AdAgency.ViewModels;

namespace AdAgency.Views;

public partial class AdminPanel : Window
{
    public AdminPanel()
    {
        InitializeComponent();
        var context = new AdAgencyContext();
        DataContext = new AdminPanelViewModel(context);
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
        // Implement logic to create a new employee account
    }

    private void EditAccountButton_Click(object sender, RoutedEventArgs e)
    {
        // Implement logic to edit an existing employee account
    }
}