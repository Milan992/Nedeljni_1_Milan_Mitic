using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
                using (StreamWriter sw = new StreamWriter(@"..\..\“ManagerAccess.txt"))
                {
                    sw.Write(r.Next(10000000, 100000000).ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
