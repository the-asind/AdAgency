using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AdAgency.Data;
using AdAgency.Models;

namespace AdAgency.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Billboard> _availableBillboards;
        private AdAgencyContext _context;

        public ObservableCollection<Billboard> AvailableBillboards
        {
            get => _availableBillboards;
            set
            {
                _availableBillboards = value;
                OnPropertyChanged();
            }
        }

        public ICommand OrderBillboardCommand { get; }

        public MainViewModel()
        {
            _context = new AdAgencyContext();
            LoadBillboards();
            OrderBillboardCommand = new RelayCommand(OrderBillboard);
        }

        private void LoadBillboards()
        {
            AvailableBillboards = new ObservableCollection<Billboard>(_context.Billboards.ToList());
        }

        private void OrderBillboard()
        {
            // Implement order logic here
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}