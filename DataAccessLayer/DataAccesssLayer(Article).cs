using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Common;
namespace DataAccessLayer
{
    public partial class DataAccessLayer
    {
        public List<Article> GetAllArticles()
        {
            DataRow[] searchedArticles = _libraryDataSet.Articles.Select();
            return GetRestPartsOfArticles(searchedArticles);
        }

        private List<Article> GetRestPartsOfArticles(DataRow[] searchedArticles)
        {
            if (searchedArticles.Length == 0)
                return null;
            var articles = new List<Article>();
            foreach (var dataRow in searchedArticles)
            {
                var art = (libraryDataSet.ArticlesRow) dataRow;
                Article tempArticle;

                var articleAndMagazine = art.GetArticlesInMagazinesRows();
                if (art.ItemsRow != null && articleAndMagazine[0].MagazinesRow.ItemsRow != null &&
                    articleAndMagazine[0].MagazinesRow != null && articleAndMagazine.Length > 0 && art.AuthorsRow != null)
                    tempArticle = new Article(art.ItemsRow.ID,art.ItemsRow.Name, art.ItemsRow.Publisher, art.ItemsRow.PublishedDate,
                        articleAndMagazine[0].MagazinesRow.ItemsRow.Name, articleAndMagazine[0].MagazinesRow.IssueNumber,
                        art.AuthorsRow.Name, art.Version);
                else
                    throw new Exception("Cannot find corresponding Item");

                articles.Add(tempArticle);
            }
            return articles;
        }

        public List<Article> SearchedArticles(Article searchedArticle)
        {
            libraryDataSet.ItemsRow[] items = (libraryDataSet.ItemsRow[])_libraryDataSet.Items.Select(MakeFilteredQuery(searchedArticle.ItemFields));

            var articles = (items.Select(item => item.GetArticlesRows())
                .Where(article => article != null && article.Length != 0)
                .Select(article => article[0])).ToList();

            var authors = (libraryDataSet.AuthorsRow[])_libraryDataSet.Authors.Select(MakeFilteredQuery(searchedArticle.AuthorFields));

            var final = new List<libraryDataSet.ArticlesRow>();
            foreach (libraryDataSet.AuthorsRow author in authors)
            {
                var findedArticles = articles.FindAll(val => val.AuthorID == author.ID);
                if (findedArticles.Count > 0)
                    final.AddRange(findedArticles);
            }
            return final.Count == 0 ? new List<Article>(0) : GetRestPartsOfArticles(final.ToArray());
        }
    
        public List<Article> AddArticles(List<Article> newArticles)
        {
            var notAdded = new List<Article>();
            foreach (Article article in newArticles)
            {
                
                DataRow author = null;
                bool isUnique = IsUniqueArticleInDb(article, out author);
                
                if (!isUnique)
                {
                    var artRows = _libraryDataSet.Articles.Select(String.Format("Version = '{0}'", article.Version));
                    foreach (var dataRow in artRows)
                    {
                        var artRow = (libraryDataSet.ArticlesRow) dataRow;
                        if (artRow.ItemsRow.Name != article.Name || artRow.ItemsRow.Publisher != article.Publisher ||
                            artRow.AuthorsRow.Name != article.AuthorName) continue;

                        var Copy = _libraryDataSet.Copies.AddCopiesRow(Guid.NewGuid().ToString(), artRow.ItemsRow, false);
                        Copy.ItemID = artRow.ItemsRow.ID;
                        _provider.UpdateAllData();
                    }
                    notAdded.Add(article);
                    continue;
                }

                libraryDataSet.ItemsRow itemRow = _libraryDataSet.Items.AddItemsRow(article.Id, article.Name, article.Publisher, article.PublishedDate);
                libraryDataSet.AuthorsRow authorRow;
                if (author == null)
                    authorRow = _libraryDataSet.Authors.AddAuthorsRow(Guid.NewGuid().ToString(), article.AuthorName);
                else
                    authorRow = (libraryDataSet.AuthorsRow)author;
                libraryDataSet.ArticlesRow articleRow = _libraryDataSet.Articles.AddArticlesRow(itemRow, authorRow, article.Version );

                DataRowCollection allMagazines = _libraryDataSet.Magazines.Rows;

                var searchedMagazines = allMagazines.Cast<libraryDataSet.MagazinesRow>()
                    .Where(magazine => 
                        magazine.ItemsRow.Name == article.MagazineName && 
                        magazine.IssueNumber == article.MagazineIssueNumber)
                    .ToList();

                if (searchedMagazines.Count == 0)
                    return new List<Article>(0);

                foreach (var magazineRow in searchedMagazines)
                {
                    _libraryDataSet.ArticlesInMagazines.AddArticlesInMagazinesRow(articleRow, magazineRow);
                }
                libraryDataSet.CopiesRow copy = _libraryDataSet.Copies.AddCopiesRow(Guid.NewGuid().ToString(), itemRow, false);
                copy.ItemID = article.Id;
                _provider.UpdateAllData();
            }
            return notAdded;
        }

        private bool IsUniqueArticleInDb(Article article, out DataRow author)
        {
            author = null;
            _libraryDataSet = _provider.GetAllData(_dataType, _targetFile);

            foreach(var authorRow in _libraryDataSet.Authors)
            {
                if (authorRow.Name == article.AuthorName)
                    author = authorRow;
            }

            foreach (libraryDataSet.ArticlesRow articleRow in _libraryDataSet.Articles)
            {
                libraryDataSet.ArticlesInMagazinesRow[] artAndMag = articleRow.GetArticlesInMagazinesRows();
                if (articleRow.ItemsRow.Name == article.Name && articleRow.ItemsRow.Publisher == article.Publisher && articleRow.Version == article.Version && articleRow.AuthorsRow.Name == article.AuthorName &&
                    article.MagazineName == artAndMag[0].MagazinesRow.ItemsRow.Name && article.MagazineIssueNumber == artAndMag[0].MagazinesRow.IssueNumber)
                    return false;
            }
            return true;
        }
    }
}
