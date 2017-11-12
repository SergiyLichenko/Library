using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Article:Item
    {
        public string MagazineName { get; private set; }
        public string MagazineIssueNumber { get; private set; }
        public string AuthorName { get; private set; }
        public string Version { get; private set; }
                                    
        public Dictionary<string, string> ItemFields { get; private set; }
        public Dictionary<string, string> MagazineFields { get; private set; }
        public Dictionary<string, string> AuthorFields { get; private set; }
        public Dictionary<string, string> ArticleFields { get; private set; }

        public Article() { }
        public Article(string name, string publisher, string PublishedDate, string magazineName,
            string magazineIssueNumber, string author, string version)
            : this(String.Empty, name, publisher, PublishedDate, magazineName, magazineIssueNumber, author, version)
        {
        }
        public Article(string id, string name, string publisher, string publishedDate, string magazineName,
            string magazineIssueNumber, string author, string version)
        {
            ID = id;
            Name = name;
            Publisher = publisher;
            PublishedDate = publishedDate;
            MagazineName = magazineName;
            MagazineIssueNumber = magazineIssueNumber;
            AuthorName = author;
            Version = version;

            ItemFields = new Dictionary<string, string>(3);
            ItemFields.Add("Name", Name);
            ItemFields.Add("Publisher", Publisher);
            ItemFields.Add("PublishedDate", PublishedDate.ToString());

            MagazineFields = new Dictionary<string, string>(2);
            MagazineFields.Add("Name", MagazineName);
            MagazineFields.Add("IssueNumber", MagazineIssueNumber);

            AuthorFields = new Dictionary<string, string>(2);
            AuthorFields.Add("Name", AuthorName);

            ArticleFields = new Dictionary<string, string>(1);
            ArticleFields.Add("Version", Version);
        }

    }
}
