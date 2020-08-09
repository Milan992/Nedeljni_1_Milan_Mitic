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
    class UpdateManagerResponsibilityLevelViewModel : ViewModelBase
    {
        UpdateManagerResponsibilityLevel updateManagerResponsibilityLevel;
        Service service = new Service();

        #region Constructors

        public UpdateManagerResponsibilityLevelViewModel(UpdateManagerResponsibilityLevel updateManagerResponsibilityLevelOpen)
        {
            updateManagerResponsibilityLevel = updateManagerResponsibilityLevelOpen;
            managerList = service.GetAllManagers();
        }

        #endregion

        #region Properties 

        private vwManager manager;

        public vwManager Manager
        {
            get { return manager; }
            set
            {
                manager = value;
                OnPropertyChanged("Manager");
            }
        }

        private List<vwManager> managerList;

        public List<vwManager> ManagerList
        {
            get { return managerList; }
            set
            {
                managerList = value;
                OnPropertyChanged("ManagerList");
            }
        }

        #endregion

        #region Commands 

        private ICommand updateResponsibility;

        public ICommand UpdateResponsibility
        {
            get
            {
                if (updateResponsibility == null)
                {
                    updateResponsibility = new RelayCommand(param => UpdateResponsibilityExecute(), param => CanUpdateResponsibilityExecute());
                }

                return updateResponsibility;
            }
        }

        private void UpdateResponsibilityExecute()
        {
            try
            {
                service.UpdateResponsibility(Manager);
                ManagerList = service.GetAllManagers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanUpdateResponsibilityExecute()
        {
            if (Manager != null)
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
