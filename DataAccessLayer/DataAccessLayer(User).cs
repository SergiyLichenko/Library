using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Data;
namespace DataAccessLayer
{
    public partial class DataAccessLayer
    {
        public List<User> GetAllUsers()
        {
            List<User> allUsers = new List<User>();

            DataRow[] users = _libraryDataSet.Users.Select();
            foreach(libraryDataSet.UsersRow user in users)
            {
                allUsers.Add(new User(user.ID, user.Name, user.UserName, user.Password, user.IsAdmin));
            }

            return allUsers;
        }
        public List<Borrowing> GetAllUserBorrowings()
        {
            List<Borrowing> borrows = new List<Borrowing>();

            foreach(libraryDataSet.BorrowsRow borrow in _libraryDataSet.Borrows)
            {
                Borrowing borStruct = new Borrowing();
                borStruct.UserID = borrow.UserID;
                borStruct.BorrowedDate = borrow.BorrowDate;

                Copy copy = new Copy(borrow.CopiesRow.ID, borrow.CopiesRow.ItemID, borrow.CopiesRow.IsBorrowed);
                borStruct.copy = copy;

                libraryDataSet.BooksRow[] bookRow = borrow.CopiesRow.ItemsRow.GetBooksRows();
                Book book = new Book(borrow.CopiesRow.ItemsRow.ID,borrow.CopiesRow.ItemsRow.Name, borrow.CopiesRow.ItemsRow.Publisher, borrow.CopiesRow.ItemsRow.PublishedDate,
                    bookRow[0].ISBN, bookRow[0].AuthorsRow.Name);
                borStruct.book = book;
                borrows.Add(borStruct);
            }
            
            return borrows;
        }

        public bool SaveNewBorrow(BorrowForSaveAndDelete borrowForSave)
        {
            try
            {
                libraryDataSet.CopiesRow copy = _libraryDataSet.Copies.FindByID(borrowForSave.CopyID);
                copy.IsBorrowed = true;
                libraryDataSet.UsersRow user = _libraryDataSet.Users.FindByID(borrowForSave.UserID);
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
                _libraryDataSet.Borrows.FindByCopiesID(borrowForSaveAndDelete.CopyID).Delete();
                _libraryDataSet.Copies.FindByID(borrowForSaveAndDelete.CopyID).IsBorrowed = false;
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
                if (userRow.Name==user.Name && userRow.Password.ToString() == user.Password.ToString() && userRow.IsAdmin == user.IsAdmin)
                    return false;
            }

            _libraryDataSet.Users.AddUsersRow(user.ID, user.Name, user.UserName, user.Password.ToString(), user.IsAdmin);
            _provider.UpdateAllData();
            return true;
        }
        public bool GetCurrentUser(string userName, string password, out User currentUser)
        {
            currentUser = null;
            foreach(libraryDataSet.UsersRow userRow in _libraryDataSet.Users)
            {
                if(userRow.UserName == userName && userRow.Password.ToLowerInvariant() == password.ToLowerInvariant())
                {
                    currentUser = new User(userRow.ID, userRow.Name, userRow.UserName, userRow.Password, userRow.IsAdmin);
                    return true;
                }

            }
            return false;
        }
    }
}
