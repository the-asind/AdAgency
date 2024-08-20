using System.Windows;
using AdAgency.Data;
using AdAgency.ViewModels;

namespace AdAgency.Views;

public partial class LoginView : Window
{
    public LoginView()
    {   
        InitializeComponent();
        PasswordBox.PasswordChanged += PasswordBox_PasswordChanged;
        var context = new AdAgencyContext();
        DataContext = new LoginViewModel(context);
    }

    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        if (DataContext is LoginViewModel viewModel)
        {
            viewModel.Password = PasswordBox.Password;
        }
    }
}