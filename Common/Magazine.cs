using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Magazine:Item
    {
        public string IssueNumber { get; set; }

        public Dictionary<string, string> ItemFields { get; private set; }
        public Dictionary<string, string> MagazineFields{get;private set;}

        public Magazine() { }
        public Magazine(string name, string publisher, string publishedDate, string issueNumber)
            : this
                (String.Empty, name, publisher, publishedDate, issueNumber) { }
        public Magazine(string id,string name, string publisher, string publishedDate, string issueNumber)
        {
            this.ID = id;
            this.Name = name;
            this.Publisher = publisher;
            this.PublishedDate = publishedDate;
            this.IssueNumber = issueNumber;

            ItemFields = new Dictionary<string, string>(3);
            ItemFields.Add("Name", Name);
            ItemFields.Add("Publisher", Publisher);
            ItemFields.Add("Published Date", PublishedDate.ToString());

            MagazineFields = new Dictionary<string, string>(1);
            MagazineFields.Add("IssueNumber", IssueNumber);
        }
    }
}
