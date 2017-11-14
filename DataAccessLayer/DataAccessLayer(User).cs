using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace DataAccessLayer
{
    public partial class DataAccessLayer
    {
        public List<User> GetAllUsers()
        {
            var users = _libraryDataSet.Users.Select();

            return (from libraryDataSet.UsersRow user 
                    in users
                    select new User(user.ID, 
                                    user.Name,
                                    user.UserName, 
                                    user.Password, 
                                    user.IsAdmin))
                    .ToList();
        }

        public List<Borrowing> GetAllUserBorrowings()
        {
            var borrows = new List<Borrowing>();

            foreach(var borrow in _libraryDataSet.Borrows)
            {
                var borStruct = new Borrowing
                {
                    UserId = borrow.UserID,
                    BorrowedDate = borrow.BorrowDate
                };

                var copy = new Copy(borrow.CopiesRow.ID, borrow.CopiesRow.ItemID, borrow.CopiesRow.IsBorrowed);
                borStruct.Copy = copy;

                var bookRow = borrow.CopiesRow.ItemsRow.GetBooksRows();
                var book = new Book(borrow.CopiesRow.ItemsRow.ID,borrow.CopiesRow.ItemsRow.Name, borrow.CopiesRow.ItemsRow.Publisher, borrow.CopiesRow.ItemsRow.PublishedDate,
                    bookRow[0].ISBN, bookRow[0].AuthorsRow.Name);
                borStruct.Book = book;
                borrows.Add(borStruct);
            }
            
            return borrows;
        }

        public bool SaveNewBorrow(BorrowForSaveAndDelete borrowForSave)
        {
            try
            {
                var copy = _libraryDataSet.Copies.FindByID(borrowForSave.CopyId);
                copy.IsBorrowed = true;
                var user = _libraryDataSet.Users.FindByID(borrowForSave.UserId);
                _libraryDataSet.Borrows.AddBorrowsRow(copy, DateTime.Now.ToString(), user);
                _provider.UpdateAllData();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteUserCopy(BorrowForSaveAndDelete borrowForSaveAndDelete)
        {
            try
            {
                _libraryDataSet.Borrows.FindByCopiesID(borrowForSaveAndDelete.CopyId).Delete();
                _libraryDataSet.Copies.FindByID(borrowForSaveAndDelete.CopyId).IsBorrowed = false;
                _provider.UpdateAllData();
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        public bool AddNewUser(User user)
        {
            foreach(libraryDataSet.UsersRow userRow in _libraryDataSet.Users)
            {
                if (userRow.Name==user.Name && userRow.Password == user.Password && userRow.IsAdmin == user.IsAdmin)
                    return false;
            }

            _libraryDataSet.Users.AddUsersRow(user.Id, user.Name, user.UserName, user.Password, user.IsAdmin);
            _provider.UpdateAllData();
            return true;
        }
        public bool GetCurrentUser(string userName, string password, out User currentUser)
        {
            currentUser = null;
            foreach(libraryDataSet.UsersRow userRow in _libraryDataSet.Users)
            {
                if (userRow.UserName != userName || userRow.Password.ToLowerInvariant() !=
                    password.ToLowerInvariant()) continue;

                currentUser = new User(userRow.ID, userRow.Name, userRow.UserName, userRow.Password, userRow.IsAdmin);
                return true;
            }
            return false;
        }
    }
}
