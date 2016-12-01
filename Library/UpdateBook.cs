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
    public partial class UpdateBook : Form
    {
        public Book book { get; private set; }
        public UpdateBook()
        {
            InitializeComponent();
        }
        public UpdateBook(Book book)
        {
            InitializeComponent();
            this.textBox_NameOrigin.Text = book.Name;
            this.textBox_AuthorOrigin.Text = book.AuthorName;            
            this.textBox_PublisherOrigin.Text = book.Publisher;
            this.textBox_PublishedDateOrigin.Text = book.PublishedDate;

            this.book = new Book();
            this.book.ID = book.ID;
            this.book.ISBN = book.ISBN;            
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_Name.Text.Trim() != String.Empty)
                book.Name = textBox_Name.Text.Trim();
            else
                book.Name = textBox_NameOrigin.Text.Trim();

            if (textBox_Publisher.Text.Trim() != String.Empty)
                book.Publisher = textBox_Publisher.Text.Trim();
            else
                book.Publisher = textBox_PublisherOrigin.Text.Trim();

            if (textBox_Author.Text.Trim() != String.Empty)
                book.AuthorName = textBox_Author.Text.Trim();
            else
                book.AuthorName = textBox_AuthorOrigin.Text.Trim();

            if (checkBox1.Checked)
                book.PublishedDate = dateTimePicker_PublishedDate.Value.ToString();
            else
                book.PublishedDate = textBox_PublishedDateOrigin.Text.Trim();

            this.DialogResult = DialogResult.OK;
        }
    }
}
