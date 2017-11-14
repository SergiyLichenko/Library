namespace Common
{
    public struct Borrowing
    {
        public string BorrowedDate { get; set; }
        public string UserId { get; set; }
        public Copy Copy { get; set; }
        public Book Book { get; set; }
    }
}
