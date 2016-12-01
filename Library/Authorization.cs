using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using System.Security.Cryptography;
namespace Library
{
    public delegate bool CheckUser(string userName, string password);
    public partial class Authorization : Form
    {
        public event CheckUser LookInDB;
        public User user { get; private set; }
        public Authorization()
        {
            InitializeComponent();
        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            if (this.textBox_Password.Text.Trim() == String.Empty || this.textBox_UserName.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            
            if (LookInDB != null)
            {
                if (LookInDB(this.textBox_UserName.Text.Trim(), Password.GetHashText(this.textBox_Password.Text.Trim()).ToString()))                
                    this.DialogResult = DialogResult.OK;
                else
                    MessageBox.Show("Неправильный User Name или Password");
            }
        }
        

        private void Authorization_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                this.DialogResult = DialogResult.No;
                Application.Exit();
            }
        }
    }
}
