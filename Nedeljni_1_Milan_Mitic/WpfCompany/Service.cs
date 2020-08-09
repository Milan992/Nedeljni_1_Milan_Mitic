using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfCompany.Model;

namespace WpfCompany
{
    class Service
    {
        /// <summary>
        /// Checks if string is in JMBG format.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool IsJmbg(string userName)
        {
            bool jmbg = false;
            if (userName.Length == 13)
            {
                try
                {
                    long i = Convert.ToInt64(userName);
                    string date = "1" + userName.Substring(4, 3) + "-" + userName.Substring(2, 2) + "-" + userName.Substring(0, 2);
                    DateTime dateOfBirth = DateTime.ParseExact(date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    jmbg = true;
                }
                catch
                {
                    jmbg = false;
                }
            }
            else
            {
                jmbg = false;
            }
            return jmbg;
        }

        /// <summary>
        /// Gets all managers from database and adds them to a list.
        /// </summary>
        /// <returns></returns>
        internal List<vwManager> GetAllManagers()
        {
            try
            {
                using (CompanyEntities context = new CompanyEntities())
                {
                    List<vwManager> list = (from m in context.vwManagers select m).ToList();
                    return list;
                }
            }
            catch
            {
                MessageBox.Show("There are no registered managers yet");
                return null;
            }
        }

        /// <summary>
        /// Changes manager's responsibility level
        /// </summary>
        /// <param name="manager"></param>
        internal void UpdateResponsibility(vwManager manager)
        {
            using (CompanyEntities context = new CompanyEntities())
            {
                tblManager managerToEdit = (from m in context.tblManagers where m.ManagerID == manager.ManagerID select m).First();
                if (managerToEdit.ResponsibilityLevel == null)
                {
                    managerToEdit.ResponsibilityLevel = 1;
                }
                else if (managerToEdit.ResponsibilityLevel == 1)
                {
                    managerToEdit.ResponsibilityLevel = 2;
                }
                else if (managerToEdit.ResponsibilityLevel == 2)
                {
                    managerToEdit.ResponsibilityLevel = 3;
                }
                else if (managerToEdit.ResponsibilityLevel == 3)
                {
                    managerToEdit.ResponsibilityLevel = null;
                }
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Generates a random number and writes it to a txt file.
        /// </summary>
        internal void GetManagerCode()
        {
            try
            {
                Random r = new Random();
                using (StreamWriter sw = new StreamWriter(@"..\..\ManagerAccess.txt"))
                {
                    sw.Write(r.Next(10000000, 100000000).ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Checks if employee with the username and pass exists in tblEmployee in the database.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        internal bool IsEmployee(string userName, string password)
        {
            try
            {
                using (CompanyEntities context = new CompanyEntities())
                {
                    tblAccount account = GetAccount(userName, password);
                    tblEmployee employee = (from e in context.tblEmployees where e.AccountID == account.AccountID select e).First();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        internal tblEmployee GetEmployee(string userName, string password)
        {
            using (CompanyEntities context = new CompanyEntities())
            {
                tblAccount account = GetAccount(userName, password);
                tblEmployee employee = (from e in context.tblEmployees where e.AccountID == account.AccountID select e).First();
                return employee;
            }
        }

        /// <summary>
        /// Returns an account with the userName and Pass from tblAccount in the database.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public tblAccount GetAccount(string userName, string password)
        {
            using (CompanyEntities context = new CompanyEntities())
            {
                tblAccount account = (from a in context.tblAccounts where a.UserName == userName && a.Pass == password select a).First();
                return account;
            }
        }

        /// <summary>
        /// Returns an account with the userName and Pass from tblAccount in the database.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public tblAccount GetAccount(string userName)
        {
            using (CompanyEntities context = new CompanyEntities())
            {
                tblAccount account = (from a in context.tblAccounts where a.UserName == userName select a).First();
                return account;
            }
        }

        /// <summary>
        /// Checks if manager with the username and pass exists in tblManager in the database.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        internal bool IsManager(string userName, string password)
        {
            try
            {
                tblAccount account = new tblAccount();
                tblManager manager = new tblManager();
                using (CompanyEntities context = new CompanyEntities())
                {
                    try
                    {
                        account = GetAccount(userName, password);
                    }
                    catch
                    {
                        account = (from a in context.tblAccounts where a.UserName == userName select a).First();
                        manager = (from e in context.tblManagers where e.SparePass == password select e).First();
                    }
                    manager = (from e in context.tblManagers where e.AccountID == account.AccountID select e).First();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        internal tblManager GetManager(string userName)
        {
            using (CompanyEntities context = new CompanyEntities())
            {
                tblAccount account = (from a in context.tblAccounts where a.UserName == userName select a).First();
                tblManager manager = (from e in context.tblManagers where e.AccountID == account.AccountID select e).First();
                return manager;
            }
        }

        /// <summary>
        /// Checks if admin with the username and pass exists in tblAdministrator in the database.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        internal bool IsAdmin(string userName, string password)
        {
            try
            {
                using (CompanyEntities context = new CompanyEntities())
                {
                    tblAccount account = GetAccount(userName, password);
                    tblAdministrator admin = (from e in context.tblAdministrators where e.AccountID == account.AccountID select e).First();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        internal tblAdministrator GetAdmin(string userName, string password)
        {
            using (CompanyEntities context = new CompanyEntities())
            {
                tblAccount account = GetAccount(userName, password);
                tblAdministrator admin = (from e in context.tblAdministrators where e.AccountID == account.AccountID select e).First();
                return admin;
            }
        }

        /// <summary>
        /// Gets all sectors from the database and adds them to the list.
        /// </summary>
        /// <returns></returns>
        internal List<tblSector> GetAllSectors()
        {
            try
            {
                using (CompanyEntities context = new CompanyEntities())
                {
                    List<tblSector> list = (from a in context.tblSectors select a).ToList();
                    return list;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets all positions from the database and adds them to the list.
        /// </summary>
        /// <returns></returns>
        internal List<tblPosition> GetAllPositions()
        {
            try
            {
                using (CompanyEntities context = new CompanyEntities())
                {
                    List<tblPosition> list = (from a in context.tblPositions select a).ToList();
                    return list;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Adds new account to tblAccount and adds an employee with the acount AccountID to database.
        /// </summary>
        /// <param name="account"></param>
        /// <param name="sector"></param>
        /// <param name="position"></param>
        /// <param name="experience"></param>
        /// <param name="qualification"></param>
        internal void AddManager(tblManager manager, tblAccount account)
        {
            using (CompanyEntities context = new CompanyEntities())
            {
                tblAccount newAccount = new tblAccount();
                newAccount.FirstName = account.FirstName;
                newAccount.LastName = account.LastName;
                newAccount.JMBG = account.JMBG;
                newAccount.Gender = account.Gender.ToUpper();
                newAccount.City = account.City;
                newAccount.MarrigeStatusID = account.MarrigeStatusID;
                newAccount.UserName = account.UserName;
                newAccount.Pass = account.Pass;
                context.tblAccounts.Add(newAccount);
                context.SaveChanges();

                tblManager newManager = new tblManager();
                newManager.AccountID = newAccount.AccountID;
                newManager.Email = manager.Email;
                newManager.SparePass = manager.SparePass + "WPF";
                newManager.OfficeNumber = manager.OfficeNumber;
                context.tblManagers.Add(newManager);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Checks if parameter code is equals to a code in a txt file.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool CheckCode(string code)
        {
            string codeFromFile = "";
            try
            {
                using (StreamReader sr = new StreamReader("../../ManagerAccess.txt"))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        codeFromFile = line;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            if (codeFromFile == code)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets all administrator types from the database and adds them to the list.
        /// </summary>
        /// <returns></returns>
        internal List<tblAdministratorType> GetAllAdminTypes()
        {
            using (CompanyEntities context = new CompanyEntities())
            {
                List<tblAdministratorType> list = (from a in context.tblAdministratorTypes select a).ToList();
                return list;
            }
        }

        /// <summary>
        /// Gets all marrige types from the database and adds them to the list.
        /// </summary>
        /// <returns></returns>
        internal List<tblMarrigeStatu> GetAllMarrigeTypes()
        {
            using (CompanyEntities context = new CompanyEntities())
            {
                List<tblMarrigeStatu> list = (from a in context.tblMarrigeStatus select a).ToList();
                return list;
            }
        }

        /// <summary>
        /// Adds new account to tblAccount and adds an admin with the acount AccountID to database.
        /// </summary>
        /// <param name="administrator"></param>
        /// <param name="marrigeType"></param>
        /// <param name="adminType"></param>
        internal void AddAdministrator(tblAdministrator administrator, tblAccount account, tblMarrigeStatu marrigeType, tblAdministratorType adminType)
        {
            using (CompanyEntities context = new CompanyEntities())
            {
                tblAccount newAccount = new tblAccount();
                newAccount.FirstName = account.FirstName;
                newAccount.LastName = account.LastName;
                newAccount.JMBG = account.JMBG;
                newAccount.Gender = account.Gender.ToUpper();
                newAccount.City = account.City;
                newAccount.MarrigeStatusID = marrigeType.MarrigeStatusID;
                newAccount.UserName = account.UserName;
                newAccount.Pass = account.Pass;
                context.tblAccounts.Add(newAccount);
                context.SaveChanges();

                tblAdministrator newAdmin = new tblAdministrator();
                newAdmin.AccountID = newAccount.AccountID;
                newAdmin.AdministratorTypeID = adminType.AdministratorTypeID;
                newAdmin.DateOfExpiry = DateTime.Today.AddDays(7);
                context.tblAdministrators.Add(newAdmin);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Adds new account to tblAccount and adds an employee with the acount AccountID to database.
        /// </summary>
        /// <param name="account"></param>
        /// <param name="sector"></param>
        /// <param name="position"></param>
        /// <param name="experience"></param>
        /// <param name="qualification"></param>
        internal void AddEmployee(tblEmployee employee, tblAccount account, tblSector sector, tblPosition position, int experience)
        {
            int id = RandomManager();
            if (id != 0)
            {
                using (CompanyEntities context = new CompanyEntities())
                {
                    tblAccount newAccount = new tblAccount();
                    newAccount.FirstName = account.FirstName;
                    newAccount.LastName = account.LastName;
                    newAccount.JMBG = account.JMBG;
                    newAccount.Gender = account.Gender.ToUpper();
                    newAccount.City = account.City;
                    newAccount.MarrigeStatusID = account.MarrigeStatusID;
                    newAccount.UserName = account.UserName;
                    newAccount.Pass = account.Pass;
                    context.tblAccounts.Add(newAccount);
                    context.SaveChanges();

                    tblEmployee newEmployee = new tblEmployee();
                    newEmployee.AccountID = newAccount.AccountID;
                    newEmployee.ManagerID = id;
                    newEmployee.SectorID = sector.SectorID;
                    newEmployee.PositionID = position.PositionID;
                    newEmployee.EmploymentDate = DateTime.Now.AddYears(-experience);
                    newEmployee.QualificationsLevel = employee.QualificationsLevel;
                    context.tblEmployees.Add(newEmployee);
                    context.SaveChanges();
                    MessageBox.Show("Employee saved.");
                }
            }
            else
            {
                MessageBox.Show("You can not register any employees until there is no registered managers first.");
            }
        }

        private int RandomManager()
        {
            try
            {
                using (CompanyEntities context = new CompanyEntities())
                {
                    List<tblManager> list = (from m in context.tblManagers select m).ToList();
                    Random random = new Random();
                    int r = random.Next(0, list.Count);
                    tblManager manager = (from i in list where i.ManagerID == list[r].ManagerID select i).First();
                    int id = manager.ManagerID;
                    return id;
                }
            }
            catch
            {
                return 0;
            }
        }
    }
}

