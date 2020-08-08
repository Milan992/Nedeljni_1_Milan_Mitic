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
    class AddEmployeeViewModel : ViewModelBase
    {
        AddEmployee addEmployee;
        Service service = new Service();

        #region Constructors

        public AddEmployeeViewModel(AddEmployee addEmployeeOpen)
        {
            employee = new tblEmployee();
            addEmployee = addEmployeeOpen;
        }

        public AddEmployeeViewModel(AddEmployee addEmployeeOpen, tblAccount acountAdd)
        {
            account = acountAdd;
            employee = new tblEmployee();
            sectorList = service.GetAllSectors();
            positionList = service.GetAllPositions();
            qualificationsList = new List<string> { "I", "II", "III", "IV", "V", "VI", "VII", };
            addEmployee = addEmployeeOpen;
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

        private tblEmployee employee;

        public tblEmployee Employee
        {
            get
            {
                return employee;
            }
            set
            {
                employee = value;
                OnPropertyChanged("Employee");
            }
        }

        private List<tblSector> sectorList;

        public List<tblSector> SectorList
        {
            get { return sectorList; }
            set
            {
                sectorList = value;
                OnPropertyChanged("SectorList");
            }
        }

        private tblSector sector;

        public tblSector Sector
        {
            get { return sector; }
            set
            {
                sector = value;
                OnPropertyChanged("Sector");
            }
        }

        private tblPosition position;

        public tblPosition Position
        {
            get { return position; }
            set
            {
                position = value;
                OnPropertyChanged("Position");
            }
        }


        private List<tblPosition> positionList;

        public List<tblPosition> PositionList
        {
            get { return positionList; }
            set
            {
                positionList = value;
                OnPropertyChanged("PositionList");
            }
        }

        private List<string> qualificationsList;

        public List<string> QualificationsList
        {
            get { return qualificationsList; }
            set
            {
                qualificationsList = value;
                OnPropertyChanged("QualificationsList");
            }
        }

        private int experience;

        public int Experience
        {
            get { return experience; }
            set
            {
                experience = value;
                OnPropertyChanged("Experience");
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
                service.AddEmployee(Employee, Account, Sector, Position, Experience);
                addEmployee.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute()
        {
            if (Sector != null && Position != null && Experience != null && Employee.QualificationsLevel != null)
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
            addEmployee.Close();
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
