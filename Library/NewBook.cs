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
using System.Globalization;
namespace Library
{
    public partial class NewBook : Form
    {
        public List<Book> book;
        public NewBook()
        {
            InitializeComponent();
            this.textBox_ID.Text = Guid.NewGuid().ToString();
            this.textBox_ISBN.Text = Guid.NewGuid().ToString();
            book = new List<Book>();
            button_SaveBook.Enabled = false;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Hide();
        }

        private void button_SaveBook_Click(object sender, EventArgs e)
        {
            if (book.Count != 0)
                this.DialogResult = DialogResult.OK;
            else
                MessageBox.Show("Не было добавлено книг для сохранения");

        }

        private void button_AddBook_Click(object sender, EventArgs e)
        {
            if (this.textBox_Author.Text.Trim() == String.Empty || this.textBox_Name.Text.Trim() == String.Empty ||
                this.textBox_Publisher.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Fill all information");
                return;
            }
            button_SaveBook.Enabled = true;
            book.Add(new Book(this.textBox_ID.Text.Trim(), this.textBox_Name.Text.Trim(), this.textBox_Publisher.Text.Trim(),
                this.dateTimePicker_PublishedDate.Value.ToString(), this.textBox_ISBN.Text.Trim(), this.textBox_Author.Text.Trim()));
            label_bookCount.Text = "Новых книг: " + book.Count;
            MessageBox.Show("Книга была добавлена в очередь добавления (для добавления нажмите Save Book, для отмены - Cancel)");
            this.textBox_ID.Text = Guid.NewGuid().ToString();
            this.textBox_ISBN.Text = Guid.NewGuid().ToString();
        }
    }
}
