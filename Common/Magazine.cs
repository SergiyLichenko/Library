using System;
using System.Collections.Generic;

namespace Common
{
    public class Magazine : Item
    {
        public string IssueNumber { get; }

        public Dictionary<string, string> ItemFields { get; }
        public Dictionary<string, string> MagazineFields { get; }

        public Magazine(string name, string publisher, string publishedDate, string issueNumber)
            : this
                (String.Empty, name, publisher, publishedDate, issueNumber)
        { }
        public Magazine(string id, string name, string publisher, string publishedDate, string issueNumber)
        {
            Id = id;
            Name = name;
            Publisher = publisher;
            PublishedDate = publishedDate;
            IssueNumber = issueNumber;

            ItemFields = new Dictionary<string, string>(3)
            {
                {"Name", Name},
                {"Publisher", Publisher},
                {"Published Date", PublishedDate}
            };

            MagazineFields = new Dictionary<string, string>(1) { { "IssueNumber", IssueNumber } };
        }
    }
}
