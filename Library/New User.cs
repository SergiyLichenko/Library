using System;
using System.Windows.Forms;
using Common;

namespace Library
{
    public partial class NewUser : Form
    {        
        public User User; 
        public NewUser()
        {
            InitializeComponent();
        }

        private void Button_Create_Click(object sender, EventArgs e)
        {
            if(textBox_Name.Text.Trim() == String.Empty || 
                textBox_Password.Text.Trim() == String.Empty || 
                textBox_UserName.Text.Trim() == String.Empty)
            {
                MessageBox.Show(@"Заполните все поля");
                return;
            }
            User = new User(Guid.NewGuid().ToString(),
                textBox_Name.Text.Trim(), 
                textBox_UserName.Text.Trim(),
                Password.GetHashText(textBox_Password.Text.Trim()).ToString(), 
                checkBox1.Checked);
            DialogResult = DialogResult.OK;
        }
    }
}
