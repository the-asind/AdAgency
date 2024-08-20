using System.Windows;
using AdAgency.Data;
using AdAgency.ViewModels;

namespace AdAgency.Views
{
    public partial class RegistrationView : Window
    {
        public RegistrationView()
        {
            InitializeComponent();
            var context = new AdAgencyContext();
            DataContext = new RegistrationViewModel(context);
        }
    }
}