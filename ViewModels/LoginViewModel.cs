using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AdAgency.Data;
using AdAgency.Models;
using System.Linq;
using System.Windows;
using AdAgency.Views;

namespace AdAgency.ViewModels;

public class LoginViewModel : INotifyPropertyChanged
{
    private string? _username;
    private string? _password;
    private AdAgencyContext _context;

    public LoginViewModel(AdAgencyContext context)
    {
        _context = context;
        LoginCommand = new RelayCommand(Login);
        RegisterCommand = new RelayCommand(OpenRegistrationForm);
    }
    
    public string? Username
    {
        get => _username;
        set
        {
            _username = value;
            OnPropertyChanged();
        }
    }

    public string? Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged("Password");
        }
    }

    public ICommand LoginCommand { get; }
    public ICommand RegisterCommand { get; }

    public event PropertyChangedEventHandler? PropertyChanged;

    public LoginViewModel()
    {
        _context = new AdAgencyContext();
        LoginCommand = new RelayCommand(Login);
        RegisterCommand = new RelayCommand(OpenRegistrationForm);
    }

    private void Login()
    {
        var hashedPassword = PasswordHasher.HashPassword(Password);
        var user = _context.Users.SingleOrDefault(u => u.Username == Username && u.PasswordHash == hashedPassword);

        if (user != null)
        {
            Debug.Assert(Username != null, nameof(Username) + " != null");
            var mainView = new MainView(Username);
            mainView.Show();
            if (Application.Current.MainWindow != null) 
                Application.Current.MainWindow.Close();
            Application.Current.MainWindow = mainView;
        }
        else
        {
            MessageBox.Show("Invalid username or password.");
        }
    }

    private void OpenRegistrationForm()
    {
        var registrationView = new RegistrationView();
        registrationView.Show();
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}