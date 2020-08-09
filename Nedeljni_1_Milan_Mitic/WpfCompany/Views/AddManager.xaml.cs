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
    /// Interaction logic for AddManager.xaml
    /// </summary>
    public partial class AddManager : Window
    {
        public AddManager()
        {
            InitializeComponent();
            this.DataContext = new AddManagerViewModel(this);
        }

        public AddManager(tblAccount acountAdd)
        {
            InitializeComponent();
            this.DataContext = new AddManagerViewModel(this, acountAdd);
        }
    }
}
