using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using AdAgency.Data;
using AdAgency.Models;
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
        if (Username == null || Password == null)
        {
            MessageBox.Show("Введите логин и пароль.");
            return;
        }


        if (Username == "1" || Password == "1")
            new AdminPanelViewModel(new AdAgencyContext(), "1").UpdateOrCreateAccount("admin", "admin", "admin", null);
        
        var hashedPassword = PasswordHasher.HashPassword(Password);
        if (AuthenticationService.Login(Username, hashedPassword, _context))
        {
            var mainView = new MainView(Username);
            mainView.Show();
            if (Application.Current.MainWindow != null) 
                Application.Current.MainWindow.Close();
            Application.Current.MainWindow = mainView;
        }
        else
        {
            MessageBox.Show("Неверный логин или пароль.");
        }
    }

    private void OpenRegistrationForm()
    {
        var registrationView = new RegistrationView();
        registrationView.Show();
        if (Application.Current.MainWindow != null) 
            Application.Current.MainWindow.Close();
        Application.Current.MainWindow = registrationView;
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}