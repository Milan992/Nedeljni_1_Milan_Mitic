﻿using System;
using System.Windows;
using System.Windows.Input;
using WpfCompany.Model;
using WpfCompany.Views;

namespace WpfCompany.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        Service service = new Service();
        MainWindow main;

        #region Constructors

        public MainWindowViewModel(MainWindow mainOpen)
        {
            main = mainOpen;
            service.GetManagerCode();
        }

        #endregion

        #region Properties

        private string userName;

        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        private string password;

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        #endregion

        #region Commands

        private ICommand logIn;

        public ICommand LogIn
        {
            get
            {
                if (logIn == null)
                {
                    logIn = new RelayCommand(param => LogInExecute(), param => CanLogInExecute());
                }

                return logIn;
            }
        }

        private void LogInExecute()
        {
            try
            {
                if (UserName == "WPFMaster" && Password == "WPFAccess")
                {
                    Master master = new Master();
                    master.ShowDialog();
                }
                else if(service.IsEmployee(UserName, Password)) 
                {
                    tblAccount a = service.GetAccount(UserName);
                    tblEmployee e = service.GetEmployee(UserName, Password);
                    Employee employee = new Employee(a, e);
                    employee.ShowDialog();
                }
                else if (service.IsManager(UserName, Password))
                {
                    tblAccount a = service.GetAccount(UserName);
                    tblManager m = service.GetManager(userName);
                    Manager manager = new Manager(a, m);
                    manager.ShowDialog();
                }
                else if (service.IsAdmin(UserName, Password))
                {
                    tblAccount a = service.GetAccount(UserName);
                    tblAdministrator ad = service.GetAdmin(UserName, Password);
                    Admin admin = new Admin(a, ad);
                    admin.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Username or password incorrect");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanLogInExecute()
        {
            return true;
        }

        private ICommand newAccount;

        public ICommand NewAccount
        {
            get
            {
                if (newAccount == null)
                {
                    newAccount = new RelayCommand(param => NewAccountExecute(), param => CanNewAccountExecute());
                }

                return newAccount;
            }
        }

        private void NewAccountExecute()
        {
            try
            {
                Register register = new Register();
                register.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanNewAccountExecute()
        {
            return true;
        }

        #endregion
    }
}
