namespace Common
{
    public class Copy
    {
        public string Id { get; }
        public string ItemId { get; }
        public bool IsBorrowed { get;  }

        public Copy(string id, string itemId, bool isBorrowed)
        {
            Id = id;
            ItemId = itemId;
            IsBorrowed = isBorrowed;
        }
    }
}
