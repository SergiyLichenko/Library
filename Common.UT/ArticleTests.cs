using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Common.UT
{
    public class ArticleTests
    {
        [Fact]
        public void Article_Constructor_should_create_via_default_constructor()
        {
            //Act
            Action constructor = () => new Article();

            //Assert
            constructor.ShouldNotThrow();
        }

        [Theory]
        [MemberData(nameof(InvalidConstructorArguments))]
        public void Article_Constructor_should_not_create_with_invalid_argument(
            string id, string name,
            string publisher, string publishedDate,
            string magazineName, string magazineIssueNumber,
            string author, string version)
        {
            //Act
            Action constructor = () => new Article(id, name, publisher, publishedDate,
                magazineName, magazineIssueNumber, author, version);

            //Assert
            constructor.ShouldThrow<ArgumentException>();
        }

        [Theory]
        [MemberData(nameof(ValidConstructorArguments))]
        public void Article_Constructor_should_create_with_valid_arguments(
            string id, string name,
            string publisher, string publishedDate,
            string magazineName, string magazineIssueNumber,
            string author, string version)
        {
            //Act
            Action constructor = () => new Article(id, name, publisher, publishedDate,
                magazineName, magazineIssueNumber, author, version);

            //Assert
            constructor.ShouldNotThrow();
        }

        [Theory]
        [MemberData(nameof(ValidConstructorArguments))]
        public void Article_Constructor_should_set_correct_items_fields(
            string id, string name,
            string publisher, string publishedDate,
            string magazineName, string magazineIssueNumber,
            string author, string version)
        {
            //Act
            var article = new Article(id, name, publisher, publishedDate,
                magazineName, magazineIssueNumber, author, version);

            //Assert
            article.ItemFields.Count.ShouldBeEquivalentTo(3);

            article.ItemFields.First().Key.ShouldBeEquivalentTo("Name");
            article.ItemFields.First().Value.ShouldBeEquivalentTo(name);

            article.ItemFields.ElementAt(1).Key.ShouldBeEquivalentTo("Publisher");
            article.ItemFields.ElementAt(1).Value.ShouldBeEquivalentTo(publisher);

            article.ItemFields.ElementAt(2).Key.ShouldBeEquivalentTo("PublishedDate");
            article.ItemFields.ElementAt(2).Value.ShouldBeEquivalentTo(publishedDate);
        }

        [Theory]
        [MemberData(nameof(ValidConstructorArguments))]
        public void Article_Constructor_should_set_correct_author_fields(
            string id, string name,
            string publisher, string publishedDate,
            string magazineName, string magazineIssueNumber,
            string author, string version)
        {
            //Act
            var article = new Article(id, name, publisher, publishedDate,
                magazineName, magazineIssueNumber, author, version);

            //Assert
            article.AuthorFields.Count.ShouldBeEquivalentTo(1);

            article.AuthorFields.First().Key.ShouldBeEquivalentTo("Name");
            article.AuthorFields.First().Value.ShouldBeEquivalentTo(author);
        }

        [Theory]
        [MemberData(nameof(ValidConstructorArguments))]
        public void Article_Constructor_should_set_correct_article_fields(
            string id, string name,
            string publisher, string publishedDate,
            string magazineName, string magazineIssueNumber,
            string author, string version)
        {
            //Act
            var article = new Article(id, name, publisher, publishedDate,
                magazineName, magazineIssueNumber, author, version);

            //Assert
            article.ArticleFields.Count.ShouldBeEquivalentTo(1);

            article.ArticleFields.First().Key.ShouldBeEquivalentTo("Version");
            article.ArticleFields.First().Value.ShouldBeEquivalentTo(version);
        }

        [Theory]
        [MemberData(nameof(ValidConstructorArguments))]
        public void Article_Constructor_should_set_correct_magazine_fields(
            string id, string name,
            string publisher, string publishedDate,
            string magazineName, string magazineIssueNumber,
            string author, string version)
        {
            //Act
            var article = new Article(id, name, publisher, publishedDate,
                magazineName, magazineIssueNumber, author, version);

            //Assert
            article.MagazineFields.Count.ShouldBeEquivalentTo(2);

            article.MagazineFields.First().Key.ShouldBeEquivalentTo("Name");
            article.MagazineFields.First().Value.ShouldBeEquivalentTo(magazineName);
            article.MagazineFields.Last().Key.ShouldBeEquivalentTo("IssueNumber");
            article.MagazineFields.Last().Value.ShouldBeEquivalentTo(magazineIssueNumber);
        }

        public static IEnumerable<object[]> InvalidConstructorArguments => new[]
        {
            new object[] { string.Empty, "name", "publisher", "publishedDate", "magazineName", "magazineIssueNumber", "author", "version"},
            new object[] { "   ", "name", "publisher", "publishedDate", "magazineName", "magazineIssueNumber", "author", "version"},
            new object[] { null, "name", "publisher", "publishedDate", "magazineName", "magazineIssueNumber", "author", "version"},
            new object[] { "id", string.Empty, "publisher", "publishedDate", "magazineName", "magazineIssueNumber", "author", "version"},
            new object[] { "id", "   ", "publisher", "publishedDate", "magazineName", "magazineIssueNumber", "author", "version"},
            new object[] { "id", null, "publisher", "publishedDate", "magazineName", "magazineIssueNumber", "author", "version"},
            new object[] { "id", "name", string.Empty, "publishedDate", "magazineName", "magazineIssueNumber", "author", "version"},
            new object[] { "id", "name", "    ", "publishedDate", "magazineName", "magazineIssueNumber", "author", "version"},
            new object[] { "id", "name", null, "publishedDate", "magazineName", "magazineIssueNumber", "author", "version"},
            new object[] { "id", "name", "publisher", string.Empty, "magazineName", "magazineIssueNumber", "author", "version"},
            new object[] { "id", "name", "publisher", "   ", "magazineName", "magazineIssueNumber", "author", "version"},
            new object[] { "id", "name", "publisher", null, "magazineName", "magazineIssueNumber", "author", "version"},
            new object[] { "id", "name", "publisher", "publishedDate", string.Empty, "magazineIssueNumber", "author", "version"},
            new object[] { "id", "name", "publisher", "publishedDate", "   ", "magazineIssueNumber", "author", "version"},
            new object[] { "id", "name", "publisher", "publishedDate", null, "magazineIssueNumber", "author", "version"},
            new object[] { "id", "name", "publisher", "publishedDate", "magazineName", string.Empty, "author", "version"},
            new object[] { "id", "name", "publisher", "publishedDate", "magazineName", "   ", "author", "version"},
            new object[] { "id", "name", "publisher", "publishedDate", "magazineName", null, "author", "version"},
            new object[] { "id", "name", "publisher", "publishedDate", "magazineName", "magazineIssueNumber", string.Empty, "version"},
            new object[] { "id", "name", "publisher", "publishedDate", "magazineName", "magazineIssueNumber", "   ", "version"},
            new object[] { "id", "name", "publisher", "publishedDate", "magazineName", "magazineIssueNumber", null, "version"},
            new object[] { "id", "name", "publisher", "publishedDate", "magazineName", "magazineIssueNumber", "author", string.Empty},
            new object[] { "id", "name", "publisher", "publishedDate", "magazineName", "magazineIssueNumber", "author", "   "},
            new object[] { "id", "name", "publisher", "publishedDate", "magazineName", "magazineIssueNumber", "author", null}
        };

        public static IEnumerable<object[]> ValidConstructorArguments => new[]
        {
            new object[] { "id", "name", "publisher", "publishedDate", "magazineName", "magazineIssueNumber", "author", "version"}
        };
    }
}