namespace Common
{
    public class User
    {
        public string Id { get; }
        public string Name { get; }
        public string UserName { get; }
        public string Password { get; }
        public bool IsAdmin { get; }

        public User(string id,string name, string userName, string password, bool isAdmin)
        {
            Id = id;
            Name = name;
            UserName = userName;
            Password = password;
            IsAdmin = isAdmin;
        }
    }
}
