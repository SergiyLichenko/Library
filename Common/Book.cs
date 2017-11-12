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
            if(string.IsNullOrWhiteSpace(id)) throw new ArgumentException(nameof(id));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(nameof(name));
            if (string.IsNullOrWhiteSpace(publisher)) throw new ArgumentException(nameof(publisher));
            if (string.IsNullOrWhiteSpace(publishedDate)) throw new ArgumentException(nameof(publishedDate));
            if (string.IsNullOrWhiteSpace(isbn)) throw new ArgumentException(nameof(isbn));
            if (string.IsNullOrWhiteSpace(authorName)) throw new ArgumentException(nameof(authorName));

            ID = id;
            Name = name;
            Publisher = publisher;
            PublishedDate = publishedDate;
            ISBN = isbn;
            AuthorName = authorName;

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
