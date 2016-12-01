using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Copy
    {
        public string ID { get;  set; }
        public string ItemID { get;  set; }
        public bool isBorrowed { get;  set; }

        public Copy(string ID, string ItemID, bool isBorrowed)
        {
            this.ID = ID;
            this.ItemID = ItemID;
            this.isBorrowed = isBorrowed;
        }
    }
}
