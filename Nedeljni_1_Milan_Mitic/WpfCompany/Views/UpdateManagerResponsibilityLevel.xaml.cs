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
using WpfCompany.ViewModels;

namespace WpfCompany.Views
{
    /// <summary>
    /// Interaction logic for UpdateManagerResponsibilityLevel.xaml
    /// </summary>
    public partial class UpdateManagerResponsibilityLevel : Window
    {
        public UpdateManagerResponsibilityLevel()
        {
            InitializeComponent();
            this.DataContext = new UpdateManagerResponsibilityLevelViewModel(this);
        }
    }
}
