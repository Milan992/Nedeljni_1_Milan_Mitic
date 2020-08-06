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
    class AddAdministratorViewModel : ViewModelBase
    {
        AddAdministrator addAdministrator;
        Service service = new Service();

        #region Constructors

        public AddAdministratorViewModel(AddAdministrator addAdministratorOpen)
        {
            account = new tblAccount();
            administrator = new tblAdministrator();
            marrigeTypeList = service.GetAllMarrigeTypes();
            AdminTypeList = service.GetAllAdminTypes();
            addAdministrator = addAdministratorOpen;
        }

        #endregion

        #region Properties

        private tblAccount account;

        public tblAccount Account
        {
            get
            {
                return account;
            }
            set
            {
                account = value;
                OnPropertyChanged("Account");
            }
        }

        private tblAdministrator administrator;

        public tblAdministrator Administrator
        {
            get
            {
                return administrator;
            }
            set
            {
                administrator = value;
                OnPropertyChanged("Administrator");
            }
        }

        private List<tblMarrigeStatu> marrigeTypeList;

        public List<tblMarrigeStatu> MarrigeTypeList
        {
            get { return marrigeTypeList; }
            set
            {
                marrigeTypeList = value;
                OnPropertyChanged("MarrigeTypeList");
            }
        }

        private List<tblAdministratorType> adminTypeList;

        public List<tblAdministratorType> AdminTypeList
        {
            get { return adminTypeList; }
            set
            {
                adminTypeList = value;
                OnPropertyChanged("AdminTypeList");
            }
        }

        private tblMarrigeStatu marrigeType;

        public tblMarrigeStatu MarrigeType
        {
            get { return marrigeType; }
            set
            {
                marrigeType = value;
                OnPropertyChanged("MarrigeType");
            }
        }

        private tblAdministratorType adminType;

        public tblAdministratorType AdminType
        {
            get { return adminType; }
            set
            {
                adminType = value;
                OnPropertyChanged("AdminType");
            }
        }

        #endregion

        #region Commands

        private ICommand save;

        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }

                return save;
            }
        }

        private void SaveExecute()
        {
            try
            {
                service.AddAdministrator(Administrator, Account, MarrigeType, AdminType);
                MessageBox.Show("Administrator saved.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute()
        {
            if (marrigeType != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private ICommand close;

        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }

                return close;
            }
        }

        private void CloseExecute()
        {
            try
            {
                addAdministrator.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanCloseExecute()
        {
            return true;
        }

        #endregion
    }
}
