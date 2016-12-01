using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Client client = new Client();
            client.changeUser += Client_changeUser;

            while (client.ShowDialog() == DialogResult.OK)
            {
                client = new Client();
                client.changeUser += Client_changeUser;
            }
            

        }

        private static void Client_changeUser(Client client)
        {
            client.DialogResult = DialogResult.OK;
        }
    }
}
