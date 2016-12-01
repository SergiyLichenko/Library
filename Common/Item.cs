using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public abstract class Item
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public string PublishedDate { get; set; }
    }
}
