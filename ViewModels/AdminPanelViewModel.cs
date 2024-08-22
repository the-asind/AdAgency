using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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

    public ObservableCollection<object> DbTableData
    {
        get => _dbTableData;
        set
        {
            _dbTableData = value;
            OnPropertyChanged();
        }
    }

    public AdminPanelViewModel(AdAgencyContext context)
    {
        _context = context;
        DbTableData = new ObservableCollection<object>();
    }

    public void LoadDbTableData()
    {
        if (SelectedDbTable == null) return;
        DbTableData = SelectedDbTable switch
        {
            "AdvertisementWork" => new ObservableCollection<object>(_context.AdvertisementWorks.ToList()),
            "AuditLogs" => new ObservableCollection<object>(_context.AuditLogs.ToList()),
            "Billboard" => new ObservableCollection<object>(_context.Billboards.ToList()),
            "Contract" => new ObservableCollection<object>(_context.Contracts.ToList()),
            "ContractBillboard" => new ObservableCollection<object>(_context.ContractBillboards.ToList()),
            "Renter" => new ObservableCollection<object>(_context.Renters.ToList()),
            "User" => new ObservableCollection<object>(_context.Users.ToList()),
            _ => DbTableData
        };
    }

    public void SaveDbTableData()
    {
        switch (SelectedDbTable)
        {
            case "AdvertisementWork":
                foreach (AdvertisementWork item in DbTableData)
                    _context.Entry(item).State = item.WorkId == 0 ? EntityState.Added : EntityState.Modified;
                break;
            case "AuditLogs":
                foreach (AuditLog item in DbTableData)
                    _context.Entry(item).State = item.LogId == 0 ? EntityState.Added : EntityState.Modified;
                break;
            case "Billboard":
                foreach (Billboard item in DbTableData)
                    _context.Entry(item).State = item.BillboardId == 0 ? EntityState.Added : EntityState.Modified;
                break;
            case "Contract":
                foreach (Contract item in DbTableData)
                    _context.Entry(item).State = item.ContractId == 0 ? EntityState.Added : EntityState.Modified;
                break;
            case "ContractBillboard":
                foreach (ContractBillboard item in DbTableData)
                    _context.Entry(item).State = item.Id == 0 ? EntityState.Added : EntityState.Modified;
                break;
            case "Renter":
                foreach (Renter item in DbTableData)
                    _context.Entry(item).State = item.RenterId == 0 ? EntityState.Added : EntityState.Modified;
                break;
            case "User":
                foreach (User item in DbTableData)
                    _context.Entry(item).State = item.UserId == 0 ? EntityState.Added : EntityState.Modified;
                break;
        }

        _context.SaveChanges();
    }

    public void SaveChanges()
    {
        // Implement logic to save changes to the database
    }

    public void CreateAccount()
    {
        // Implement logic to create a new employee account
    }

    public void EditAccount()
    {
        // Implement logic to edit an existing employee account
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}