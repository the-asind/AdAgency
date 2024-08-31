using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
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
        
        public string? Status { get; set; }
        public string? LegalAddress { get; set; }
        public string? DirectorName { get; set; }
        public string? DirectorPhone { get; set; }
        public string? ContactPersonName { get; set; }
        public string? ContactPersonPhone { get; set; }
        public string? BankName { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? Inn { get; set; }

        public ICommand RegisterCommand { get; }

        public RegistrationViewModel(AdAgencyContext context)
        {
            _context = context;
            RegisterCommand = new RelayCommand(Register);
        }

        private void Register()
        {
            if (string.IsNullOrWhiteSpace(AgencyName) ||
                string.IsNullOrWhiteSpace(Status) ||
                string.IsNullOrWhiteSpace(LegalAddress) ||
                string.IsNullOrWhiteSpace(DirectorName) ||
                string.IsNullOrWhiteSpace(DirectorPhone) ||
                string.IsNullOrWhiteSpace(ContactPersonName) ||
                string.IsNullOrWhiteSpace(ContactPersonPhone) ||
                string.IsNullOrWhiteSpace(BankName) ||
                string.IsNullOrWhiteSpace(BankAccountNumber) ||
                string.IsNullOrWhiteSpace(Inn) ||
                string.IsNullOrWhiteSpace(Username) ||
                string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Все поля должны быть заполнены.");
                return;
            }

            if (!Regex.IsMatch(Inn, @"^\d{10,12}$"))
            {
                MessageBox.Show("Некорректный ИНН. ИНН должен состоять из 10 или 12 цифр.");
                return;
            }

            if (!Regex.IsMatch(DirectorPhone, @"^\+7\d{10}$") || !Regex.IsMatch(ContactPersonPhone, @"^\+7\d{10}$"))
            {
                MessageBox.Show("Некорректный номер телефона. Номер должен начинаться с +7 и содержать 10 цифр после.");
                return;
            }

            if (!Regex.IsMatch(Username, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$"))
            {
                MessageBox.Show("Некорректный email. Пожалуйста, введите корректный email.");
                return;
            }
            
            var existingUser = _context.Users.FirstOrDefault(u => u.Username == Username);
            if (existingUser != null)
            {
                MessageBox.Show("Пользователь с таким логином уже существует. Пожалуйста, выберите другой логин.");
                return;
            }

            var newUser = new User
            {
                Username = Username,
                PasswordHash = PasswordHasher.HashPassword(Password),
                Role = "renter",
                Renter = new Renter
                {
                    Name = AgencyName,
                    Status = Status.Replace("System.Windows.Controls.ComboBoxItem: ", ""),
                    LegalAddress = LegalAddress,
                    DirectorName = DirectorName,
                    DirectorPhone = DirectorPhone,
                    ContactPersonName = ContactPersonName,
                    ContactPersonPhone = ContactPersonPhone,
                    BankName = BankName,
                    BankAccountNumber = BankAccountNumber,
                    Inn = Inn
                }
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

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