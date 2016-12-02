using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Common;

namespace DataAccessLayer
{
    public partial class DataAccessLayer
    {
        public List<Book> GetAllBooks()
        {
            DataRow[] searchedRows = this.LibraryDataSet.books.Select();
            return GetRestPartsOfBook(searchedRows);            
        }
        private List<Book> GetRestPartsOfBook(DataRowCollection searchedRows)
        {
            if (searchedRows == null || searchedRows.Count == 0)
                return null;
            List<Book> books = new List<Book>();
            foreach (libraryDataSet.booksRow bookRow in searchedRows)
            {
                Book book = new Book();
                book.ISBN = bookRow.ISBN;

                if (bookRow.itemsRow != null)
                {
                    book.ID = bookRow.itemsRow.ID;
                    book.Name = bookRow.itemsRow.Name;
                    book.Publisher = bookRow.itemsRow.Publisher;
                    book.PublishedDate = bookRow.itemsRow.PublishedDate;
                }
                else
                    throw new Exception("Cannot find corresponding Item");

                if (bookRow.authorsRow != null)
                    book.AuthorName = bookRow.authorsRow.Name;
                else
                    throw new Exception("Cannot find corresponding Item");
                books.Add(book);
            }
            return books;
        }
        
        private List<Book> GetRestPartsOfBook(DataRow[] searchedRows)
        {
            if (searchedRows == null || searchedRows.Length == 0)
                return null;

            List<Book> books = new List<Book>();
            foreach (libraryDataSet.booksRow bookRow in searchedRows)
            {
                Book book = new Book();
                book.ISBN = bookRow.ISBN;
                                
                if (bookRow.itemsRow != null)
                {
                    book.ID = bookRow.itemsRow.ID;
                    book.Name = bookRow.itemsRow.Name;
                    book.Publisher = bookRow.itemsRow.Publisher;
                    book.PublishedDate = bookRow.itemsRow.PublishedDate;
                }
                else
                    throw new Exception("Cannot find corresponding Item");

                if (bookRow.authorsRow != null)
                    book.AuthorName = bookRow.authorsRow.Name;
                else
                    throw new Exception("Cannot find corresponding Item");
                books.Add(book);
            }
            return books;
        }
       

        public List<Book> SearchedBooks(Book searchedBook)//можна було б починати з авторів, і за допомогою зовнішнього ключа переходити до таблиці Items(пошук по типізованих рядках)
        {
            //получаем набор найденных строк в таблице Items
            libraryDataSet.itemsRow[] searchedItemsRows = (libraryDataSet.itemsRow[])LibraryDataSet.items.Select(MakeFilteredQuery(searchedBook.ItemFields));
            //получаем набор найденных строк из таблицы Authors
            libraryDataSet.authorsRow[] searchedAuthorsRows = (libraryDataSet.authorsRow[])LibraryDataSet.authors.Select(MakeFilteredQuery(searchedBook.AuthorFields));

            //искать строки в таблице Books не стоит, поскольку поиск по полю ISBN не производится, а это поле заходится именно в таблицее Books
            if (searchedItemsRows.Length == 0 || searchedItemsRows == null || searchedAuthorsRows.Length == 0 || searchedAuthorsRows == null)
                return new List<Book>(0);

            //создаем списки для набора строк Items и Books для более гибкого манипулирования эллементами массива
            List<libraryDataSet.itemsRow> searchedItemsRowsList = searchedItemsRows.ToList<libraryDataSet.itemsRow>();
            List<libraryDataSet.booksRow> searchedBooksRowsList = new List<libraryDataSet.booksRow>();

            //заполняем список книг searchedBooksRowsList, для каждой записи в таблице Items существует всего одна запись в таблице Books
            foreach (libraryDataSet.itemsRow itemRow in searchedItemsRowsList)
            {
                libraryDataSet.booksRow[] bookRows = itemRow.GetbooksRows();
                if (bookRows != null && bookRows.Length != 0)
                    searchedBooksRowsList.Add(bookRows[0]);
            }
            //конечный набор искомых строк
            List<libraryDataSet.booksRow> final = new List<libraryDataSet.booksRow>();
            
            //выбираем те книги, которые написаны данным автором
            for (int i = 0; i < searchedAuthorsRows.Length; i++)
            {
                List<libraryDataSet.booksRow> temp = searchedBooksRowsList.FindAll(val => val.AuthorID == searchedAuthorsRows[i].ID);
                if (temp != null && temp.Count != 0)
                    final.AddRange(temp);
            }
            if (final.Count == 0)
                return new List<Book>(0);
            return GetRestPartsOfBook(final.ToArray());
        }



