using System;

namespace Common
{
    public class Copy
    {
        public string Id { get; }
        public string ItemId { get; }
        public bool IsBorrowed { get;  }

        public Copy(string id, string itemId, bool isBorrowed)
        {
            if(string.IsNullOrWhiteSpace(id)) throw new ArgumentException(nameof(ArgumentException));
            if(string.IsNullOrWhiteSpace(itemId)) throw new ArgumentException(nameof(ArgumentException));

            Id = id;
            ItemId = itemId;
            IsBorrowed = isBorrowed;
        }
    }
}
