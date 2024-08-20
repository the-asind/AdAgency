using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AdAgency.Data;
using AdAgency.Models;

namespace AdAgency.ViewModels;

public class BillboardViewModel : INotifyPropertyChanged
{
    private readonly AdAgencyContext _context;
    private ObservableCollection<Billboard> _billboards;

    public ObservableCollection<Billboard> Billboards
    {
        get => _billboards;
        set
        {
            _billboards = value;
            OnPropertyChanged();
        }
    }

    public BillboardViewModel()
    {
        _context = new AdAgencyContext();
        LoadBillboards();
    }

    private void LoadBillboards()
    {
        Billboards = new ObservableCollection<Billboard>(_context.Billboards.ToList());
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}