using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using AdAgency.Data;
using AdAgency.Models;
using AdAgency.Views;
using Microsoft.EntityFrameworkCore;

namespace AdAgency.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public enum UserRole
        {
            Admin,
            Renter,
            Configurator
        }
        
        private UserRole _role;

        public UserRole Role
        {
            get => _role;
            set
            {
                _role = value;
                OnPropertyChanged();
            }
        }
        
        private ObservableCollection<Billboard>? _availableBillboards;
        private AdAgencyContext _context;

        public ObservableCollection<Billboard>? AvailableBillboards
        {
            get => _availableBillboards;
            set
            {
                _availableBillboards = value;
                OnPropertyChanged();
            }
        }

        public ICommand OrderBillboardCommand { get; }

        private string? _username;
        public string? Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        private Renter? RenterInfo { get; set; }
        public ObservableCollection<ContractBillboard>? ContractsBillboards { get; set; }
        public ObservableCollection<Contract>? Contracts { get; set; }
        public ObservableCollection<AdvertisementWork>? AdvertisementWorks { get; set; }

        public ICommand AdminPanelCommand { get; set; }
        public ICommand ConfigureBillboardsCommand { get; set; }
        
        private string _renterOutput;
        public string RenterOutput
        {
            get => _renterOutput;
            set
            {
                _renterOutput = value;
                OnPropertyChanged();
            }
        }
        
        public MainViewModel(AdAgencyContext context, string username)
        {
            _context = context;
            LoadBillboards();
            OrderBillboardCommand = new RelayCommand(OrderBillboard);
            AdminPanelCommand = new RelayCommand(OpenAdminPanel, CanOpenAdminPanel);
            ConfigureBillboardsCommand = new RelayCommand(ConfigureBillboards, CanConfigureBillboards);
            Username = username;    
            
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            Role = user?.Role switch
            {
                "admin" => UserRole.Admin,
                "renter" => UserRole.Renter,
                "configurator" => UserRole.Configurator,
                _ => throw new Exception("Invalid user role")
            };
            
            RenterInfo = _context.Renters.AsEnumerable().FirstOrDefault(r => r.RenterId == user?.RenterId);
            ContractsBillboards = new ObservableCollection<ContractBillboard>(_context.ContractBillboards
                .Include(contractBillboard => contractBillboard.Contract).AsEnumerable().Where(cb => RenterInfo != null && cb.Contract.RenterId == RenterInfo.RenterId).ToList());
            Contracts = new ObservableCollection<Contract>(_context.Contracts.AsEnumerable().Where(c => RenterInfo != null && c.RenterId == RenterInfo.RenterId).ToList());
            //AdvertisementWorks = new ObservableCollection<AdvertisementWork>(_context.AdvertisementWorks.AsEnumerable().Where(aw => RenterInfo != null && aw.Contract.RenterId == RenterInfo.RenterId).ToList());
            AdvertisementWorks =
                new ObservableCollection<AdvertisementWork>(_context.AdvertisementWorks.OfType<AdvertisementWork>()
                    .ToList());
            RenterOutput = user.Renter?.ToString() ?? "Информация об арендаторе отсутствует";

            
        }

        private void LoadBillboards()
        {
            AvailableBillboards = new ObservableCollection<Billboard>(_context.Billboards.ToList());
        }

        private void OpenAdminPanel()
        {
            if (Username == null) return;
            var adminPanel = new AdminPanel(Username);
            adminPanel.Show();
            if (Application.Current.MainWindow != null) 
                Application.Current.MainWindow.Close();
            Application.Current.MainWindow = adminPanel;
        }
        
        private bool CanOpenAdminPanel() => UserRole.Admin == Role;

        private void ConfigureBillboards()
        {
            // Implement logic to configure billboards
        }

        private bool CanConfigureBillboards() => UserRole.Configurator == Role;

        private void OrderBillboard()
        {
            // Implement logic to order a billboard
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}