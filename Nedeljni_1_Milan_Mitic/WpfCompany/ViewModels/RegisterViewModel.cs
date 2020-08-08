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
    class RegisterViewModel : ViewModelBase
    {
        Register register;
        Service service = new Service();

        #region Constructors

        public RegisterViewModel(Register registerOpen)
        {
            account = new tblAccount();
            register = registerOpen;
            marrigeTypeList = service.GetAllMarrigeTypes();
            genderList = new List<string> { "M", "Z", "N", "X" };
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


        private bool isManager;

        public bool IsManager
        {
            get { return isManager; }
            set
            {
                isManager = value;
                OnPropertyChanged("IsManager");
            }
        }

        private List<string> genderList;

        public List<string> GenderList
        {
            get { return genderList; }
            set
            {
                genderList = value; OnPropertyChanged("GenderList");
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
                Account.MarrigeStatusID = MarrigeType.MarrigeStatusID;
                if (IsManager)
                {
                    string sMessageBoxText = "Are you sure you want to register as a manager?";
                    string sCaption = "";

                    MessageBoxButton btnMessageBox = MessageBoxButton.YesNoCancel;
                    MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

                    MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

                    switch (rsltMessageBox)
                    {
                        case MessageBoxResult.Yes:
                            ManagerCode managerCode = new ManagerCode(Account);
                            managerCode.ShowDialog();
                            register.Close();
                            break;

                        case MessageBoxResult.No:
                            /* ... */
                            break;

                        case MessageBoxResult.Cancel:
                            /* ... */
                            break;
                    }
                }
                else
                {
                    AddEmployee addEmployee = new AddEmployee(Account);
                    addEmployee.ShowDialog();
                    register.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute()
        {
            if (MarrigeType != null && Account.FirstName != null && Account.LastName != null
                && Account.JMBG != null && Account.Gender != null && Account.FirstName != null
                && Account.UserName != null && Account.Pass != null)
            {
                if (service.IsJmbg(Account.JMBG) && Account.FirstName != "" && Account.LastName != "" && Account.UserName.Length > 4
                    && Account.UserName.Length > 5)
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
                register.Close();
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
