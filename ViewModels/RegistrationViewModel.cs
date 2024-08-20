using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using AdAgency.Data;
using AdAgency.Models;
using AdAgency.Views;

namespace AdAgency.ViewModels
{
    public class RegistrationViewModel : INotifyPropertyChanged
    {
        private string? _username;
        private string? _password;
        private string? _agencyName;
        private AdAgencyContext _context;

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
                OnPropertyChanged();
            }
        }

        public string? AgencyName
        {
            get => _agencyName;
            set
            {
                _agencyName = value;
                OnPropertyChanged();
            }
        }

        public ICommand RegisterCommand { get; }

        public RegistrationViewModel(AdAgencyContext context)
        {
            _context = new AdAgencyContext();
            RegisterCommand = new RelayCommand(Register);
        }

        private void Register()
        {
            var newUser = new User
            {
                Username = Username,
                PasswordHash = Password,
                Role = "Agency",
                Renter = new Renter
                {
                    Name = AgencyName,
                    Status = "ООО",
                    LegalAddress = "",
                    DirectorName = "",
                    DirectorPhone = "",
                    Inn = "",
                    ContactPersonName = "null",
                    ContactPersonPhone = "null",
                    BankName = "null",
                    BankAccountNumber = "null"
                }
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            // Redirect to login after registration
            var loginView = new LoginView();
            loginView.Show();
            if (Application.Current.MainWindow != null) 
                Application.Current.MainWindow.Close();
            Application.Current.MainWindow = loginView;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
