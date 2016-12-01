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
    public partial class New_User : Form
    {        
        public User user; 
        public New_User()
        {
            InitializeComponent();
        }

        private void button_Create_Click(object sender, EventArgs e)
        {
            if(this.textBox_Name.Text.Trim() == String.Empty || this.textBox_Password.Text.Trim() == String.Empty || this.textBox_UserName.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            user = new User(Guid.NewGuid().ToString(), this.textBox_Name.Text.Trim(), this.textBox_UserName.Text.Trim(), Password.GetHashText(this.textBox_Password.Text.Trim()).ToString(), this.checkBox1.Checked);
            this.DialogResult = DialogResult.OK;
        }
        
    }
}
