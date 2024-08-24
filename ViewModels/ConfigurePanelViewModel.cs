using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Input;
using AdAgency.Data;
using AdAgency.Models;

namespace AdAgency.ViewModels;

public class ConfigurePanelViewModel : INotifyPropertyChanged
{
    private readonly AdAgencyContext _context;
    private Billboard _billboard;

    public Billboard Billboard
    {
        get => _billboard;
        set
        {
            _billboard = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<Billboard> Billboards { get; }

    public ICommand CreateBillboardCommand { get; }

    public ConfigurePanelViewModel(AdAgencyContext context, string username)
    {
        _context = context;
        Billboard = new Billboard
        {
            RegistrationNumber = "",
            CityDistrict = "",
            Address = ""
        };
        Billboards = new ObservableCollection<Billboard>(_context.Billboards.ToList());
        CreateBillboardCommand = new RelayCommand(CreateBillboard);
    }

    private void CreateBillboard()
    {
        if (string.IsNullOrWhiteSpace(Billboard.RegistrationNumber) ||
            string.IsNullOrWhiteSpace(Billboard.CityDistrict) ||
            string.IsNullOrWhiteSpace(Billboard.Address))
        {
            MessageBox.Show("Не были заполнены обязательные поля", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }

        var existingBillboard =
            _context.Billboards.FirstOrDefault(b => b.RegistrationNumber == Billboard.RegistrationNumber);

        if (existingBillboard != null)
        {
            existingBillboard.CityDistrict = Billboard.CityDistrict;
            existingBillboard.Address = Billboard.Address;
            existingBillboard.LocationDescription = Billboard.LocationDescription;
            existingBillboard.UsefulArea = Billboard.UsefulArea;
        }
        else
        {
            _context.Billboards.Add(Billboard);
            Billboards.Add(Billboard);
        }

        _context.SaveChanges();

        Billboard = new Billboard
        {
            RegistrationNumber = "",
            CityDistrict = "",
            Address = ""
        };
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}