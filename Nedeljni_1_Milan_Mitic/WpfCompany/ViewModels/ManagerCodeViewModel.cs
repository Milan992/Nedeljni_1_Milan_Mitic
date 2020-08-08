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
    class ManagerCodeViewModel : ViewModelBase
    {
        ManagerCode managerCode;
        Service service = new Service();
        int counter = 3;

        #region Constructors

        public ManagerCodeViewModel(ManagerCode managerCodeOpen)
        {
            managerCode = managerCodeOpen;
        }

        public ManagerCodeViewModel(ManagerCode managerCodeOpen, tblAccount account)
        {
            managerCode = managerCodeOpen;
            accountToView = account;
        }

        #endregion

        #region Properties

        private tblAccount accountToView;

        public tblAccount AccountToView
        {
            get
            {
                return accountToView;
            }
            set
            {
                accountToView = value;
                OnPropertyChanged("AccountToView");
            }
        }

        private string code;

        public string Code
        {
            get { return code; }
            set
            {
                code = value;
                OnPropertyChanged("Code");
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
                if (service.CheckCode(Code))
                {
                    MessageBox.Show("Code correct. Please procced to completing yor manager registration.");
                    AddManager addManager = new AddManager(AccountToView);
                    addManager.ShowDialog();
                    managerCode.Close();
                }
                else
                {
                    counter--;
                    if (counter > 0)
                    {
                        MessageBox.Show("Code incorrect." + " " + counter.ToString() + " " + "attempts left");
                    }
                    else
                    {
                        MessageBox.Show("Out of attempts. Proceed to completing registration as an employee.");
                        AddEmployee addEmployee = new AddEmployee(AccountToView);
                        addEmployee.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute()
        {
            return true;
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
                managerCode.Close();
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
