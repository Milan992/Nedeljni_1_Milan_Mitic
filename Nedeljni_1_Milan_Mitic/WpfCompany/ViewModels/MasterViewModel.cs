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
                UpdateManagerResponsibilityLevel updateManagerResponsibilityLevel = new UpdateManagerResponsibilityLevel();
                updateManagerResponsibilityLevel.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanManagerResponsibilityExecute()
        {
            return true;
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
            return true;
        }

        private ICommand createSector;

        public ICommand CreateSector
        {
            get
            {
                if (createSector == null)
                {
                    createSector = new RelayCommand(param => CreateSectorExecute(), param => CanCreateSectorExecute());
                }

                return createSector;
            }
        }

        private void CreateSectorExecute()
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanCreateSectorExecute()
        {
            return true;
        }

        private ICommand deleteSector;

        public ICommand DeleteSector
        {
            get
            {
                if (deleteSector == null)
                {
                    deleteSector = new RelayCommand(param => DeleteSectorExecute(), param => CanDeleteSectorExecute());
                }

                return deleteSector;
            }
        }

        private void DeleteSectorExecute()
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanDeleteSectorExecute()
        {
            return true;
        }

        private ICommand updateReport;

        public ICommand UpdateReport
        {
            get
            {
                if (updateReport == null)
                {
                    updateReport = new RelayCommand(param => UpdateReportExecute(), param => CanUpdateReportExecute());
                }

                return updateReport;
            }
        }

        private void UpdateReportExecute()
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanUpdateReportExecute()
        {
            return true;
        }

        private ICommand updateAccount;

        public ICommand UpdateAccount
        {
            get
            {
                if (updateAccount == null)
                {
                    updateAccount = new RelayCommand(param => UpdateAccountExecute(), param => CanUpdateAccountExecute());
                }

                return updateAccount;
            }
        }

        private void UpdateAccountExecute()
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanUpdateAccountExecute()
        {
            return true;
        }

        private ICommand createPosition;

        public ICommand CreatePosition
        {
            get
            {
                if (createPosition == null)
                {
                    createPosition = new RelayCommand(param => CreatePositionExecute(), param => CanCreatePositionExecute());
                }

                return createPosition;
            }
        }

        private void CreatePositionExecute()
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanCreatePositionExecute()
        {
            return true;
        }

        private ICommand deleteManager;

        public ICommand DeleteManager
        {
            get
            {
                if (deleteManager == null)
                {
                    deleteManager = new RelayCommand(param => DeleteManagerExecute(), param => CanDeleteManagerExecute());
                }

                return deleteManager;
            }
        }

        private void DeleteManagerExecute()
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanDeleteManagerExecute()
        {
            return true;
        }

        private ICommand deleteProject;

        public ICommand DeleteProject
        {
            get
            {
                if (deleteProject == null)
                {
                    deleteProject = new RelayCommand(param => DeleteProjectExecute(), param => CanDeleteProjectExecute());
                }

                return deleteProject;
            }
        }

        private void DeleteProjectExecute()
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanDeleteProjectExecute()
        {
            return true;
        }

        private ICommand viewAllProjects;

        public ICommand ViewAllProjects
        {
            get
            {
                if (viewAllProjects == null)
                {
                    viewAllProjects = new RelayCommand(param => ViewAllProjectsExecute(), param => CanViewAllProjectsExecute());
                }

                return viewAllProjects;
            }
        }

        private void ViewAllProjectsExecute()
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanViewAllProjectsExecute()
        {
            return true;
        }

        private ICommand updateAdmin;

        public ICommand UpdateAdmin
        {
            get
            {
                if (updateAdmin == null)
                {
                    updateAdmin = new RelayCommand(param => UpdateAdminExecute(), param => CanUpdateAdminExecute());
                }

                return updateAdmin;
            }
        }

        private void UpdateAdminExecute()
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanUpdateAdminExecute()
        {
            return true;
        }

        #endregion
    }
}
