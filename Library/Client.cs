using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;
using Common;

namespace Library
{
    public delegate void ChangeUser(Client client);
    public partial class Client : Form
    {
        
        List<Book> books;
        List<Magazine> magazines;
        List<Article> articles;
        public User currentUser;
        Point point = new Point();
        DataAccessLayer.DataAccessLayer DAL;
        public event ChangeUser changeUser;
        public Client()
        {
            LogIn logIn = new LogIn();
            if (logIn.ShowDialog() == DialogResult.OK)
                DAL = new DataAccessLayer.DataAccessLayer(logIn.dataType, logIn.ConnectionParameters);

            Authorization authorization = new Authorization();
            authorization.LookInDb += this.Authorization_LookInDB;
            if (authorization.ShowDialog() == DialogResult.OK)
                MessageBox.Show("\tАвторизация пройдена\nВы вошли под именем " + this.currentUser.UserName + ", Admin - " + this.currentUser.IsAdmin + "\n\nВаше настоящее имя " + this.currentUser.Name);
            else
                return;
            authorization.LookInDb -= this.Authorization_LookInDB;

            InitializeComponent();
          
           

            button_Refresh_Click(null, null);
            button_RefreshMagazine_Click(null, null);
            button_RefreshArticle_Click(null, null);
            if (this.currentUser != null)
                this.label_UserName.Text = String.Format("Здраствуйте, {0}", this.currentUser.Name);

        }

        public bool Authorization_LookInDB(string userName,string password)
        {
            return DAL.GetCurrentUser(userName,password, out currentUser);
        }

        private void button_Refresh_Click(object sender, EventArgs e)
        {
            if (DAL == null)
                return;
            if ((sender == null && e == null) ||
                (textBox_BookName.Text.Trim() == String.Empty && textBox_BookPublisher.Text.Trim() == String.Empty
                && textBox_BookAuthor.Text.Trim() == String.Empty))
            {
                books = DAL.GetAllBooks();
                dataGridView_Books.DataSource = books;
            }
           
                Book searchedBook = new Book(textBox_BookName.Text.Trim(), textBox_BookPublisher.Text.Trim(),
                    String.Empty, string.Empty, textBox_BookAuthor.Text.Trim());
                books = DAL.SearchedBooks(searchedBook);
                if (books == null)
                    dataGridView_Books.DataSource = null;
                else
                    dataGridView_Books.DataSource = books;
            
            if (dataGridView_Books.Columns.Count != 0 && dataGridView_Books.Rows.Count != 0)
            {
                dataGridView_Books.Columns["ItemFields"].Visible = false;
                dataGridView_Books.Columns["AuthorFields"].Visible = false;
                dataGridView_Books.Columns["BookFields"].Visible = false;
            }
        }

