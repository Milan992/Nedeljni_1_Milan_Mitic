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
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class Employee : Window
    {
        public Employee()
        {
            InitializeComponent();
            this.DataContext = new EmployeeViewModel(this);
        }
        public Employee(tblAccount account, tblEmployee employee)
        {
            InitializeComponent();
            this.DataContext = new EmployeeViewModel(this, account, employee);
        }
    }
}
