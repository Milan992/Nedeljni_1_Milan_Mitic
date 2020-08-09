using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCompany.Model;
using WpfCompany.Views;

namespace WpfCompany.ViewModels
{
    class EmployeeViewModel : ViewModelBase
    {
        Employee employeee;
        Service service = new Service();

        #region Constructors

        public EmployeeViewModel(Employee employeeOpen)
        {
            employeee = employeeOpen;
        }

        public EmployeeViewModel(Employee employeeOpen, tblAccount accountToView, tblEmployee employeeToView)
        {
            employeee = employeeOpen;
            account = accountToView;
            employee = employeeToView;
        }

        #endregion

        #region Properties

        private tblAccount account;

        public tblAccount Account
        {
            get { return account; }
            set
            {
                account = value;
                OnPropertyChanged("Account");
            }
        }

        private tblEmployee employee;

        public tblEmployee Employee
        {
            get { return employee; }
            set
            {
                employee = value;
                OnPropertyChanged("Employee");
            }
        }

        #endregion
    }
}
