using System;
using System.Windows.Forms;
using Common;

namespace Library
{
    public delegate bool CheckUser(string userName, string password);
    public partial class Authorization : Form
    {
        public event CheckUser LookInDb;
        public Authorization()
        {
            InitializeComponent();
        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            if (textBox_Password.Text.Trim() == String.Empty || this.textBox_UserName.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            if (LookInDb == null) return;

            if (LookInDb(textBox_UserName.Text.Trim(), Password.GetHashText(textBox_Password.Text.Trim()).ToString()))                
                DialogResult = DialogResult.OK;
            else
                MessageBox.Show("Неправильный User Name или Password");
        }
        

        private void Authorization_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK) return;

            DialogResult = DialogResult.No;
            Application.Exit();
        }
    }
}
