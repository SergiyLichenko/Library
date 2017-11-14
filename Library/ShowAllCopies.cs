using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Common;

namespace Library
{
    public partial class ShowAllCopies : Form
    {
        public readonly BorrowForSaveAndDelete BorrowForSave = new BorrowForSaveAndDelete();

        public ShowAllCopies(List<Copy> booksCopies, Book book, List<User> allUsers)
        {
            InitializeComponent();
            textBox_AuthorOrigin.Text = book.AuthorName;
            textBox_NameOrigin.Text = book.Name;
            textBox_PublishedDateOrigin.Text = book.PublishedDate;
            textBox_PublisherOrigin.Text = book.Publisher;

            dataGridView_Copies.DataSource =booksCopies;
            dataGridView_Users.DataSource = allUsers;

            var dataGridViewColumn = dataGridView_Users.Columns["Password"];
            if (dataGridViewColumn != null) dataGridViewColumn.Visible = false;
            label_CopiesCount.Text = $@"Количество копий: {booksCopies.Count}";

            DataGridView1_CellEnter(null, new DataGridViewCellEventArgs(0, 0));
        }

        private void DataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            var formattedValue = dataGridView_Copies.Rows[e.RowIndex].Cells["IsBorrowed"].FormattedValue;
            if (formattedValue != null && Boolean.Parse(formattedValue.ToString()))
                dataGridView_Copies.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
        }

        private void DataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_Copies.Rows.Count == 0)
            {
                button_GiveBook.Enabled = false;
                return;
            }
            button_GiveBook.Enabled = !Boolean.Parse(dataGridView_Copies["IsBorrowed", e.RowIndex].Value.ToString());
        }

        private void Button_GiveBook_Click(object sender, EventArgs e)
        {
            if (dataGridView_Copies.CurrentRow == null || dataGridView_Users.CurrentRow == null)
                return;
            BorrowForSave.CopyId = dataGridView_Copies.CurrentRow.Cells["ID"].Value.ToString();
            BorrowForSave.UserId = dataGridView_Users.CurrentRow.Cells["ID"].Value.ToString();
            DialogResult = DialogResult.OK;
        }
    }
}
