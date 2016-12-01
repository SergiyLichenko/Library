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
    public partial class ShowAllCopies : Form
    {
        List<Copy> booksCopies;
        public BorrowForSaveAndDelete borrowForSave = new BorrowForSaveAndDelete();
        public ShowAllCopies(List<Copy> booksCopies, Book book, List<User> allUsers)
        {
            InitializeComponent();
            this.textBox_AuthorOrigin.Text = book.AuthorName;
            this.textBox_NameOrigin.Text = book.Name;
            this.textBox_PublishedDateOrigin.Text = book.PublishedDate.ToString();
            this.textBox_PublisherOrigin.Text = book.Publisher;

            this.booksCopies = booksCopies;
            this.dataGridView_Copies.DataSource = this.booksCopies;
            this.dataGridView_Users.DataSource = allUsers;
            this.dataGridView_Users.Columns["Password"].Visible = false;
            this.label_CopiesCount.Text = String.Format("Количество копий: {0}",this.booksCopies.Count);
            dataGridView1_CellEnter(null, new DataGridViewCellEventArgs(0, 0));
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if (Boolean.Parse(dataGridView_Copies.Rows[e.RowIndex].Cells["IsBorrowed"].FormattedValue.ToString()))
                dataGridView_Copies.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
        }



        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView_Copies.Rows == null || this.dataGridView_Copies.Rows.Count == 0)
            {
                this.button_GiveBook.Enabled = false;
                return;
            }                
            if (Boolean.Parse(dataGridView_Copies["IsBorrowed", e.RowIndex].Value.ToString()))
                this.button_GiveBook.Enabled = false;
            else
                this.button_GiveBook.Enabled = true;
        }

        private void button_GiveBook_Click(object sender, EventArgs e)
        {
            if (dataGridView_Copies.CurrentRow == null || dataGridView_Users.CurrentRow == null)
                return;
            this.borrowForSave.CopyID = dataGridView_Copies.CurrentRow.Cells["ID"].Value.ToString();
            this.borrowForSave.UserID = dataGridView_Users.CurrentRow.Cells["ID"].Value.ToString();
            this.DialogResult = DialogResult.OK;
        }
    }
}
