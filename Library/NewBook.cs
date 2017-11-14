using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using Common;

namespace Library
{
    public partial class NewBook : Form
    {
        public readonly List<Book> Book;
        public NewBook()
        {
            InitializeComponent();
            textBox_ID.Text = Guid.NewGuid().ToString();
            textBox_ISBN.Text = Guid.NewGuid().ToString();
            Book = new List<Book>();
            button_SaveBook.Enabled = false;
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Hide();
        }

        private void Button_SaveBook_Click(object sender, EventArgs e)
        {
            if (Book.Count != 0)
                DialogResult = DialogResult.OK;
            else
                MessageBox.Show(@"Не было добавлено книг для сохранения");

        }

        private void Button_AddBook_Click(object sender, EventArgs e)
        {
            if (textBox_Author.Text.Trim() == String.Empty || textBox_Name.Text.Trim() == String.Empty ||
                textBox_Publisher.Text.Trim() == String.Empty)
            {
                MessageBox.Show(@"Fill all information");
                return;
            }

            button_SaveBook.Enabled = true;
            Book.Add(new Book(textBox_ID.Text.Trim(), 
                textBox_Name.Text.Trim(), 
                textBox_Publisher.Text.Trim(),
                dateTimePicker_PublishedDate.Value.ToString(CultureInfo.InvariantCulture), 
                textBox_ISBN.Text.Trim(), 
                textBox_Author.Text.Trim()));

            label_bookCount.Text = @"Новых книг: " + Book.Count;
            MessageBox.Show(@"Книга была добавлена в очередь добавления (для добавления нажмите Save Book, для отмены - Cancel)");
            textBox_ID.Text = Guid.NewGuid().ToString();
            textBox_ISBN.Text = Guid.NewGuid().ToString();
        }
    }
}
