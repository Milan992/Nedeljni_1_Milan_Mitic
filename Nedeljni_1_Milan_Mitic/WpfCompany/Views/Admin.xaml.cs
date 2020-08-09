using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfCompany.Model;
using WpfCompany.ViewModels;

namespace WpfCompany.Views
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
            this.DataContext = new AdminViewModel(this);
        }
        public Admin(tblAccount account, tblAdministrator admin)
        {
            InitializeComponent();
            this.DataContext = new AdminViewModel(this, account, admin);
        }
    }
}
