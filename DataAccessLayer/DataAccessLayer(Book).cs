using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Common;

namespace DataAccessLayer
{
    public partial class DataAccessLayer
    {
        public List<Book> GetAllBooks()
        {
            var searchedRows = _libraryDataSet.Books.Select();
            return GetRestPartsOfBook(searchedRows.ToArray());            
        }

        private List<Book> GetRestPartsOfBook(DataRow[] searchedRows)
        {
            if (searchedRows == null || searchedRows.Length == 0)
                return null;

            var books = new List<Book>();
            foreach (var dataRow in searchedRows)
            {
                var bookRow = (libraryDataSet.BooksRow) dataRow;
                var book = new Book();
                book.ISBN = bookRow.ISBN;
                                
                if (bookRow.ItemsRow != null)
                {
                    book.Id = bookRow.ItemsRow.ID;
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
            foreach (var item in searchedAuthorsRows)
            {
                List<libraryDataSet.BooksRow> temp = searchedBooksRowsList.FindAll(val => val.AuthorID == item.ID);
                if (temp.Count != 0)
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
                var canAdd = IsUniqueBookinDb(b,out authorRow);
                if (!canAdd)
                {
                    DataRow[] items = _libraryDataSet.Items.Select($"Name = '{b.Name}' and Publisher = '{b.Publisher}'");
                    
                    foreach(var dataRow in items)
                    {
                        var item = (libraryDataSet.ItemsRow) dataRow;
                        if (item.GetBooksRows()[0].AuthorsRow.Name != b.Name) continue;

                        libraryDataSet.CopiesRow Copy = _libraryDataSet.Copies.AddCopiesRow(Guid.NewGuid().ToString(), item, false);
                        Copy.ItemID = item.ID;
                        _provider.UpdateAllData();
                    }
                    
                    
                    notAdded.Add(b);
                    continue;
                }
                
                libraryDataSet.ItemsRow itemRow = _libraryDataSet.Items.AddItemsRow(b.Id, b.Name, b.Publisher, b.PublishedDate);
                //если такого автора еще не было
                libraryDataSet.AuthorsRow author;
                if (authorRow == null)
                    author = _libraryDataSet.Authors.AddAuthorsRow(Guid.NewGuid().ToString(), b.AuthorName);
                else
                    author =(libraryDataSet.AuthorsRow) authorRow;
                var book=_libraryDataSet.Books.AddBooksRow(itemRow, author, b.ISBN);
                book.AuthorID = author.ID;
                book.AuthorsRow=author;
                if (book.AuthorsRow==null)
                    return new List<Book>(0);
                var copy = _libraryDataSet.Copies.AddCopiesRow(Guid.NewGuid().ToString(), itemRow, false);
                copy.ItemID = b.Id;
                _provider.UpdateAllData();
            }
            return notAdded;  
        }

        private bool IsUniqueBookinDb(Book b, out DataRow authorRow)
        {
            authorRow = null;
            _libraryDataSet = _provider.GetAllData(_dataType, _targetFile);
            foreach (libraryDataSet.BooksRow bookRow in _libraryDataSet.Books)
                if (bookRow.ItemsRow.Name == b.Name && bookRow.AuthorsRow.Name==b.AuthorName &&
                    bookRow.ItemsRow.Publisher == b.Publisher)
                    return false;

            _provider.FillAuthors();
            foreach (var author in _libraryDataSet.Authors)
                if (author.Name == b.AuthorName)
                    authorRow = author;
            
            return true;
        }

        public bool UpdateBook(Book book)
        {
            DataRow author;
            bool canUpdate = IsUniqueBookinDb(book,out author);
            if (!canUpdate)
                return false;

            try
            {
                var bookRow = _libraryDataSet.Books.FindByItemID(book.Id);
                var authorId = bookRow.AuthorsRow.ID;
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
                _provider.DeleteAuthor(authorId);
                return true;
            }
            catch (Exception)
            {
                // ignored
            }
            return false;
        }
        private List<Copy> GetRestPartsOfCopies(DataRow[] copies)
        {
            if (copies == null || copies.Length == 0)
                return new List<Copy>(0);
            List<Copy> allCopies = new List<Copy>();
            foreach(var dataRow in copies)
            {
                var copy = (libraryDataSet.CopiesRow) dataRow;
                var tempCopy = new Copy(copy.ID, copy.ItemID, copy.IsBorrowed);
                allCopies.Add(tempCopy);
            }
            return allCopies;
        }
        public List<Copy> GetAllCopiesBooks(string searchedId)
        {
            try
            {
                if (string.IsNullOrEmpty(searchedId))
                    return new List<Copy>(0);
                foreach (var item in _libraryDataSet.Items)
                {
                    if (item.ID != searchedId) continue;
                    var copies = item.GetChildRows("To_Items");
                    return GetRestPartsOfCopies(copies);
                }
                return new List<Copy>(0);
            }
            catch (Exception)
            {
                // ignored
            }
            return null;           
        }

        public bool WriteToXml(string fileName)
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
