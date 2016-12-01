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
    public delegate void SelectItem(object sender, EventArgs e);
    public partial class NewArticle : Form
    {
        public List<Article> newArticles { get; private set; }
        public event SelectItem SelectMagName;
        List<Magazine> allMagazines;
        public NewArticle(List<Magazine> allMagazines)
        {
            InitializeComponent();
            this.allMagazines = allMagazines;
            textBox_ID.Text = Guid.NewGuid().ToString();
            FillListBoxes();
            SelectMagName += new SelectItem(MyEventForListBox);
            newArticles = new List<Article>();
            this.button_SaveArticle.Enabled = false;
        }

        private void MyEventForListBox(object sender, EventArgs e)
        {
            if (listBox_MagazineName.SelectedItem == null)
                return;     
            listBox_MagazineIssueNumber.Items.Clear();
            string searchedName = listBox_MagazineName.SelectedItem.ToString();
            List<Magazine> findedMagazines = allMagazines.FindAll(val => val.Name == searchedName);
            if (findedMagazines != null && findedMagazines.Count > 0)
            {
                foreach (Magazine magazine in findedMagazines)
                    listBox_MagazineIssueNumber.Items.Add(magazine.IssueNumber);
            }
            else
                listBox_MagazineIssueNumber.DataSource = null;            
        }

       

        private void FillListBoxes()
        {
            if (allMagazines == null)
                return;
            foreach (Magazine magazine in allMagazines)
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

        private void listBox_MagazineName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectMagName != null)
                SelectMagName(null, null);            
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void button_AddArticle_Click(object sender, EventArgs e)
        {
            try
            {
                string id = textBox_ID.Text.Trim();
                string name = textBox_Name.Text.Trim();
                string publisher = textBox_Publisher.Text.Trim();
                string publishedDate = dateTimePicker_PublishedDate.Value.ToString();
                string authorName = textBox_AuthorName.Text.Trim();
                string version = textBox_Version.Text.Trim();
                string magazineName = listBox_MagazineName.SelectedItem.ToString().Trim();
                string magazineIssueNumber = listBox_MagazineIssueNumber.SelectedItem.ToString().Trim();

                if (name == String.Empty || publisher == String.Empty || publishedDate == String.Empty || authorName == String.Empty ||
                version == String.Empty || magazineName == String.Empty || magazineIssueNumber == String.Empty)
                {
                    MessageBox.Show("Заполните или выберите все поля");
                    return;
                }
                Article tempArticle = new Article(id, name, publisher, publishedDate, magazineName, magazineIssueNumber, authorName, version);
                newArticles.Add(tempArticle);
                label_ArticlesCount.Text = String.Format("Новых статей: {0}", newArticles.Count);
                MessageBox.Show("Для сохранения всех статей нажмите 'Save Articles'");
                textBox_ID.Text = Guid.NewGuid().ToString();
                this.button_SaveArticle.Enabled = true;
            }            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_SaveArticle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
