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

            DataRow[] users = LibraryDataSet.users.Select();
            foreach(libraryDataSet.usersRow user in users)
            {
                allUsers.Add(new User(user.ID, user.Name, user.UserName, user.Password, user.IsAdmin));
            }

            return allUsers;
        }
        public List<Borrowing> GetAllUserBorrowings()
        {
            List<Borrowing> borrows = new List<Borrowing>();

            foreach(libraryDataSet.borrowsRow borrow in LibraryDataSet.borrows)
            {
                Borrowing borStruct = new Borrowing();
                borStruct.UserID = borrow.UserID;
                borStruct.BorrowedDate = borrow.BorrowedDate;

                Copy copy = new Copy(borrow.copiesRow.ID, borrow.copiesRow.ItemID, borrow.copiesRow.IsBorrowed);
                borStruct.copy = copy;

                libraryDataSet.booksRow[] bookRow = borrow.copiesRow.itemsRow.GetbooksRows();
                Book book = new Book(borrow.copiesRow.itemsRow.ID,borrow.copiesRow.itemsRow.Name, borrow.copiesRow.itemsRow.Publisher, borrow.copiesRow.itemsRow.PublishedDate,
                    bookRow[0].ISBN, bookRow[0].authorsRow.Name);
                borStruct.book = book;
                borrows.Add(borStruct);
            }
            
            return borrows;
        }

        public bool SaveNewBorrow(BorrowForSaveAndDelete borrowForSave)
        {
            try
            {
                libraryDataSet.copiesRow copy = LibraryDataSet.copies.FindByID(borrowForSave.CopyID);
                copy.IsBorrowed = true;
                libraryDataSet.usersRow user = LibraryDataSet.users.FindByID(borrowForSave.UserID);
                LibraryDataSet.borrows.AddborrowsRow(copy, DateTime.Now.ToString(), user);
                provider.UpdateAllData();
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
                LibraryDataSet.borrows.FindByCopyID(borrowForSaveAndDelete.CopyID).Delete();
                LibraryDataSet.copies.FindByID(borrowForSaveAndDelete.CopyID).IsBorrowed = false;
                provider.UpdateAllData();
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        public bool AddNewUser(User user)
        {
            foreach(libraryDataSet.usersRow userRow in LibraryDataSet.users)
            {
                if (userRow.Name==user.Name && userRow.Password.ToString() == user.Password.ToString() && userRow.IsAdmin == user.IsAdmin)
                    return false;
            }

            LibraryDataSet.users.AddusersRow(user.ID, user.Name, user.UserName, user.Password.ToString(), user.IsAdmin);
            provider.UpdateAllData();
            return true;
        }
        public bool GetCurrentUser(string userName, string password, out User currentUser)
        {
            currentUser = null;
            foreach(libraryDataSet.usersRow userRow in LibraryDataSet.users)
            {
                if(userRow.UserName == userName && userRow.Password == password)
                {
                    currentUser = new User(userRow.ID, userRow.Name, userRow.UserName, userRow.Password, userRow.IsAdmin);
                    return true;
                }

            }
            return false;
        }
    }
}
