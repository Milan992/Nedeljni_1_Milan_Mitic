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
    class MasterViewModel : ViewModelBase
    {
        Master master;
        Service service = new Service();

        #region Constructors

        public MasterViewModel(Master masterOpen)
        {
            account = new tblAccount();
            master = masterOpen;
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

        #endregion

        #region Commands

        private ICommand addAdmin;

        public ICommand AddAdmin
        {
            get
            {
                if (addAdmin == null)
                {
                    addAdmin = new RelayCommand(param => AddAdminExecute(), param => CanAddAdminExecute());
                }

                return addAdmin;
            }
        }

        private void AddAdminExecute()
        {
            try
            {
                AddAdministrator addAdministrator = new AddAdministrator();
                addAdministrator.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanAddAdminExecute()
        {
            return true;
        }

        #endregion
    }
}
