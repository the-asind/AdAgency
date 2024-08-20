using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AdAgency.Data;
using AdAgency.Models;
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
        
        
        public MainViewModel(AdAgencyContext context, string username)
        {
            _context = context;
            LoadBillboards();
            OrderBillboardCommand = new RelayCommand(OrderBillboard);
            AdminPanelCommand = new RelayCommand(OpenAdminPanel, CanOpenAdminPanel);
            ConfigureBillboardsCommand = new RelayCommand(ConfigureBillboards, CanConfigureBillboards);
            Username = username;    
            
            // Determine user role based on username
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            Role = user?.Role switch
            {
                "admin" => UserRole.Admin,
                "renter" => UserRole.Renter,
                "configurator" => UserRole.Configurator,
                _ => throw new System.Exception("Invalid user role")
            };
            
            // Added logic to get the renter info, contracts_billboards, contracts, and advertisement_works
            RenterInfo = _context.Renters.AsEnumerable().FirstOrDefault(r => r.Name == Username);
            ContractsBillboards = new ObservableCollection<ContractBillboard>(_context.ContractBillboards
                .Include(contractBillboard => contractBillboard.Contract).AsEnumerable().Where(cb => RenterInfo != null && cb.Contract.RenterId == RenterInfo.RenterId).ToList());
            Contracts = new ObservableCollection<Contract>(_context.Contracts.AsEnumerable().Where(c => RenterInfo != null && c.RenterId == RenterInfo.RenterId).ToList());
            AdvertisementWorks = new ObservableCollection<AdvertisementWork>(_context.AdvertisementWorks.AsEnumerable().Where(aw => RenterInfo != null && aw.Contract.RenterId == RenterInfo.RenterId).ToList());
        }

        private void LoadBillboards()
        {
            AvailableBillboards = new ObservableCollection<Billboard>(_context.Billboards.ToList());
        }

        private void OpenAdminPanel()
        {
            // Implement logic to open the admin panel
        }

        private bool CanOpenAdminPanel()
        {
            // Implement logic to check if the user is an admin
            return true; // Replace with actual logic
        }

        private void ConfigureBillboards()
        {
            // Implement logic to configure billboards
        }

        private bool CanConfigureBillboards()
        {
            // Implement logic to check if the user is a manager
            return true; // Replace with actual logic
        }

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