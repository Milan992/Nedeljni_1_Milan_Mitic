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
                newAccount.Gender = account.Gender;
                newAccount.City = account.FirstName;
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

        internal void AddEmployee(tblAccount account, tblSector sector, tblPosition position, int experience, string qualification)
        {
            throw new NotImplementedException();
        }
    }
}
