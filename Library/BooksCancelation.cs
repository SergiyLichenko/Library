using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Common;

namespace Library
{
    public partial class BooksCancelation : Form
    {
        readonly List<User> _allUsers;
        readonly List<Borrowing> _borrows;
        readonly List<Source> _source;
        private Point _point;
        readonly bool _currentUserIsAdmin;
        public readonly BorrowForSaveAndDelete BorrowForSaveAndDelete = new BorrowForSaveAndDelete();

        public BooksCancelation(List<User> allUsers, List<Borrowing> borrows, bool currentUserIsAdmin)
        {
            InitializeComponent();
            _allUsers = allUsers;
            dataGridView_Users.DataSource = _allUsers;

            var dataGridViewColumn = dataGridView_Users.Columns["Password"];
            if (dataGridViewColumn != null) dataGridViewColumn.Visible = false;

            _source = new List<Source>();
            _borrows = borrows;
            _currentUserIsAdmin = currentUserIsAdmin;

            DataGridView_Users_CellClick(null, new DataGridViewCellEventArgs(0, 0));
        }

        private void DataGridView_Users_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1 || e.RowIndex > _allUsers.Count - 1)
                return;
            _point.X = e.ColumnIndex;
            _point.Y = e.RowIndex;
        }

        private void DataGridView_Users_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex < 0 || e.RowIndex < 0)
                    return;
                _source.Clear();

                string userId = this.dataGridView_Users.Rows[_point.Y].Cells["ID"].Value.ToString();
                foreach (var bor in _borrows)
                {
                    if (bor.UserId != userId) continue;

                    var s = new Source
                    {
                        BorrowedDate = bor.BorrowedDate,
                        CopyId = bor.Copy.Id,
                        ItemId = bor.Copy.ItemId,
                        IsBorrowed = bor.Copy.IsBorrowed
                    };
                    _source.Add(s);
                }
                dataGridView_Copies.DataSource = null;
                if (_source.Count != 0)
                    dataGridView_Copies.DataSource = _source;
                dataGridView_Copies_CellClick(sender, new DataGridViewCellEventArgs(0, 0));
            }
            catch
            {
                // ignored
            }
        }

        private void dataGridView_Copies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1)
                return;
            try
            {
                string itemId = dataGridView_Copies.Rows[e.RowIndex].Cells["ItemID"].Value.ToString();
                foreach (var bor in _borrows)
                {
                    if (bor.Copy.ItemId != itemId) continue;

                    textBox_AuthorOrigin.Text = bor.Book.AuthorName;
                    textBox_NameOrigin.Text = bor.Book.Name;
                    textBox_PublishedDateOrigin.Text = bor.Book.PublishedDate;
                    textBox_PublisherOrigin.Text = bor.Book.Publisher;

                    button_CancelBook.Enabled = Boolean.Parse(dataGridView_Copies.Rows[e.RowIndex].Cells["IsBorrowed"].Value.ToString());
                }
            }
            catch
            {
                textBox_AuthorOrigin.Text = textBox_NameOrigin.Text =
                    textBox_PublishedDateOrigin.Text = textBox_PublisherOrigin.Text = String.Empty;
            }
            if (_currentUserIsAdmin == false)
                button_CancelBook.Enabled = false;
        }

        private void Button_CancelBook_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView_Users.CurrentRow == null || dataGridView_Copies.CurrentRow == null)
                    return;
                BorrowForSaveAndDelete.CopyId = dataGridView_Copies.CurrentRow.Cells["CopyID"].Value.ToString();
                BorrowForSaveAndDelete.UserId = dataGridView_Users.CurrentRow.Cells["ID"].Value.ToString();
                DialogResult = DialogResult.OK;
            }
            catch
            {
                DialogResult = DialogResult.No;
            }
        }
    }
}