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
namespace Library
{
    public partial class NewMagazine : Form
    {
        public List<Magazine> magazines;
        public NewMagazine()
        {
            InitializeComponent();
            button_SaveBook.Enabled = false;
            magazines = new List<Magazine>();           
            
            button_AddBook_Click(null, null);
        }

        private void button_AddBook_Click(object sender, EventArgs e)
        {
            textBox_ID.Text = Guid.NewGuid().ToString();
            if (sender == null && e == null)
                return;
            if (textBox_IssueNumber.Text.Trim() == String.Empty || textBox_Name.Text.Trim() == String.Empty || textBox_Publisher.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            button_SaveBook.Enabled = true;
            Magazine tempMagazine = new Magazine(textBox_ID.Text.Trim(), textBox_Name.Text.Trim(),
                textBox_Publisher.Text.Trim(), dateTimePicker_PublishedDate.Value.ToString(), textBox_IssueNumber.Text.Trim());
            magazines.Add(tempMagazine);
            label_MagazineCount.Text = String.Format("Новых журналов: {0}",magazines.Count);
        }

        private void button_SaveBook_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}
