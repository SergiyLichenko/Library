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
            ID = id ?? throw new ArgumentNullException(nameof(id));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
            PublishedDate = publishedDate ?? throw new ArgumentNullException(nameof(publishedDate));
            MagazineName = magazineName ?? throw new ArgumentNullException(nameof(magazineName));
            MagazineIssueNumber = magazineIssueNumber ?? throw new ArgumentNullException(nameof(magazineIssueNumber));
            AuthorName = author ?? throw new ArgumentNullException(nameof(author));
            Version = version ?? throw new ArgumentNullException(nameof(version));

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