        private void добавитьКнигуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewBook newBook = new NewBook();
            if (newBook.ShowDialog() == DialogResult.OK && newBook.book.Count > 0)
            {
                List<Book> notAdded = DAL.AddBook(newBook.book);
                button_Refresh_Click(null, null);
                MessageBox.Show("Книга была добавлена");
                if (notAdded.Count > 0)
                {
                    NotAddedMagazines notAddedForm = new NotAddedMagazines(notAdded);
                    notAddedForm.ShowDialog();
                }
            }
            else
                MessageBox.Show("Не было добавлено новых книг для сохранения");
        }

   
        private void updateSelectedBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView_Books.CurrentCell == null)
                return;
            Book book = books[dataGridView_Books.CurrentRow.Index];

            UpdateBook updateBook = new UpdateBook(book);
            if(updateBook.ShowDialog()==DialogResult.OK)
            {
                if (DAL.UpdateBook(updateBook.book))
                    MessageBox.Show("Книга была успешно изменена");
                else
                    MessageBox.Show("Изменения не были произведены");
            }
            button_Refresh_Click(null, null);
        }

        private void button_RefreshMagazine_Click(object sender, EventArgs e)
        {
            if (DAL == null)
                return;
            if ((sender==null && e==null) || (textBox_Name.Text.Trim() == String.Empty && textBox_Publisher.Text.Trim() == String.Empty && 
                textBox_IssueNumber.Text.Trim() == String.Empty))
            {
                magazines = DAL.GetAllMagazines();
                if (magazines == null || magazines.Count == 0 )
                {
                    dataGridView_Magazines.DataSource = null;
                    return;
                }

                dataGridView_Magazines.DataSource = magazines;
                dataGridView_Magazines.Columns["ItemFields"].Visible = false;
                dataGridView_Magazines.Columns["MagazineFields"].Visible = false;
                return;
            }
            Magazine searchedMagazine;

           
          
                searchedMagazine = new Magazine(textBox_Name.Text.Trim(), textBox_Publisher.Text.Trim(),
                    String.Empty, textBox_IssueNumber.Text.Trim());

            magazines = DAL.SearchedMagazines(searchedMagazine);
            if (magazines == null)
                dataGridView_Magazines.DataSource = null;
            else
            {
                dataGridView_Magazines.DataSource = magazines;
                dataGridView_Magazines.Columns["ItemFields"].Visible = false;
                dataGridView_Magazines.Columns["MagazineFields"].Visible = false;
            }

        }

        private void button_RefreshArticle_Click(object sender, EventArgs e)
        {
            if (DAL == null)
                return;
            if (sender == null && e == null)
            {
                articles = DAL.GetAllArticles();
                if (articles != null)
                    dataGridView_Articles.DataSource = articles;
                else
                {
                    dataGridView_Articles.DataSource = null;
                    return;
                }
            }
            else            
            {
                Article searchedArticle;
               
               
                    searchedArticle = new Article(textBox_articleName.Text.Trim(), textBox_articlePublisher.Text.Trim(),
                        String.Empty, String.Empty, String.Empty, textBox_articleAuthor.Text.Trim(), String.Empty);
                articles = DAL.SearchedArticles(searchedArticle);
                if (articles != null)
                    dataGridView_Articles.DataSource = articles;
                else
                {
                    dataGridView_Articles.DataSource = null;
                    return;
                }
            }
            dataGridView_Articles.Columns["ItemFields"].Visible = false;
            dataGridView_Articles.Columns["MagazineFields"].Visible = false;
            dataGridView_Articles.Columns["AuthorFields"].Visible = false;
            dataGridView_Articles.Columns["ArticleFields"].Visible = false;
        }

        private void addNewMagazineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Magazine> notAdded;
            NewMagazine newMagazine = new NewMagazine();
            if (newMagazine.ShowDialog() == DialogResult.OK)
            {
                notAdded=DAL.AddMagazines(newMagazine.magazines);
                button_RefreshMagazine_Click(null, null);
                if (notAdded.Count>0)
                {                   
                    MessageBox.Show("Некоторые журналы не были сохранены в базе данных");
                    NotAddedMagazines notAddedItems = new NotAddedMagazines(notAdded);
                    notAddedItems.ShowDialog();
                }
                else if(notAdded==null)
                    MessageBox.Show("Не было добавлено новых журналов для сохранения");
                else
                    MessageBox.Show("Новый журнал был успешно добавлен");
            }
            
        }

      

        private void addNewArticleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewArticle newArticle = new NewArticle(DAL.GetAllMagazines());
            
            if (newArticle.ShowDialog() == DialogResult.OK)
            {
                List<Article> notAdded = DAL.AddArticles(newArticle.newArticles);
                button_RefreshArticle_Click(null, null);
                MessageBox.Show("Новая статья была успешно добавлена");
                if (notAdded != null && notAdded.Count > 0)
                {   //not added items
                    NotAddedMagazines notAdd = new NotAddedMagazines(notAdded);
                    notAdd.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Новая статья не была добавлена");
            }
            
        }

        private void showAllCopiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView_Books.CurrentRow == null)
                return;

            string searchedID = String.Empty;
            searchedID = this.dataGridView_Books.Rows[point.Y].Cells["ID"].Value.ToString();
            List<Copy> booksCopies = DAL.GetAllCopiesBooks(searchedID);
            Book book = books[point.Y];
            List<User> allUsers = DAL.GetAllUsers();
            ShowAllCopies showCopies = new ShowAllCopies(booksCopies, book,allUsers);
            if (showCopies.ShowDialog() == DialogResult.OK)
            {
                if (DAL.SaveNewBorrow(showCopies.borrowForSave))
                    MessageBox.Show("Новая книга успешно выдана");
                else
                    MessageBox.Show("Новая книга не была выдана");
            }
        }

        private void dataGridView_Books_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.point.Y = e.RowIndex;
            this.point.X = e.ColumnIndex;
        }

        private void showAllUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<User> allUsers = DAL.GetAllUsers();
            
            List<Borrowing> borrows = DAL.GetAllUserBorrowings();
            

            BooksCancelation bookCancel = new BooksCancelation(allUsers, borrows, currentUser.IsAdmin);
            if(bookCancel.ShowDialog() == DialogResult.OK)
            {
                if (DAL.DeleteUserCopy(bookCancel.borrowForSaveAndDelete))
                    MessageBox.Show("Книга была успешно списана");
                else
                    MessageBox.Show("Книга не была списана");
            }
        }

        private void createNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_User newUser = new New_User();

            if(newUser.ShowDialog() == DialogResult.OK)
            {
                if(DAL.AddNewUser(newUser.user))
                    MessageBox.Show("Новый пользователь добавлен");
                else
                    MessageBox.Show("Новый пользователь не был добавлен");
            }
        }

        private void Client_Load(object sender, EventArgs e)
        {
            
            if(this.currentUser.IsAdmin==false)
            {
                this.добавитьКнигуToolStripMenuItem.Enabled = false;
                this.updateSelectedBookToolStripMenuItem.Enabled = false;
                this.addNewMagazineToolStripMenuItem.Enabled = false;
                this.addNewArticleToolStripMenuItem.Enabled = false;
                this.createNewUserToolStripMenuItem.Enabled = false;
                this.showAllCopiesToolStripMenuItem.Enabled = false;
            }
        }

        private void changeUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (changeUser != null)            
                changeUser(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void writeToXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            if(fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (DAL.WriteToXML(fileDialog.FileName))
                    MessageBox.Show("Данные были успешно записаны");
                else
                    MessageBox.Show("Данные не были записаны");
            }
        }
    }
}

