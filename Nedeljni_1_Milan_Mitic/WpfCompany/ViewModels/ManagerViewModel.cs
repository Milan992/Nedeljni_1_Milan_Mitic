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

        #region Commands

        private ICommand addPosition;

        public ICommand AddPosition
        {
            get
            {
                if (addPosition == null)
                {
                    addPosition = new RelayCommand(param => AddPositionExecute(), param => CanAddPositionExecute());
                }

                return addPosition;
            }
        }

        private void AddPositionExecute()
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanAddPositionExecute()
        {
            if (Manager.ResponsibilityLevel == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private ICommand showYourProjects;

        public ICommand ShowYourProjects
        {
            get
            {
                if (showYourProjects == null)
                {
                    showYourProjects = new RelayCommand(param => ShowYourProjectsExecute(), param => CanShowYourProjectsExecute());
                }

                return showYourProjects;
            }
        }

        private void ShowYourProjectsExecute()
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanShowYourProjectsExecute()
        {
            return true;
        }

        private ICommand updateManager;

        public ICommand UpdateManager
        {
            get
            {
                if (updateManager == null)
                {
                    updateManager = new RelayCommand(param => UpdateManagerExecute(), param => CanUpdateManagerExecute());
                }

                return updateManager;
            }
        }

        private void UpdateManagerExecute()
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanUpdateManagerExecute()
        {
            return true;
        }

        private ICommand createProject;

        public ICommand CreateProject
        {
            get
            {
                if (createProject == null)
                {
                    createProject = new RelayCommand(param => CreateProjectExecute(), param => CanCreateProjectExecute());
                }

                return createProject;
            }
        }

        private void CreateProjectExecute()
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanCreateProjectExecute()
        {
            if (Manager.ResponsibilityLevel == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private ICommand viewMonthReports;

        public ICommand ViewMonthReports
        {
            get
            {
                if (viewMonthReports == null)
                {
                    viewMonthReports = new RelayCommand(param => ViewMonthReportsExecute(), param => CanViewMonthReportsExecute());
                }

                return viewMonthReports;
            }
        }

        private void ViewMonthReportsExecute()
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanViewMonthReportsExecute()
        {
            return true;
        }

        private ICommand viewAllReports;

        public ICommand ViewAllReports
        {
            get
            {
                if (viewAllReports == null)
                {
                    viewAllReports = new RelayCommand(param => ViewAllReportsExecute(), param => CanViewAllReportsExecute());
                }

                return viewAllReports;
            }
        }

        private void ViewAllReportsExecute()
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanViewAllReportsExecute()
        {
            if (Manager.ResponsibilityLevel == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private ICommand deleteEmployee;

        public ICommand DeleteEmployee
        {
            get
            {
                if (deleteEmployee == null)
                {
                    deleteEmployee = new RelayCommand(param => DeleteEmployeeExecute(), param => CanDeleteEmployeeExecute());
                }

                return deleteEmployee;
            }
        }

        private void DeleteEmployeeExecute()
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanDeleteEmployeeExecute()
        {
            return true;
        }

        private ICommand viewRequests;

        public ICommand ViewRequests
        {
            get
            {
                if (viewRequests == null)
                {
                    viewRequests = new RelayCommand(param => ViewRequestsExecute(), param => CanViewRequestsExecute());
                }

                return viewRequests;
            }
        }

        private void ViewRequestsExecute()
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanViewRequestsExecute()
        {
            return true;
        }

        #endregion
    }
}
