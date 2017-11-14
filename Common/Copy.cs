using System;

namespace Common
{
    /// <summary>
    /// Class which represents copy of the book
    /// </summary>
    public class Copy
    {
        /// <summary>
        /// Copy id
        /// </summary>
        public string Id { get; }
        
        /// <summary>
        /// Id from Items table
        /// </summary>
        public string ItemId { get; }

        /// <summary>
        /// Field, which represents if copy is borrowed
        /// </summary>
        public bool IsBorrowed { get;  }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">Copy id</param>
        /// <param name="itemId">Id from Items table</param>
        /// <param name="isBorrowed">field, which represents if copy is borrowed</param>
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