        public List<Book> AddBook(List<Book> books)
        {
            List<Book> notAdded = new List<Book>();
            foreach (Book b in books)
            {
                DataRow authorRow=null;
                bool canAdd = IsUniqueBookinDB(b,out authorRow);
                if (!canAdd)
                {
                    DataRow[] items = LibraryDataSet.items.Select(String.Format("Name = '{0}' and Publisher = '{1}'",b.Name,b.Publisher));
                    
                    foreach(libraryDataSet.itemsRow item in items)
                    {
                        if(item.GetbooksRows()[0].authorsRow.Name == b.Name)
                        {
                            libraryDataSet.copiesRow Copy = LibraryDataSet.copies.AddcopiesRow(Guid.NewGuid().ToString(), item, false);
                            Copy.ItemID = item.ID;
                            provider.UpdateAllData();
                        }
                    }
                    
                    
                    notAdded.Add(b);
                    continue;
                }
                
                libraryDataSet.itemsRow itemRow = LibraryDataSet.items.AdditemsRow(b.ID, b.Name, b.Publisher, b.PublishedDate);
                //если такого автора еще не было
                libraryDataSet.authorsRow author;
                if (authorRow == null)
                    author = LibraryDataSet.authors.AddauthorsRow(Guid.NewGuid().ToString(), b.AuthorName);
                else
                    author =(libraryDataSet.authorsRow) authorRow;
                libraryDataSet.booksRow book=LibraryDataSet.books.AddbooksRow(itemRow,b.ISBN,author);
                book.AuthorID = author.ID;
                book.authorsRow=author;
                if (book.authorsRow==null)
                    return new List<Book>(0);
                libraryDataSet.copiesRow copy = LibraryDataSet.copies.AddcopiesRow(Guid.NewGuid().ToString(), itemRow, false);
                copy.ItemID = b.ID;
                provider.UpdateAllData();
            }
            return notAdded;  
        }

        private bool IsUniqueBookinDB(Book b, out DataRow authorRow)
        {
            authorRow = null;
            LibraryDataSet = provider.GetAllData(dataType, targetFile);
            foreach (libraryDataSet.booksRow bookRow in LibraryDataSet.books)
            {
                if (bookRow.itemsRow.Name == b.Name && bookRow.authorsRow.Name==b.AuthorName &&
                    bookRow.itemsRow.Publisher == b.Publisher)
                    return false;                
            }
            provider.FillAuthors();
            foreach (libraryDataSet.authorsRow author in LibraryDataSet.authors)
            {
                if (author.Name == b.AuthorName)
                    authorRow = author;
            }
            return true;
        }

        public bool UpdateBook(Book book)
        {
            DataRow author=null;
            bool canUpdate = IsUniqueBookinDB(book,out author);
            if (!canUpdate)
                return false;
            
            string authorID=String.Empty;
            try
            {
                libraryDataSet.booksRow bookRow = LibraryDataSet.books.FindByItemID(book.ID);
                authorID = bookRow.authorsRow.ID;
                bookRow.itemsRow.Name = book.Name;
                bookRow.itemsRow.Publisher = book.Publisher;
                bookRow.itemsRow.PublishedDate = book.PublishedDate;
                
                if (author == null)
                {
                    libraryDataSet.authorsRow authorRow = LibraryDataSet.authors.AddauthorsRow(Guid.NewGuid().ToString(), book.AuthorName);
                    bookRow.authorsRow = authorRow;                    
                }
                else                
                    bookRow.authorsRow = (libraryDataSet.authorsRow)author;
                
                provider.UpdateAllData();
                provider.DeleteAuthor(authorID);
                return true;
            }
            catch(Exception)
            {
            }
            return false;
        }
        private List<Copy> GetRestPartsOfCopies(DataRow[] copies)
        {
            if (copies == null || copies.Length == 0)
                return new List<Copy>(0);
            List<Copy> allCopies = new List<Copy>();
            foreach(libraryDataSet.copiesRow copy in copies)
            {
                Copy tempCopy = new Copy(copy.ID, copy.ItemID, copy.IsBorrowed);
                if (tempCopy != null)
                    allCopies.Add(tempCopy);
            }
            return allCopies;
        }
        public List<Copy> GetAllCopiesBooks(string searchedID)
        {
            try
            {
                if (searchedID == null || searchedID == String.Empty)
                    return new List<Copy>(0);
                foreach (libraryDataSet.itemsRow item in LibraryDataSet.items)
                {
                    if (item.ID == searchedID)
                    {
                        DataRow[] copies = item.GetChildRows("Copies-Items");
                        return GetRestPartsOfCopies(copies);
                    }
                }
                return new List<Copy>(0);
            }
            catch (Exception)
            {
                
            }
            return null;           
        }

        public bool BorrowingBook(string copyID)
        {

            return true;
        }

        public bool WriteToXML(string fileName)
        {
            try
            {
                LibraryDataSet.WriteXml(fileName+".xml");
                LibraryDataSet.WriteXmlSchema(fileName+".xsd");
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
