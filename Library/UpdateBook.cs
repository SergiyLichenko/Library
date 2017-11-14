using System;
using System.Globalization;
using System.Windows.Forms;
using Common;

namespace Library
{
    public partial class UpdateBook : Form
    {
        public Book Book { get; }
        public UpdateBook()
        {
            InitializeComponent();
        }

        public UpdateBook(Book book)
        {
            InitializeComponent();
            textBox_NameOrigin.Text = book.Name;
            textBox_AuthorOrigin.Text = book.AuthorName;            
            textBox_PublisherOrigin.Text = book.Publisher;
            textBox_PublishedDateOrigin.Text = book.PublishedDate;

            Book = new Book();
            Book.Id = book.Id;
            Book.ISBN = book.ISBN;            
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Book.Name = textBox_Name.Text.Trim() != String.Empty ? textBox_Name.Text.Trim() : textBox_NameOrigin.Text.Trim();
            Book.Publisher = textBox_Publisher.Text.Trim() != String.Empty ? textBox_Publisher.Text.Trim() : textBox_PublisherOrigin.Text.Trim();
            Book.AuthorName = textBox_Author.Text.Trim() != String.Empty ? textBox_Author.Text.Trim() : textBox_AuthorOrigin.Text.Trim();
            Book.PublishedDate = checkBox1.Checked ? dateTimePicker_PublishedDate.Value.ToString(CultureInfo.InvariantCulture) : textBox_PublishedDateOrigin.Text.Trim();

            DialogResult = DialogResult.OK;
        }
    }
}
