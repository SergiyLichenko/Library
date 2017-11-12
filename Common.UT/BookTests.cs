using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Common.UT
{
    public class BookTests
    {
        [Fact]
        public void Book_Constructor_should_create_via_default_constructor()
        {
            //Act
            Action constructor = () => new Book();

            //Assert
            constructor.ShouldNotThrow();
        }

        [Theory]
        [MemberData(nameof(InvalidConstructorArguments))]
        public void Book_Constructor_should_not_create_with_invalid_argument(
            string id, string name, string publisher, string publishedDate,
            string isbn, string authorName)
        {
            //Act
            Action constructor = () => new Book(id, name, publisher, publishedDate, isbn, authorName);

            //Assert
            constructor.ShouldThrow<ArgumentException>();
        }

        [Theory]
        [MemberData(nameof(ValidConstructorArguments))]
        public void Book_Constructor_should_create_with_valid_arguments(
            string id, string name, string publisher, string publishedDate,
            string isbn, string authorName)
        {
            //Act
            Action constructor = () => new Book(id, name, publisher, publishedDate, isbn, authorName);

            //Assert
            constructor.ShouldNotThrow();
        }


        [Theory]
        [MemberData(nameof(ValidConstructorArguments))]
        public void Book_Constructor_should_set_correct_items_fields(
            string id, string name, string publisher, string publishedDate,
            string isbn, string authorName)
        {
            //Act
            var book = new Book(id, name, publisher, publishedDate, isbn, authorName);

            //Assert
            book.ItemFields.Count.ShouldBeEquivalentTo(3);

            book.ItemFields.First().Key.ShouldBeEquivalentTo("Name");
            book.ItemFields.First().Value.ShouldBeEquivalentTo(name);
         
            book.ItemFields.ElementAt(1).Key.ShouldBeEquivalentTo("Publisher");
            book.ItemFields.ElementAt(1).Value.ShouldBeEquivalentTo(publisher);

            book.ItemFields.ElementAt(2).Key.ShouldBeEquivalentTo("PublishedDate");
            book.ItemFields.ElementAt(2).Value.ShouldBeEquivalentTo(publishedDate);
        }

        [Theory]
        [MemberData(nameof(ValidConstructorArguments))]
        public void Book_Constructor_should_set_correct_author_fields(
            string id, string name, string publisher, string publishedDate,
            string isbn, string authorName)
        {
            //Act
            var book = new Book(id, name, publisher, publishedDate, isbn, authorName);

            //Assert
            book.AuthorFields.Count.ShouldBeEquivalentTo(1);

            book.AuthorFields.First().Key.ShouldBeEquivalentTo("Name");
            book.AuthorFields.First().Value.ShouldBeEquivalentTo(authorName);
        }

        [Theory]
        [MemberData(nameof(ValidConstructorArguments))]
        public void Book_Constructor_should_set_correct_book_fields(
            string id, string name, string publisher, string publishedDate,
            string isbn, string authorName)
        {
            //Act
            var book = new Book(id, name, publisher, publishedDate, isbn, authorName);

            //Assert
            book.BookFields.Count.ShouldBeEquivalentTo(1);

            book.BookFields.First().Key.ShouldBeEquivalentTo("ISBN");
            book.BookFields.First().Value.ShouldBeEquivalentTo(isbn);
        }

        public static IEnumerable<object[]> InvalidConstructorArguments => new[]
        {
            new object[] { string.Empty, "name", "publisher", "publishedDate", "isbn", "authorName"},
            new object[] {"   ", "name", "publisher", "publishedDate", "isbn", "authorName"},
            new object[] {null, "name", "publisher", "publishedDate", "isbn", "authorName"},
            new object[] {"id", string.Empty, "publisher", "publishedDate", "isbn", "authorName"},
            new object[] {"id", "   ", "publisher", "publishedDate", "isbn", "authorName"},
            new object[] {"id", null, "publisher", "publishedDate", "isbn", "authorName"},
            new object[] {"id", "name", string.Empty, "publishedDate", "isbn", "authorName"},
            new object[] {"id", "name", "   ", "publishedDate", "isbn", "authorName"},
            new object[] {"id", "name", null, "publishedDate", "isbn", "authorName"},
            new object[] {"id", "name", "publisher", string.Empty, "isbn", "authorName"},
            new object[] {"id", "name", "publisher", "   ", "isbn", "authorName"},
            new object[] {"id", "name", "publisher", null, "isbn", "authorName"},
            new object[] {"id", "name", "publisher", "publishedDate", string.Empty, "authorName"},
            new object[] {"id", "name", "publisher", "publishedDate", "   ", "authorName"},
            new object[] {"id", "name", "publisher", "publishedDate", null, "authorName"},
            new object[] {"id", "name", "publisher", "publishedDate", "isbn", string.Empty},
            new object[] {"id", "name", "publisher", "publishedDate", "isbn", "   "},
            new object[] {"id", "name", "publisher", "publishedDate", "isbn", null},
        };

        public static IEnumerable<object[]> ValidConstructorArguments => new[]
        {
            new object[] {"id", "name", "publisher", "publishedDate", "isbn", "authorName"},
        };
    }
}
