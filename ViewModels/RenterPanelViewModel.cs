using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using AdAgency.Data;
using AdAgency.Models;
using Microsoft.EntityFrameworkCore;

namespace AdAgency.ViewModels;

public class RenterPanelViewModel : INotifyPropertyChanged
{
    private readonly AdAgencyContext _context;
    private Billboard _selectedBillboard;
    private DateTime? _rentStartDate;
    private int _rentDurationWeeks;
    private DateTime? _rentEndDate;
    private decimal _rentCost;
    private decimal _rentCostTotal;
    private readonly int _renterId;
    private readonly string _renterName;

    public ObservableCollection<Billboard> AvailableBillboards { get; private set; }
    public ICommand BuyBillboardCommand { get; }

    public Billboard? SelectedBillboard
    {
        get => _selectedBillboard;
        set
        {
            _selectedBillboard = value;
            OnPropertyChanged();
            CalculateRentCost();
        }
    }

    public DateTime? RentStartDate
    {
        get => _rentStartDate;
        set
        {
            if (value < DateTime.Today.AddDays(1))
            {
                MessageBox.Show("Начало аренды должно быть не раньше завтрашней даты.");
                return;
            }

            _rentStartDate = value;
            OnPropertyChanged();
            UpdateAvailableBillboards();
            CalculateRentEndDate();
            CalculateRentCost();
        }
    }

    public int RentDurationWeeks
    {
        get => _rentDurationWeeks;
        set
        {
            _rentDurationWeeks = value;
            OnPropertyChanged();
            CalculateRentEndDate();
            CalculateRentCost();
        }
    }

    public DateTime? RentEndDate
    {
        get => _rentEndDate;
        private set
        {
            _rentEndDate = value;
            OnPropertyChanged();
        }
    }

    public decimal RentCost
    {
        get => _rentCost;
        private set
        {
            _rentCost = value;
            OnPropertyChanged();
        }
    }

    public decimal RentCostTotal
    {
        get => _rentCostTotal;
        private set
        {
            _rentCostTotal = value;
            OnPropertyChanged();
        }
    }

    private readonly string _username;

    private string _advertisementPhotoLink = string.Empty;
    private bool _isAdvertisementPhotoLinkValid;
    private string _paymentType = string.Empty;
    private string _additionalTerms = string.Empty;

    public string AdvertisementPhotoLink
    {
        get => _advertisementPhotoLink;
        set
        {
            _advertisementPhotoLink = value;
            OnPropertyChanged();
            _ = ValidateAdvertisementPhotoLinkAsync();
        }
    }

    public bool IsAdvertisementPhotoLinkValid
    {
        get => _isAdvertisementPhotoLinkValid;
        private set
        {
            _isAdvertisementPhotoLinkValid = value;
            OnPropertyChanged();
            ((RelayCommand)BuyBillboardCommand).RaiseCanExecuteChanged();
        }
    }

    public string PaymentType
    {
        get => _paymentType;
        set
        {
            _paymentType = value;
            OnPropertyChanged();
        }
    }

    public string AdditionalTerms
    {
        get => _additionalTerms;
        set
        {
            _additionalTerms = value;
            OnPropertyChanged();
        }
    }

    public RenterPanelViewModel(AdAgencyContext context, string username)
    {
        _context = context;
        _username = username;
        var user = _context.Users.Include(u => u.Renter).FirstOrDefault(u => u.Username == username);
        if (user != null && user.Renter != null)
        {
            _renterId = user.Renter.RenterId;
            _renterName = user.Renter.Name;
        }
        else
        {
            throw new Exception("User or associated renter not found.");
        }

        AvailableBillboards = new ObservableCollection<Billboard>(_context.Billboards.ToList());
        BuyBillboardCommand = new RelayCommand(BuyBillboard, CanBuyBillboard);
    }

    private void CalculateRentEndDate()
    {
        if (RentStartDate.HasValue && RentDurationWeeks > 0)
            RentEndDate = RentStartDate.Value.AddDays(RentDurationWeeks * 7);
        else
            RentEndDate = null;
        OnPropertyChanged(nameof(RentEndDateFormatted));
    }

    public string RentEndDateFormatted =>
        RentEndDate.HasValue ? RentEndDate.Value.ToString("dd.MM.yyyy") : string.Empty;

    public int InstallWorkCost => 3000;
    public string InstallWorkCostFormatted => InstallWorkCost.ToString();

    public int UninstallWorkCost => 2000;
    public string UninstallWorkCostFormatted => UninstallWorkCost.ToString();

