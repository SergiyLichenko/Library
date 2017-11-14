using System.Collections.Generic;
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
            var dataGridViewColumn = dataGridView_notAddedItems.Columns["ItemFields"];
            if (dataGridViewColumn != null)
                dataGridViewColumn.Visible = false;
            var gridViewColumn = dataGridView_notAddedItems.Columns["MagazineFields"];
            if (gridViewColumn != null)
                gridViewColumn.Visible = false;
        }

        public NotAddedMagazines(List<Article> articles)
        {
            InitializeComponent();
            dataGridView_notAddedItems.DataSource = articles;

            var dataGridViewColumn = dataGridView_notAddedItems.Columns["ItemFields"];
            if (dataGridViewColumn != null)
                dataGridViewColumn.Visible = false;
            var gridViewColumn = dataGridView_notAddedItems.Columns["AuthorFields"];
            if (gridViewColumn != null)
                gridViewColumn.Visible = false;
            var viewColumn = dataGridView_notAddedItems.Columns["MagazineFields"];
            if (viewColumn != null)
                viewColumn.Visible = false;
            var column = dataGridView_notAddedItems.Columns["ArticleFields"];
            if (column != null)
                column.Visible = false;
        }

        public NotAddedMagazines(List<Book> book)
        {
            InitializeComponent();
            if (dataGridView_notAddedItems == null) return;

            dataGridView_notAddedItems.DataSource = book;
            var dataGridViewColumn = dataGridView_notAddedItems.Columns["ItemFields"];
            if (dataGridViewColumn != null)
                dataGridViewColumn.Visible = false;
            var gridViewColumn = dataGridView_notAddedItems.Columns["AuthorFields"];
            if (gridViewColumn != null)
                gridViewColumn.Visible = false;
            var viewColumn = dataGridView_notAddedItems.Columns["BookFields"];
            if (viewColumn != null)
                viewColumn.Visible = false;
        }
    }
}
