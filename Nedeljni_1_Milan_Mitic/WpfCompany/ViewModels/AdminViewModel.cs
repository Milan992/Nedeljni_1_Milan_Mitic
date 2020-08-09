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
            if (Admin.AdministratorTypeID == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            if (Admin.AdministratorTypeID == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            if (Admin.AdministratorTypeID == 2 || Admin.AdministratorTypeID == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            if (Admin.AdministratorTypeID == 1 || Admin.AdministratorTypeID == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            if (Admin.AdministratorTypeID == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            if (Admin.AdministratorTypeID == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            if (Admin.AdministratorTypeID == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
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

        #endregion
    }
}
