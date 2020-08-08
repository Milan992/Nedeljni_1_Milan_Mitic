using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfCompany.Model;
using WpfCompany.Views;

namespace WpfCompany.ViewModels
{
    class AdminViewModel : ViewModelBase
    {
        Admin adminr;
        Service service = new Service();

        #region Constructors

        public AdminViewModel(Admin adminOpen)
        {
            adminr = adminOpen;
        }

        public AdminViewModel(Admin adminOpen, tblAccount accountToView, tblAdministrator adminToView)
        {
            adminr = adminOpen;
            account = accountToView;
            admin = adminToView;
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

        private tblAdministrator admin;

        public tblAdministrator Admin
        {
            get { return admin; }
            set
            {
                admin = value;
                OnPropertyChanged("Admin");
            }
        }

        #endregion

        #region Commands

        private ICommand managerResponsibility;

        public ICommand ManagerResponsibility
        {
            get
            {
                if (managerResponsibility == null)
                {
                    managerResponsibility = new RelayCommand(param => ManagerResponsibilityExecute(), param => CanManagerResponsibilityExecute());
                }

                return managerResponsibility;
            }
        }

        private void ManagerResponsibilityExecute()
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanManagerResponsibilityExecute()
        {
            if (Admin.AdministratorTypeID == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private ICommand deleteAccount;

        public ICommand DeleteAccount
        {
            get
            {
                if (deleteAccount == null)
                {
                    deleteAccount = new RelayCommand(param => DeleteAccountExecute(), param => CanDeleteAccountExecute());
                }

                return deleteAccount;
            }
        }

        private void DeleteAccountExecute()
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanDeleteAccountExecute()
        {
            if (Admin.AdministratorTypeID == 1 || admin.AdministratorTypeID == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
