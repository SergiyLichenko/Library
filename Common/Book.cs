using System;
using System.Collections.Generic;

namespace Common
{
    /// <summary>
    /// Class that represents book entity from database
    /// </summary>
    public class Book : Item
    {
        /// <summary>
        /// ISBN of the book
        /// </summary>
        public string ISBN { get; set; }

        /// <summary>
        /// Name of author
        /// </summary>
        public string AuthorName { get; set; }

        /// <summary>
        /// Fields that are related to the Items table
        /// </summary>
        public Dictionary<string, string> ItemFields { get; }

        /// <summary>
        /// Fields that are related to the Authors table
        /// </summary>
        public Dictionary<string, string> AuthorFields { get; }

        /// <summary>
        /// Fields that are related to the Books table
        /// </summary>
        public Dictionary<string, string> BookFields { get; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Book() { }
        public Book(string name, string publisher, string publishedDate, string isbn, string authorName) :
            this(String.Empty, name, publisher, publishedDate, isbn, authorName)
        { }

        public Book(string id, string name, string publisher, string publishedDate,
            string isbn, string authorName)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
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
