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
    public partial class NotAddedMagazines : Form
    {
        public NotAddedMagazines(List<Magazine> magazines)
        {
            InitializeComponent();
            dataGridView_notAddedItems.DataSource = magazines;
            dataGridView_notAddedItems.Columns["ItemFields"].Visible = false;
            dataGridView_notAddedItems.Columns["MagazineFields"].Visible = false;
        }
        public NotAddedMagazines(List<Article> Articles)
        {
            InitializeComponent();
            dataGridView_notAddedItems.DataSource = Articles;
            
            dataGridView_notAddedItems.Columns["ItemFields"].Visible = false;
            dataGridView_notAddedItems.Columns["AuthorFields"].Visible = false;
            dataGridView_notAddedItems.Columns["MagazineFields"].Visible = false;
            dataGridView_notAddedItems.Columns["ArticleFields"].Visible = false;
        }
        public NotAddedMagazines(List<Book> book)
        {
            InitializeComponent();
            dataGridView_notAddedItems.DataSource = book;
            dataGridView_notAddedItems.Columns["ItemFields"].Visible = false;
            dataGridView_notAddedItems.Columns["AuthorFields"].Visible = false;
            dataGridView_notAddedItems.Columns["BookFields"].Visible = false;
        }
    }
}
