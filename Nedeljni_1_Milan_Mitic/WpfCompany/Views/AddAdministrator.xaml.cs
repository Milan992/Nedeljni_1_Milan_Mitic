using System.Windows;
using WpfCompany.ViewModels;

namespace WpfCompany.Views
{
    /// <summary>
    /// Interaction logic for AddAdministrator.xaml
    /// </summary>
    public partial class AddAdministrator : Window
    {
        public AddAdministrator()
        {
            InitializeComponent();
            this.DataContext = new AddAdministratorViewModel(this);
        }
    }
}
