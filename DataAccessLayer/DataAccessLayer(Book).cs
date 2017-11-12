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
            DataRow[] searchedRows = this._libraryDataSet.Books.Select();
            return GetRestPartsOfBook(searchedRows);            
        }
        private List<Book> GetRestPartsOfBook(DataRowCollection searchedRows)
        {
            if (searchedRows == null || searchedRows.Count == 0)
                return null;
            List<Book> books = new List<Book>();
            foreach (libraryDataSet.BooksRow bookRow in searchedRows)
            {
                Book book = new Book();
                book.ISBN = bookRow.ISBN;

                if (bookRow.ItemsRow != null)
                {
                    book.ID = bookRow.ItemsRow.ID;
                    book.Name = bookRow.ItemsRow.Name;
                    book.Publisher = bookRow.ItemsRow.Publisher;
                    book.PublishedDate = bookRow.ItemsRow.PublishedDate;
                }
                else
                    throw new Exception("Cannot find corresponding Item");

                if (bookRow.AuthorsRow != null)
                    book.AuthorName = bookRow.AuthorsRow.Name;
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
            foreach (libraryDataSet.BooksRow bookRow in searchedRows)
            {
                Book book = new Book();
                book.ISBN = bookRow.ISBN;
                                
                if (bookRow.ItemsRow != null)
                {
                    book.ID = bookRow.ItemsRow.ID;
                    book.Name = bookRow.ItemsRow.Name;
                    book.Publisher = bookRow.ItemsRow.Publisher;
                    book.PublishedDate = bookRow.ItemsRow.PublishedDate;
                }
                else
                    throw new Exception("Cannot find corresponding Item");

                if (bookRow.AuthorsRow != null)
                    book.AuthorName = bookRow.AuthorsRow.Name;
                else
                    throw new Exception("Cannot find corresponding Item");
                books.Add(book);
            }
            return books;
        }
       

        public List<Book> SearchedBooks(Book searchedBook)//можна було б починати з авторів, і за допомогою зовнішнього ключа переходити до таблиці Items(пошук по типізованих рядках)
        {
            //получаем набор найденных строк в таблице Items
            libraryDataSet.ItemsRow[] searchedItemsRows = (libraryDataSet.ItemsRow[])_libraryDataSet.Items.Select(MakeFilteredQuery(searchedBook.ItemFields));
            //получаем набор найденных строк из таблицы Authors
            libraryDataSet.AuthorsRow[] searchedAuthorsRows = (libraryDataSet.AuthorsRow[])_libraryDataSet.Authors.Select(MakeFilteredQuery(searchedBook.AuthorFields));

            //искать строки в таблице Books не стоит, поскольку поиск по полю ISBN не производится, а это поле заходится именно в таблицее Books
            if (searchedItemsRows.Length == 0 || searchedItemsRows == null || searchedAuthorsRows.Length == 0 || searchedAuthorsRows == null)
                return new List<Book>(0);

            //создаем списки для набора строк Items и Books для более гибкого манипулирования эллементами массива
            List<libraryDataSet.ItemsRow> searchedItemsRowsList = searchedItemsRows.ToList<libraryDataSet.ItemsRow>();
            List<libraryDataSet.BooksRow> searchedBooksRowsList = new List<libraryDataSet.BooksRow>();

            //заполняем список книг searchedBooksRowsList, для каждой записи в таблице Items существует всего одна запись в таблице Books
            foreach (libraryDataSet.ItemsRow itemRow in searchedItemsRowsList)
            {
                libraryDataSet.BooksRow[] bookRows = itemRow.GetBooksRows();
                if (bookRows != null && bookRows.Length != 0)
                    searchedBooksRowsList.Add(bookRows[0]);
            }
            //конечный набор искомых строк
            List<libraryDataSet.BooksRow> final = new List<libraryDataSet.BooksRow>();
            
            //выбираем те книги, которые написаны данным автором
            for (int i = 0; i < searchedAuthorsRows.Length; i++)
            {
                List<libraryDataSet.BooksRow> temp = searchedBooksRowsList.FindAll(val => val.AuthorID == searchedAuthorsRows[i].ID);
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
                    DataRow[] items = _libraryDataSet.Items.Select(String.Format("Name = '{0}' and Publisher = '{1}'",b.Name,b.Publisher));
                    
                    foreach(libraryDataSet.ItemsRow item in items)
                    {
                        if(item.GetBooksRows()[0].AuthorsRow.Name == b.Name)
                        {
                            libraryDataSet.CopiesRow Copy = _libraryDataSet.Copies.AddCopiesRow(Guid.NewGuid().ToString(), item, false);
                            Copy.ItemID = item.ID;
                            _provider.UpdateAllData();
                        }
                    }
                    
                    
                    notAdded.Add(b);
                    continue;
                }
                
                libraryDataSet.ItemsRow itemRow = _libraryDataSet.Items.AddItemsRow(b.ID, b.Name, b.Publisher, b.PublishedDate);
                //если такого автора еще не было
                libraryDataSet.AuthorsRow author;
                if (authorRow == null)
                    author = _libraryDataSet.Authors.AddAuthorsRow(Guid.NewGuid().ToString(), b.AuthorName);
                else
                    author =(libraryDataSet.AuthorsRow) authorRow;
                libraryDataSet.BooksRow book=_libraryDataSet.Books.AddBooksRow(itemRow, author, b.ISBN);
                book.AuthorID = author.ID;
                book.AuthorsRow=author;
                if (book.AuthorsRow==null)
                    return new List<Book>(0);
                libraryDataSet.CopiesRow copy = _libraryDataSet.Copies.AddCopiesRow(Guid.NewGuid().ToString(), itemRow, false);
                copy.ItemID = b.ID;
                _provider.UpdateAllData();
            }
            return notAdded;  
        }

        private bool IsUniqueBookinDB(Book b, out DataRow authorRow)
        {
            authorRow = null;
            _libraryDataSet = _provider.GetAllData(_dataType, _targetFile);
            foreach (libraryDataSet.BooksRow bookRow in _libraryDataSet.Books)
            {
                if (bookRow.ItemsRow.Name == b.Name && bookRow.AuthorsRow.Name==b.AuthorName &&
                    bookRow.ItemsRow.Publisher == b.Publisher)
                    return false;                
            }
            _provider.FillAuthors();
            foreach (libraryDataSet.AuthorsRow author in _libraryDataSet.Authors)
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
                libraryDataSet.BooksRow bookRow = _libraryDataSet.Books.FindByItemID(book.ID);
                authorID = bookRow.AuthorsRow.ID;
                bookRow.ItemsRow.Name = book.Name;
                bookRow.ItemsRow.Publisher = book.Publisher;
                bookRow.ItemsRow.PublishedDate = book.PublishedDate;
                
                if (author == null)
                {
                    libraryDataSet.AuthorsRow authorRow = _libraryDataSet.Authors.AddAuthorsRow(Guid.NewGuid().ToString(), book.AuthorName);
                    bookRow.AuthorsRow = authorRow;                    
                }
                else                
                    bookRow.AuthorsRow = (libraryDataSet.AuthorsRow)author;
                
                _provider.UpdateAllData();
                _provider.DeleteAuthor(authorID);
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
            foreach(libraryDataSet.CopiesRow copy in copies)
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
                foreach (libraryDataSet.ItemsRow item in _libraryDataSet.Items)
                {
                    if (item.ID == searchedID)
                    {
                        DataRow[] copies = item.GetChildRows("To_Items");
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
                _libraryDataSet.WriteXml(fileName+".xml");
                _libraryDataSet.WriteXmlSchema(fileName+".xsd");
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
