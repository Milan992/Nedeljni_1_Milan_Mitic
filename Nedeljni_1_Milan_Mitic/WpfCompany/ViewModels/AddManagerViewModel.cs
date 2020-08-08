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
    class AddManagerViewModel : ViewModelBase
    {
        AddManager addManager;
        Service service = new Service();

        #region Constructors

        public AddManagerViewModel(AddManager addManagerOpen)
        {
            manager = new tblManager();
            addManager = addManagerOpen;
        }

        public AddManagerViewModel(AddManager addManagerOpen, tblAccount acountAdd)
        {
            account = acountAdd;
            manager = new tblManager();
            responsibilityLevelList = new List<int> { 1, 2, 3 };
            addManager = addManagerOpen;
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

        private tblManager manager;

        public tblManager Manager
        {
            get
            {
                return manager;
            }
            set
            {
                manager = value;
                OnPropertyChanged("Manager");
            }
        }

        private List<int> responsibilityLevelList;

        public List<int> ResponsibilityLevelList
        {
            get { return responsibilityLevelList; }
            set
            {
                responsibilityLevelList = value;
                OnPropertyChanged("ResponsibilityLevelList");
            }
        }


        private int responsibilityLevel;

        public int ResponsibilityLevel
        {
            get { return responsibilityLevel; }
            set
            {
                responsibilityLevel = value;
                OnPropertyChanged("ResponsibilityLevel");
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
                service.AddManager(Manager, Account);
                MessageBox.Show("Manager saved.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute()
        {
            if (Manager.SparePass != null)
            {
                if (Manager.SparePass.Length > 5)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
                addManager.Close();
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
