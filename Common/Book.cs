using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Book:Item
    {
        public string ISBN { get; set; }
        public string AuthorName { get; set; }

        public Dictionary<string, string> ItemFields { get; private set; }
        public Dictionary<string, string> AuthorFields { get; private set; }
        public Dictionary<string, string> BookFields { get; private set; }

        public Book() { }
        public Book(string name,string publisher,string publishedDate,string isbn,string authorName):
            this (String.Empty,name,publisher,publishedDate,isbn,authorName){}

        public Book(string id, string name, string publisher, string publishedDate, string isbn, string authorName)
        {
            this.ID = id;
            this.Name = name;
            this.Publisher = publisher;
            this.PublishedDate = publishedDate;
            this.ISBN = isbn;
            this.AuthorName = authorName;

            ItemFields = new Dictionary<string, string>(3);            
            ItemFields.Add("Name", Name);
            ItemFields.Add("Publisher", Publisher);
            ItemFields.Add("PublishedDate", PublishedDate);

            AuthorFields = new Dictionary<string, string>(1);
            AuthorFields.Add("Name", AuthorName);

            BookFields = new Dictionary<string, string>(1);
            BookFields.Add("ISBN", ISBN);
        }

    }
}
