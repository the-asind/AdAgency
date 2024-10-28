using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AdAgency.Data;
using AdAgency.Models;
using Microsoft.EntityFrameworkCore;

namespace AdAgency.ViewModels;

public sealed class AdminPanelViewModel : INotifyPropertyChanged
{
    private string? _selectedDbTable;

    public string? SelectedDbTable
    {
        get => _selectedDbTable?.Replace("System.Windows.Controls.ComboBoxItem: ", "");
        set => _selectedDbTable = value;
    }

    private readonly AdAgencyContext _context;

    private ObservableCollection<object> _dbTableData = null!;
    private readonly string _username;

    public ObservableCollection<object> DbTableData
    {
        get => _dbTableData;
        set
        {
            _dbTableData = value;
            OnPropertyChanged();
        }
    }

    public AdminPanelViewModel(AdAgencyContext context, string username)
    {
        _username = username;
        _context = context;
        DbTableData = new ObservableCollection<object>();
    }

    public void LoadDbTableData()
    {
        if (!AuthenticationService.HasPermission("admin")) Environment.Exit(1);
        switch (SelectedDbTable)
        {
            case null:
                return;
            case "User":
                MessageBox.Show(
                    "Редактирование таблицы пользователей может привести к поломке изменённого аккаунта. После изменения данных придётся перезайти.");
                DbTableData = new ObservableCollection<object>(_context.Users.ToList());
                break;
            case "AdvertisementWork":
                DbTableData = new ObservableCollection<object>(_context.AdvertisementWorks.ToList());
                break;
            case "AuditLogs":
                DbTableData = new ObservableCollection<object>(_context.AuditLogs.ToList());
                break;
            case "Billboard":
                DbTableData = new ObservableCollection<object>(_context.Billboards.ToList());
                break;
            case "Contract":
                DbTableData = new ObservableCollection<object>(_context.Contracts.ToList());
                break;
            case "ContractBillboard":
                DbTableData = new ObservableCollection<object>(_context.ContractBillboards.ToList());
                break;
            case "Renter":
                DbTableData = new ObservableCollection<object>(_context.Renters.ToList());
                break;
            default:
                DbTableData = new ObservableCollection<object>();
                break;
        }
    }

    public void SaveDbTableData()
    {
        if (!AuthenticationService.HasPermission("admin")) Environment.Exit(1);
        try
        {
            switch (SelectedDbTable)
            {
                case "AdvertisementWork":
                    foreach (var item in DbTableData.Cast<AdvertisementWork>())
                        _context.Entry(item).State = item.WorkId == 0 ? EntityState.Added : EntityState.Modified;
                    break;
                case "AuditLogs":
                    foreach (var item in DbTableData.Cast<AuditLog>())
                        _context.Entry(item).State = item.LogId == 0 ? EntityState.Added : EntityState.Modified;
                    break;
                case "Billboard":
                    foreach (var item in DbTableData.Cast<Billboard>())
                        _context.Entry(item).State = item.BillboardId == 0 ? EntityState.Added : EntityState.Modified;
                    break;
                case "Contract":
                    foreach (var item in DbTableData.Cast<Contract>())
                        _context.Entry(item).State = item.ContractId == 0 ? EntityState.Added : EntityState.Modified;
                    break;
                case "ContractBillboard":
                    foreach (var item in DbTableData.Cast<ContractBillboard>())
                        _context.Entry(item).State = item.Id == 0 ? EntityState.Added : EntityState.Modified;
                    break;
                case "Renter":
                    foreach (var item in DbTableData.Cast<Renter>())
                        _context.Entry(item).State = item.RenterId == 0 ? EntityState.Added : EntityState.Modified;
                    break;
                case "User":
                    foreach (var item in DbTableData.Cast<User>())
                        _context.Entry(item).State = item.UserId == 0 ? EntityState.Added : EntityState.Modified;
                    MessageBox.Show("Вы вручную изменили таблицу пользователей. Пожалуйста, перезайдите.");
                    Environment.Exit(0);
                    break;
            }

            _context.SaveChanges();
            MessageBox.Show("Данные успешно сохранены.");
        }
        catch (Exception e)
        {
            MessageBox.Show($"Ошибка сохранения данных: {e}");
        }

        
    }

    private bool CheckLoginExistence(string username)
    {
        return _context.Users.Any(u => u.Username == username);
    }

    public void UpdateOrCreateAccount(string username, string password, string role, int? renterId)
    {
        var userExists = CheckLoginExistence(username);
        var passwordHash = PasswordHasher.HashPassword(password);
        if (userExists)
        {
            var user = _context.Users.First(u => u.Username == username);
            user.PasswordHash = passwordHash;
            user.Role = role;
            user.RenterId = renterId;
            MessageBox.Show($"Аккаунт {username} успешно обновлён.");
        }
        else
        {
            var newUser = new User
            {
                Username = username,
                PasswordHash = passwordHash,
                Role = role,
                RenterId = renterId
            };
            _context.Users.Add(newUser);
            MessageBox.Show($"Аккаунт {username} успешно создан.");
        }

        _context.SaveChanges();
        if (username != _username) return;

        MessageBox.Show("Вы обновили свой аккаунт. Пожалуйста, перезайдите.");
        Environment.Exit(0);
    }

    public void CreateAccount(string username, string password, string role, int? renterId)
    {
        UpdateOrCreateAccount(username, password, role, renterId);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}