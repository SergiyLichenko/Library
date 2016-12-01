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
    public partial class BooksCancelation : Form
    {
        List<User> allUsers;
        List<Borrowing> borrows;        
        List<Source> source;
        Point point = new Point();
        bool CurrentUserIsAdmin;
        public BorrowForSaveAndDelete borrowForSaveAndDelete = new BorrowForSaveAndDelete();
        public BooksCancelation(List<User> allUsers, List<Borrowing> borrows, bool currentUserIsAdmin)
        {
            InitializeComponent();
            this.allUsers = allUsers;
            this.dataGridView_Users.DataSource = this.allUsers;
            this.dataGridView_Users.Columns["Password"].Visible = false;
            source = new List<Source>();
            this.borrows = borrows;
            CurrentUserIsAdmin = currentUserIsAdmin;
            
            dataGridView_Users_CellClick(null, new DataGridViewCellEventArgs(0,0));

        }
        private void dataGridView_Users_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1 || e.RowIndex > allUsers.Count-1)
                return;
            this.point.X = e.ColumnIndex;
            this.point.Y = e.RowIndex;
            
        }
        
        private void dataGridView_Users_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex < 0 || e.RowIndex < 0)
                    return;
                source.Clear();

                string userID = this.dataGridView_Users.Rows[point.Y].Cells["ID"].Value.ToString();
                foreach (Borrowing bor in borrows)
                {
                    if (bor.UserID == userID)
                    {
                        Source s = new Source();
                        s.BorrowedDate = bor.BorrowedDate;
                        s.CopyID = bor.copy.ID;
                        s.ItemID = bor.copy.ItemID;
                        s.IsBorrowed = bor.copy.isBorrowed;
                        source.Add(s);

                    }
                }
                dataGridView_Copies.DataSource = null;
                if(source.Count != 0)
                    dataGridView_Copies.DataSource = source;
                dataGridView_Copies_CellClick(sender, new DataGridViewCellEventArgs(0, 0));
            }
            catch
            { }
        }
        
        private void dataGridView_Copies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex ==-1)
                return;
            try
            {
                string itemID = dataGridView_Copies.Rows[e.RowIndex].Cells["ItemID"].Value.ToString();
                foreach (Borrowing bor in borrows)
                {
                    if (bor.copy.ItemID == itemID)
                    {
                        this.textBox_AuthorOrigin.Text = bor.book.AuthorName;
                        this.textBox_NameOrigin.Text = bor.book.Name;
                        this.textBox_PublishedDateOrigin.Text = bor.book.PublishedDate;
                        this.textBox_PublisherOrigin.Text = bor.book.Publisher;

                        if (Boolean.Parse(dataGridView_Copies.Rows[e.RowIndex].Cells["IsBorrowed"].Value.ToString()))
                            this.button_CancelBook.Enabled = true;
                        else
                            this.button_CancelBook.Enabled = false;
                    }
                }
            }
            catch
            {
                this.textBox_AuthorOrigin.Text = this.textBox_NameOrigin.Text = this.textBox_PublishedDateOrigin.Text = this.textBox_PublisherOrigin.Text = String.Empty;
            }
            if (CurrentUserIsAdmin == false)
                this.button_CancelBook.Enabled = false;

        }

        private void button_CancelBook_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView_Users.CurrentRow == null || dataGridView_Copies.CurrentRow == null)
                    return;
                this.borrowForSaveAndDelete.CopyID = dataGridView_Copies.CurrentRow.Cells["CopyID"].Value.ToString();
                this.borrowForSaveAndDelete.UserID = dataGridView_Users.CurrentRow.Cells["ID"].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            catch
            {
                this.DialogResult = DialogResult.No;
            }
        }
    }
}
struct Source
{
    public string BorrowedDate { get; set; }
    public string CopyID { get; set; }
    public string ItemID { get; set; }
    public bool IsBorrowed { get; set; }
}
