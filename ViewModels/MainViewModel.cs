using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using AdAgency.Data;
using AdAgency.Models;
using AdAgency.Views;
using Microsoft.EntityFrameworkCore;

namespace AdAgency.ViewModels;

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
    private readonly AdAgencyContext _context;

    public ObservableCollection<Billboard>? AvailableBillboards
    {
        get => _availableBillboards;
        set
        {
            _availableBillboards = value;
            OnPropertyChanged();
        }
    }

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

    public ObservableCollection<Renter>? RenterInfo { get; set; }
    public ObservableCollection<ContractBillboard>? ContractsBillboards { get; set; }
    public ObservableCollection<Contract>? Contracts { get; set; }
    public ObservableCollection<AdvertisementWork>? AdvertisementWorks { get; set; }

    public ObservableCollection<ContractBillboard>? RentersContractsBillboards { get; set; }
    public ObservableCollection<Contract>? RentersContracts { get; set; }
    public ObservableCollection<AdvertisementWork>? RentersAdvertisementWorks { get; set; }

    public ICommand? AdminPanelCommand { get; set; }
    public ICommand? ConfigureBillboardsCommand { get; set; }
    public ICommand? LogOutCommand { get; set; }

    private string? _renterOutput;

    public string? RenterOutput
    {
        get => _renterOutput;
        set
        {
            _renterOutput = value;
            OnPropertyChanged();
        }
    }

    public ICommand? OpenRenterPanelCommand { get; }

    public MainViewModel(AdAgencyContext context, string username)
    {
        _context = context;
        Username = username;

        var user = _context.Users.Include(user => user.Renter).FirstOrDefault(u => u.Username == username);
        Role = user?.Role switch
        {
            "admin" => UserRole.Admin,
            "renter" => UserRole.Renter,
            "configurator" => UserRole.Configurator,
            _ => throw new Exception("Invalid user role")
        };

        if (UserRole.Renter == Role)
        {
            RenterOutput = user.Renter?.ToString() ?? "Информация об арендаторе отсутствует";
            RentersContracts =
                new ObservableCollection<Contract>(_context.Contracts.Where(c => c.RenterId == user.RenterId).ToList());
            RentersContractsBillboards = new ObservableCollection<ContractBillboard>(_context.ContractBillboards
                .Where(cb => cb.Contract != null && cb.Contract.RenterId == user.RenterId).ToList());
            RentersAdvertisementWorks = new ObservableCollection<AdvertisementWork>(_context.AdvertisementWorks
                .Where(aw => aw.Contract != null && aw.Contract.RenterId == user.RenterId).ToList());
            OpenRenterPanelCommand = new RelayCommand(OpenRenterPanel);
            return;
        }

        RenterInfo = new ObservableCollection<Renter>(_context.Renters.ToList());
        AdminPanelCommand = new RelayCommand(OpenAdminPanel, CanOpenAdminPanel);
        ConfigureBillboardsCommand = new RelayCommand(ConfigureBillboards, CanConfigureBillboards);
        LogOutCommand = new RelayCommand(LogOut, () => true);
        ContractsBillboards = new ObservableCollection<ContractBillboard>(_context.ContractBillboards.ToList());
        Contracts = new ObservableCollection<Contract>(_context.Contracts.ToList());
        AdvertisementWorks = new ObservableCollection<AdvertisementWork>(_context.AdvertisementWorks.ToList());
    }

    private void LogOut()
    {
        var loginWindow = new LoginView();
        loginWindow.Show();
        if (Application.Current.MainWindow != null)
            Application.Current.MainWindow.Close();
        Application.Current.MainWindow = loginWindow;
    }

    private void OpenAdminPanel()
    {
        if (!AuthenticationService.HasPermission("admin")) Environment.Exit(1);
        if (Username == null) return;
        var adminPanel = new AdminPanel(Username);
        adminPanel.Show();
        Application.Current.MainWindow?.Close();
        Application.Current.MainWindow = adminPanel;
    }

    private bool CanOpenAdminPanel()
    {
        return AuthenticationService.HasPermission("admin");
    }

    private void ConfigureBillboards()
    {
        if (Username == null) return;
        var configurePanel = new ConfigurePanel(Username);
        configurePanel.Show();
        if (Application.Current.MainWindow != null)
            Application.Current.MainWindow.Close();
        Application.Current.MainWindow = configurePanel;
    }

    private bool CanConfigureBillboards()
    {
        return AuthenticationService.HasPermission("configurator");
    }

    private void OpenRenterPanel()
    {
        if (Username == null) return;
        var renterPanel = new RenterPanel(Username);
        renterPanel.Show();
        if (Application.Current.MainWindow != null)
            Application.Current.MainWindow.Close();
        Application.Current.MainWindow = renterPanel;
    }

    private ObservableCollection<AuditLog>? _auditLogs;

    public ObservableCollection<AuditLog>? AuditLogs
    {
        get => _auditLogs;
        set
        {
            _auditLogs = value;
            OnPropertyChanged();
        }
    }

    public void LoadAuditLogs()
    {
        AuditLogs = new ObservableCollection<AuditLog>(_context.AuditLogs.ToList());
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}