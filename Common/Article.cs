using System;
using System.Collections.Generic;

namespace Common
{
    public class Article:Item
    {
        public string MagazineName { get; }
        public string MagazineIssueNumber { get;  }
        public string AuthorName { get; }
        public string Version { get;  }
                                    
        public Dictionary<string, string> ItemFields { get; }
        public Dictionary<string, string> MagazineFields { get; }
        public Dictionary<string, string> AuthorFields { get;  }
        public Dictionary<string, string> ArticleFields { get;  }

        public Article() { }
        public Article(string name, string publisher, string publishedDate, string magazineName,
            string magazineIssueNumber, string author, string version)
            : this(String.Empty, name, publisher, publishedDate, magazineName, magazineIssueNumber, author, version)
        {
        }

        public Article(string id, string name, string publisher, string publishedDate, string magazineName,
            string magazineIssueNumber, string author, string version)
        {
            if(string.IsNullOrWhiteSpace(id)) throw new ArgumentException(nameof(id));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(nameof(name));
            if (string.IsNullOrWhiteSpace(publisher)) throw new ArgumentException(nameof(publisher));
            if (string.IsNullOrWhiteSpace(publishedDate)) throw new ArgumentException(nameof(publishedDate));
            if (string.IsNullOrWhiteSpace(magazineName)) throw new ArgumentException(nameof(magazineName));
            if (string.IsNullOrWhiteSpace(magazineIssueNumber)) throw new ArgumentException(nameof(magazineIssueNumber));
            if (string.IsNullOrWhiteSpace(author)) throw new ArgumentException(nameof(author));
            if (string.IsNullOrWhiteSpace(version)) throw new ArgumentException(nameof(version));

            ID = id;
            Name = name;
            Publisher = publisher;
            PublishedDate = publishedDate;
            MagazineName = magazineName;
            MagazineIssueNumber = magazineIssueNumber;
            AuthorName = author;
            Version = version;

            ItemFields = new Dictionary<string, string>(3)
            {
                {"Name", Name},
                {"Publisher", Publisher},
                {"PublishedDate", PublishedDate}
            };

            MagazineFields = new Dictionary<string, string>(2)
                {
                    {"Name", MagazineName},
                    {"IssueNumber", MagazineIssueNumber}
                };

            AuthorFields = new Dictionary<string, string>(2) {{"Name", AuthorName}};
            ArticleFields = new Dictionary<string, string>(1) {{"Version", Version}};
        }
    }
}