    private void CalculateRentCost()
    {
        if (SelectedBillboard == null || !RentStartDate.HasValue || !RentEndDate.HasValue) return;
        if (RentDurationWeeks > 0)
        {
            RentCost = SelectedBillboard.RentAmountPerWeek * RentDurationWeeks;
            RentCostTotal = RentCost + InstallWorkCost + UninstallWorkCost;
        }
        else
        {
            RentCost = 0;
            RentCostTotal = 0;
        }
    }

    private void UpdateAvailableBillboards()
    {
        if (!RentStartDate.HasValue || !RentEndDate.HasValue) return;

        var startDate = RentStartDate.Value;
        var endDate = RentEndDate.Value;

        var availableBillboards = _context.Billboards
            .Where(b => !_context.ContractBillboards.Any(cb =>
                cb.BillboardId == b.BillboardId &&
                ((DateTime.FromBinary(BitConverter.ToInt64(BitConverter.GetBytes(cb.RentStartDate.Value.ToBinary()), 0)) <= startDate &&
                  DateTime.FromBinary(BitConverter.ToInt64(BitConverter.GetBytes(cb.RentEndDate.Value.ToBinary()), 0)) >= startDate) ||
                 (DateTime.FromBinary(BitConverter.ToInt64(BitConverter.GetBytes(cb.RentStartDate.Value.ToBinary()), 0)) <= endDate &&
                  DateTime.FromBinary(BitConverter.ToInt64(BitConverter.GetBytes(cb.RentEndDate.Value.ToBinary()), 0)) >= endDate) ||
                 (DateTime.FromBinary(BitConverter.ToInt64(BitConverter.GetBytes(cb.RentStartDate.Value.ToBinary()), 0)) >= startDate &&
                  DateTime.FromBinary(BitConverter.ToInt64(BitConverter.GetBytes(cb.RentEndDate.Value.ToBinary()), 0)) <= endDate))))
            .ToList();

        AvailableBillboards = new ObservableCollection<Billboard>(availableBillboards);
        OnPropertyChanged(nameof(AvailableBillboards));
    }

    private async Task ValidateAdvertisementPhotoLinkAsync()
    {
        if (Uri.TryCreate(AdvertisementPhotoLink, UriKind.Absolute, out var uriResult)
            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Head, uriResult));
                    if (response.IsSuccessStatusCode)
                    {
                        IsAdvertisementPhotoLinkValid = true;
                        return;
                    }
                }
            }
            catch
            {
                IsAdvertisementPhotoLinkValid = false;
            }

        IsAdvertisementPhotoLinkValid = false;
    }

    private void BuyBillboard()
    {
        if (SelectedBillboard == null || !RentStartDate.HasValue || !RentEndDate.HasValue ||
            !IsAdvertisementPhotoLinkValid)
            return;

        var contractNumber = $"{SelectedBillboard.RegistrationNumber}-{_context.Contracts.Count() + 1:D6}";

        var contract = new Contract
        {
            RenterId = _renterId,
            SigningDate = DateTime.UtcNow,
            AgencyResponsible = "Василий Гальперов Анатольевич",
            Status = "active",
            TotalAmount = RentCostTotal,
            PaymentType = PaymentType.Replace("System.Windows.Controls.ComboBoxItem: ", ""),
            AdditionalTerms = AdditionalTerms,
            ContractNumber = contractNumber
        };

        _context.Contracts.Add(contract);
        _context.SaveChanges();

        var contractBillboard = new ContractBillboard
        {
            ContractId = contract.ContractId,
            BillboardId = SelectedBillboard.BillboardId,
            RentStartDate = RentStartDate?.ToUniversalTime(),
            RentEndDate = RentEndDate?.ToUniversalTime(),
            RentAmount = RentCostTotal,
            AdvertisementPhotoLink = AdvertisementPhotoLink
        };

        _context.ContractBillboards.Add(contractBillboard);
        _context.SaveChanges();

        MessageBox.Show("Рекламный щит оформлен успешно!\n" +
                        $"Номер договора: {contractNumber}\n" +
                        $"Стоимость аренды: {RentCostTotal} руб.\n" +
                        $"Дата начала аренды: {RentStartDate.Value:dd.MM.yyyy}\n" +
                        $"Дата окончания аренды: {RentEndDate.Value:dd.MM.yyyy}");
    }

    private bool CanBuyBillboard()
    {
        return SelectedBillboard != null && RentStartDate.HasValue && RentEndDate.HasValue &&
               IsAdvertisementPhotoLinkValid;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}