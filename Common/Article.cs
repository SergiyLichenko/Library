using System;
using System.Collections.Generic;

namespace Common
{
    /// <summary>
    /// Class which represents article entity from database
    /// </summary>
    public class Article:Item
    {
        /// <summary>
        /// The name of the magazin
        /// </summary>
        public string MagazineName { get; }

        /// <summary>
        /// Magazine's issue number
        /// </summary>
        public string MagazineIssueNumber { get;  }

        /// <summary>
        /// Name of the magazine's author
        /// </summary>
        public string AuthorName { get; }

        /// <summary>
        /// Magazine's version
        /// </summary>
        public string Version { get;  }
                          
        /// <summary>
        /// Fields that are related to Items table
        /// </summary>
        public Dictionary<string, string> ItemFields { get; }

        /// <summary>
        /// Fields that are related to Magazines table
        /// </summary>
        public Dictionary<string, string> MagazineFields { get; }

        /// <summary>
        /// Fields that are related to Authors table
        /// </summary>
        public Dictionary<string, string> AuthorFields { get;  }

        /// <summary>
        /// Fields that are related to Article table
        /// </summary>
        public Dictionary<string, string> ArticleFields { get;  }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Article() { }

        public Article(string name, string publisher, string publishedDate, string magazineName,
            string magazineIssueNumber, string author, string version)
            : this(String.Empty, name, publisher, publishedDate, magazineName, magazineIssueNumber, author, version)
        {
        }

        public Article(string id, string name, string publisher, string publishedDate, string magazineName,
            string magazineIssueNumber, string author, string version)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
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