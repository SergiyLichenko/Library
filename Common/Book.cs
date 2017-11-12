using System;
using System.Collections.Generic;

namespace Common
{
    public class Book : Item
    {
        public string ISBN { get; set; }
        public string AuthorName { get; set; }

        public Dictionary<string, string> ItemFields { get; }
        public Dictionary<string, string> AuthorFields { get; }
        public Dictionary<string, string> BookFields { get; }

        public Book() { }
        public Book(string name, string publisher, string publishedDate, string isbn, string authorName) :
            this(String.Empty, name, publisher, publishedDate, isbn, authorName)
        { }

        public Book(string id, string name, string publisher, string publishedDate,
            string isbn, string authorName)
        {
            ID = id ?? throw new ArgumentNullException(nameof(id));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
            PublishedDate = publishedDate ?? throw new ArgumentNullException(nameof(publishedDate));
            ISBN = isbn ?? throw new ArgumentNullException(nameof(isbn));
            AuthorName = authorName ?? throw new ArgumentNullException(nameof(authorName));

            ItemFields = new Dictionary<string, string>(3)
            {
                {"Name", Name},
                {"Publisher", Publisher},
                {"PublishedDate", PublishedDate}
            };

            AuthorFields = new Dictionary<string, string>(1) {{"Name", AuthorName}};

            BookFields = new Dictionary<string, string>(1) {{"ISBN", ISBN}};
        }
    }
}
