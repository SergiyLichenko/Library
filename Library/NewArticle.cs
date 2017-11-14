using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using Common;
namespace Library
{
    public delegate void SelectItem(object sender, EventArgs e);
    public partial class NewArticle : Form
    {
        public List<Article> NewArticles { get; }
        public event SelectItem SelectMagName;
        private readonly List<Magazine> _allMagazines;

        public NewArticle(List<Magazine> allMagazines)
        {
            InitializeComponent();
            _allMagazines = allMagazines;
            textBox_ID.Text = Guid.NewGuid().ToString();
            FillListBoxes();
            SelectMagName += MyEventForListBox;
            NewArticles = new List<Article>();
            button_SaveArticle.Enabled = false;
        }

        private void MyEventForListBox(object sender, EventArgs e)
        {
            if (listBox_MagazineName.SelectedItem == null)
                return; 
            
            listBox_MagazineIssueNumber.Items.Clear();
            var searchedName = listBox_MagazineName.SelectedItem.ToString();
            var findedMagazines = _allMagazines.FindAll(val => val.Name == searchedName);

            if (findedMagazines.Count > 0)
                foreach (Magazine magazine in findedMagazines)
                    listBox_MagazineIssueNumber.Items.Add(magazine.IssueNumber);
            else
                listBox_MagazineIssueNumber.DataSource = null;            
        }

        private void FillListBoxes()
        {
            if (_allMagazines == null)
                return;

            foreach (Magazine magazine in _allMagazines)
            {
                if (listBox_MagazineName.Items.Count == 0)
                {
                    listBox_MagazineName.Items.Add(magazine.Name);
                    continue;
                }
                for (int i = 0; i < listBox_MagazineName.Items.Count; i++)
                    if (listBox_MagazineName.Items[i].ToString() != magazine.Name)
                    {
                        listBox_MagazineName.Items.Add(magazine.Name);
                        break;
                    }
            }
        }

        private void ListBox_MagazineName_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectMagName?.Invoke(null, null);
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void Button_AddArticle_Click(object sender, EventArgs e)
        {
            try
            {
                var id = textBox_ID.Text.Trim();
                var name = textBox_Name.Text.Trim();
                var publisher = textBox_Publisher.Text.Trim();
                var publishedDate = dateTimePicker_PublishedDate.Value.ToString(CultureInfo.InvariantCulture);
                var authorName = textBox_AuthorName.Text.Trim();
                var version = textBox_Version.Text.Trim();
                var magazineName = listBox_MagazineName.SelectedItem.ToString().Trim();
                var magazineIssueNumber = listBox_MagazineIssueNumber.SelectedItem.ToString().Trim();

                if (name == string.Empty || publisher == string.Empty || publishedDate == string.Empty || authorName == string.Empty ||
                version == string.Empty || magazineName == string.Empty || magazineIssueNumber == string.Empty)
                {
                    MessageBox.Show(@"Заполните или выберите все поля");
                    return;
                }

                var tempArticle = new Article(id, name,
                    publisher, publishedDate,
                    magazineName, magazineIssueNumber, 
                    authorName, version);

                NewArticles.Add(tempArticle);
                label_ArticlesCount.Text = $@"Новых статей: {NewArticles.Count}";

                MessageBox.Show(@"Для сохранения всех статей нажмите 'Save Articles'");
                textBox_ID.Text = Guid.NewGuid().ToString();
                button_SaveArticle.Enabled = true;
            }            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_SaveArticle_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
