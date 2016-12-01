using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class User
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public User(string id,string name, string userName, string password, bool isAdmin)
        {
            this.ID = id;
            this.Name = name;
            this.UserName = userName;
            this.Password = password;
            this.IsAdmin = isAdmin;
        }
    }
}
