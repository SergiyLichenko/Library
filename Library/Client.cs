using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Common;

namespace Library
{
    public delegate void ChangeUser(Client client);
    public partial class Client : Form
    {
        private List<Book> _books;
        private List<Magazine> _magazines;
        private List<Article> _articles;
        private User _currentUser;
        private Point _point;
        private readonly DataAccessLayer.DataAccessLayer _dal;
        public event ChangeUser ChangeUser;

        public Client()
        {
            var logIn = new LogIn();
            if (logIn.ShowDialog() == DialogResult.OK)
                _dal = new DataAccessLayer.DataAccessLayer(logIn.DataType, logIn.ConnectionParameters);

            var authorization = new Authorization();
            authorization.LookInDb += Authorization_LookInDB;
            if (authorization.ShowDialog() == DialogResult.OK)
                MessageBox.Show(@"	Авторизация пройдена
Вы вошли под именем " + _currentUser.UserName + @", Admin - " + _currentUser.IsAdmin + @"

Ваше настоящее имя " + _currentUser.Name);
            else
                return;

            authorization.LookInDb -= Authorization_LookInDB;

            InitializeComponent();
          
           

            Button_Refresh_Click(null, null);
            Button_RefreshMagazine_Click(null, null);
            Button_RefreshArticle_Click(null, null);
            if (_currentUser != null)
                label_UserName.Text = $@"Здраствуйте, {_currentUser.Name}";

        }

        private bool Authorization_LookInDB(string userName,string password)
        {
            return _dal.GetCurrentUser(userName,password, out _currentUser);
        }

        private void Button_Refresh_Click(object sender, EventArgs e)
        {
            if (_dal == null)
                return;
            if ((sender == null && e == null) ||
                (textBox_BookName.Text.Trim() == String.Empty && textBox_BookPublisher.Text.Trim() == String.Empty
                && textBox_BookAuthor.Text.Trim() == String.Empty))
            {
                _books = _dal.GetAllBooks();
                dataGridView_Books.DataSource = _books;
            }
           
                Book searchedBook = new Book(textBox_BookName.Text.Trim(), textBox_BookPublisher.Text.Trim(),
                    String.Empty, string.Empty, textBox_BookAuthor.Text.Trim());
                _books = _dal.SearchedBooks(searchedBook);
                dataGridView_Books.DataSource = _books;

            if (dataGridView_Books.Columns.Count == 0 || dataGridView_Books.Rows.Count == 0) return;

            var dataGridViewColumn = dataGridView_Books.Columns["ItemFields"];
            if (dataGridViewColumn != null)
                dataGridViewColumn.Visible = false;
            var gridViewColumn = dataGridView_Books.Columns["AuthorFields"];
            if (gridViewColumn != null)
                gridViewColumn.Visible = false;
            var viewColumn = dataGridView_Books.Columns["BookFields"];
            if (viewColumn != null)
                viewColumn.Visible = false;
        }

        private void добавитьКнигуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newBook = new NewBook();
            if (newBook.ShowDialog() == DialogResult.OK && newBook.Book.Count > 0)
            {
                var notAdded = _dal.AddBook(newBook.Book);
                Button_Refresh_Click(null, null);
                MessageBox.Show(@"Книга была добавлена");
                if (notAdded.Count <= 0) return;

                NotAddedMagazines notAddedForm = new NotAddedMagazines(notAdded);
                notAddedForm.ShowDialog();
            }
            else
                MessageBox.Show(@"Не было добавлено новых книг для сохранения");
        }

   
        private void UpdateSelectedBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView_Books.CurrentCell == null)
                return;
            if (dataGridView_Books.CurrentRow != null)
            {
                var book = _books[dataGridView_Books.CurrentRow.Index];

                var updateBook = new UpdateBook(book);
                if(updateBook.ShowDialog()==DialogResult.OK)
                {
                    MessageBox.Show(_dal.UpdateBook(updateBook.Book)
                        ? @"Книга была успешно изменена"
                        : @"Изменения не были произведены");
                }
            }
            Button_Refresh_Click(null, null);
        }

        private void Button_RefreshMagazine_Click(object sender, EventArgs e)
        {
            if (_dal == null)
                return;
            if ((sender==null && e==null) || (textBox_Name.Text.Trim() == String.Empty && textBox_Publisher.Text.Trim() == String.Empty && 
                textBox_IssueNumber.Text.Trim() == String.Empty))
            {
                _magazines = _dal.GetAllMagazines();
                if (_magazines == null || _magazines.Count == 0 )
                {
                    dataGridView_Magazines.DataSource = null;
                    return;
                }

                dataGridView_Magazines.DataSource = _magazines;
                var dataGridViewColumn = dataGridView_Magazines.Columns["ItemFields"];
                if (dataGridViewColumn != null)
                    dataGridViewColumn.Visible = false;
                var gridViewColumn = dataGridView_Magazines.Columns["MagazineFields"];
                if (gridViewColumn != null)
                    gridViewColumn.Visible = false;
                return;
            }

            var searchedMagazine = new Magazine(textBox_Name.Text.Trim(), textBox_Publisher.Text.Trim(),
                String.Empty, textBox_IssueNumber.Text.Trim());

            _magazines = _dal.SearchedMagazines(searchedMagazine);
            if (_magazines == null)
                dataGridView_Magazines.DataSource = null;
            else
            {
                dataGridView_Magazines.DataSource = _magazines;
                var dataGridViewColumn = dataGridView_Magazines.Columns["ItemFields"];
                if (dataGridViewColumn != null)
                    dataGridViewColumn.Visible = false;
                var gridViewColumn = dataGridView_Magazines.Columns["MagazineFields"];
                if (gridViewColumn != null)
                    gridViewColumn.Visible = false;
            }
        }

        private void Button_RefreshArticle_Click(object sender, EventArgs e)
        {
            if (_dal == null)
                return;
            if (sender == null && e == null)
            {
                _articles = _dal.GetAllArticles();
                if (_articles != null)
                    dataGridView_Articles.DataSource = _articles;
                else
                {
                    dataGridView_Articles.DataSource = null;
                    return;
                }
            }
            else            
            {
                var searchedArticle = new Article(textBox_articleName.Text.Trim(), textBox_articlePublisher.Text.Trim(),
                    String.Empty, String.Empty, String.Empty, textBox_articleAuthor.Text.Trim(), String.Empty);

                _articles = _dal.SearchedArticles(searchedArticle);
                if (_articles != null)
                    dataGridView_Articles.DataSource = _articles;
                else
                {
                    dataGridView_Articles.DataSource = null;
                    return;
                }
            }
            var dataGridViewColumn = dataGridView_Articles.Columns["ItemFields"];
            if (dataGridViewColumn != null)
                dataGridViewColumn.Visible = false;
            var gridViewColumn = dataGridView_Articles.Columns["MagazineFields"];
            if (gridViewColumn != null)
                gridViewColumn.Visible = false;
            var viewColumn = dataGridView_Articles.Columns["AuthorFields"];
            if (viewColumn != null)
                viewColumn.Visible = false;
            var column = dataGridView_Articles.Columns["ArticleFields"];
            if (column != null)
                column.Visible = false;
        }

        private void AddNewMagazineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newMagazine = new NewMagazine();
            if (newMagazine.ShowDialog() != DialogResult.OK) return;

            var notAdded = _dal.AddMagazines(newMagazine.Magazines);
            Button_RefreshMagazine_Click(null, null);
            if (notAdded.Count>0)
            {                   
                MessageBox.Show(@"Некоторые журналы не были сохранены в базе данных");
                NotAddedMagazines notAddedItems = new NotAddedMagazines(notAdded);
                notAddedItems.ShowDialog();
            }
            else MessageBox.Show(@"Новый журнал был успешно добавлен");
        }

        private void AddNewArticleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newArticle = new NewArticle(_dal.GetAllMagazines());

            if (newArticle.ShowDialog() == DialogResult.OK)
            {
                var notAdded = _dal.AddArticles(newArticle.NewArticles);
                Button_RefreshArticle_Click(null, null);
                MessageBox.Show(@"Новая статья была успешно добавлена");
                if (notAdded == null || notAdded.Count <= 0) return; //not added items

                var notAdd = new NotAddedMagazines(notAdded);
                notAdd.ShowDialog();
            }
            else
            {
                MessageBox.Show(@"Новая статья не была добавлена");
            }
        }

        private void ShowAllCopiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView_Books.CurrentRow == null)
                return;

            var searchedId = dataGridView_Books.Rows[_point.Y].Cells["ID"].Value.ToString();
            var booksCopies = _dal.GetAllCopiesBooks(searchedId);
            var book = _books[_point.Y];
            var allUsers = _dal.GetAllUsers();
            var showCopies = new ShowAllCopies(booksCopies, book,allUsers);
            if (showCopies.ShowDialog() != DialogResult.OK) return;

            MessageBox.Show(_dal.SaveNewBorrow(showCopies.BorrowForSave)
                ? "Новая книга успешно выдана"
                : "Новая книга не была выдана");
        }

        private void dataGridView_Books_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            _point.Y = e.RowIndex;
            _point.X = e.ColumnIndex;
        }

        private void ShowAllUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var allUsers = _dal.GetAllUsers();
            var borrows = _dal.GetAllUserBorrowings();
            
            var bookCancel = new BooksCancelation(allUsers, borrows, _currentUser.IsAdmin);
            if (bookCancel.ShowDialog() != DialogResult.OK) return;

            MessageBox.Show(_dal.DeleteUserCopy(bookCancel.BorrowForSaveAndDelete)
                ? "Книга была успешно списана"
                : "Книга не была списана");
        }

        private void createNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newUser = new NewUser();

            if (newUser.ShowDialog() != DialogResult.OK) return;
            MessageBox.Show(_dal.AddNewUser(newUser.User)
                ? "Новый пользователь добавлен"
                : "Новый пользователь не был добавлен");
        }

        private void Client_Load(object sender, EventArgs e)
        {
            if (_currentUser.IsAdmin) return;

            добавитьКнигуToolStripMenuItem.Enabled = false;
            updateSelectedBookToolStripMenuItem.Enabled = false;
            addNewMagazineToolStripMenuItem.Enabled = false;
            addNewArticleToolStripMenuItem.Enabled = false;
            createNewUserToolStripMenuItem.Enabled = false;
            showAllCopiesToolStripMenuItem.Enabled = false;
        }

        private void ChangeUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeUser?.Invoke(this);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void WriteToXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileDialog = new SaveFileDialog();
            if (fileDialog.ShowDialog() != DialogResult.OK) return;

            MessageBox.Show(_dal.WriteToXml(fileDialog.FileName)
                ? "Данные были успешно записаны"
                : "Данные не были записаны");
        }
    }
}

