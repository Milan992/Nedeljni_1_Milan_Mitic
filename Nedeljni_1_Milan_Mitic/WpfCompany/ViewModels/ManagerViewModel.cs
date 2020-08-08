using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCompany.Model;
using WpfCompany.Views;

namespace WpfCompany.ViewModels
{
    class ManagerViewModel : ViewModelBase
    {
        Manager managerr;
        Service service = new Service();

        #region Constructors

        public ManagerViewModel(Manager managerOpen)
        {
            managerr = managerOpen;
        }

        public ManagerViewModel(Manager managerOpen, tblAccount accountToView, tblManager managerToView)
        {
            managerr = managerOpen;
            account = accountToView;
            manager = managerToView;
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

        private tblManager manager;

        public tblManager Manager
        {
            get { return manager; }
            set
            {
                manager = value;
                OnPropertyChanged("Manager");
            }
        }

        #endregion
    }
}
