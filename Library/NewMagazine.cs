using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using Common;

namespace Library
{
    public partial class NewMagazine : Form
    {
        public readonly List<Magazine> Magazines;

        public NewMagazine()
        {
            InitializeComponent();
            button_SaveBook.Enabled = false;
            Magazines = new List<Magazine>();           
            
            Button_AddBook_Click(null, null);
        }

        private void Button_AddBook_Click(object sender, EventArgs e)
        {
            textBox_ID.Text = Guid.NewGuid().ToString();
            if (sender == null && e == null)
                return;

            if (textBox_IssueNumber.Text.Trim() == string.Empty ||
                textBox_Name.Text.Trim() == string.Empty ||
                textBox_Publisher.Text.Trim() == string.Empty)
            {
                MessageBox.Show(@"Заполните все поля");
                return;
            }

            button_SaveBook.Enabled = true;
            var tempMagazine = new Magazine(textBox_ID.Text.Trim(), 
                textBox_Name.Text.Trim(),
                textBox_Publisher.Text.Trim(), 
                dateTimePicker_PublishedDate.Value.ToString(CultureInfo.InvariantCulture),
                textBox_IssueNumber.Text.Trim());

            Magazines.Add(tempMagazine);
            label_MagazineCount.Text = $@"Новых журналов: {Magazines.Count}";
        }

        private void Button_SaveBook_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
    }
}