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
        public List<Article> GetAllArticles()
        {
            DataRow[] searchedArticles = LibraryDataSet.Articles.Select();
            return GetRestPartsOfArticles(searchedArticles);
        }
        private List<Article> GetRestPartsOfArticles(DataRow[] searchedArticles)
        {
            if (searchedArticles.Length == 0 || searchedArticles == null)
                return null;
            List<Article> articles = new List<Article>();
            foreach (libraryDataSet.ArticlesRow art in searchedArticles)
            {
                Article tempArticle=null;
                libraryDataSet.ArticlesInMagazinesRow[] articleAndMagazine = art.GetArticlesInMagazinesRows();
                if (art.ItemsRow != null && articleAndMagazine[0].MagazinesRow.ItemsRow != null &&
                    articleAndMagazine[0].MagazinesRow != null && articleAndMagazine.Length > 0 && art.AuthorsRow != null)
                    tempArticle = new Article(art.ItemsRow.ID,art.ItemsRow.Name, art.ItemsRow.Publisher, art.ItemsRow.PublishedDate,
                        articleAndMagazine[0].MagazinesRow.ItemsRow.Name, articleAndMagazine[0].MagazinesRow.IssueNumber,
                        art.AuthorsRow.Name, art.Version);
                else
                    throw new Exception("Cannot find corresponding Item");
                if (tempArticle != null)
                    articles.Add(tempArticle);
            }
            return articles;
        }

        public List<Article> SearchedArticles(Article searchedArticle)
        {
            libraryDataSet.ItemsRow[] items = (libraryDataSet.ItemsRow[])LibraryDataSet.Items.Select(MakeFilteredQuery(searchedArticle.ItemFields));
            if (items.Length == 0 && items == null)
                return new List<Article>(0);

            List<libraryDataSet.ArticlesRow> articles = new List<libraryDataSet.ArticlesRow>();
            foreach (libraryDataSet.ItemsRow item in items)
            {
                libraryDataSet.ArticlesRow[] article = item.GetArticlesRows();
                if (article != null && article.Length != 0)
                    articles.Add(article[0]);
            }
            
            libraryDataSet.AuthorsRow[] authors = (libraryDataSet.AuthorsRow[])LibraryDataSet.Authors.Select(MakeFilteredQuery(searchedArticle.AuthorFields));
            if (authors.Length == 0 && authors == null)
                return new List<Article>(0);

            List<libraryDataSet.ArticlesRow> final = new List<libraryDataSet.ArticlesRow>();
            for (int i = 0; i < authors.Length; i++)
            {
                List<libraryDataSet.ArticlesRow> findedArticles = articles.FindAll(val => val.AuthorID == authors[i].ID);
                if (findedArticles != null && findedArticles.Count > 0)
                    final.AddRange(findedArticles);
            }
            if (final.Count == 0 || final == null)
                return new List<Article>(0);
            return GetRestPartsOfArticles(final.ToArray());
        }
        //Самий жосткий метод який я написав повністю сам :D
        public List<Article> AddArticles(List<Article> newArticles)
        {
            List<Article> notAdded = new List<Article>();
            foreach (Article article in newArticles)
            {
                
                DataRow author = null;
                bool isUnique = isUniqueArticleInDB(article, out author);
                
                if (!isUnique)
                {
                    DataRow[] artRows = LibraryDataSet.Articles.Select(String.Format("Version = '{0}'", article.Version));
                    foreach (libraryDataSet.ArticlesRow artRow in artRows)
                    {
                        if (artRow.ItemsRow.Name==article.Name && artRow.ItemsRow.Publisher == article.Publisher && artRow.AuthorsRow.Name == article.AuthorName)
                        {
                            libraryDataSet.CopiesRow Copy = LibraryDataSet.Copies.AddCopiesRow(Guid.NewGuid().ToString(), artRow.ItemsRow, false);
                            Copy.ItemID = artRow.ItemsRow.ID;
                            provider.UpdateAllData();
                        }
                    }
                    notAdded.Add(article);
                    continue;
                }
                libraryDataSet.ItemsRow itemRow = LibraryDataSet.Items.AddItemsRow(article.ID, article.Name, article.Publisher, article.PublishedDate);
                libraryDataSet.AuthorsRow authorRow;
                if (author == null)
                    authorRow = LibraryDataSet.Authors.AddAuthorsRow(Guid.NewGuid().ToString(), article.AuthorName);
                else
                    authorRow = (libraryDataSet.AuthorsRow)author;
                libraryDataSet.ArticlesRow articleRow = LibraryDataSet.Articles.AddArticlesRow(itemRow, authorRow, article.Version );

                DataRowCollection allMagazines = LibraryDataSet.Magazines.Rows;
                List<libraryDataSet.MagazinesRow> searchedMagazines = new List<libraryDataSet.MagazinesRow>();
                
                foreach(libraryDataSet.MagazinesRow magazine in allMagazines)
                {
                    if (magazine.ItemsRow.Name == article.MagazineName && magazine.IssueNumber == article.MagazineIssueNumber) 
                        searchedMagazines.Add(magazine);
                }
                
                if (searchedMagazines == null || searchedMagazines.Count == 0)
                    return new List<Article>(0);
                foreach (libraryDataSet.MagazinesRow magazineRow in searchedMagazines)
                {
                    LibraryDataSet.ArticlesInMagazines.AddArticlesInMagazinesRow(articleRow, magazineRow);
                }
                libraryDataSet.CopiesRow copy = LibraryDataSet.Copies.AddCopiesRow(Guid.NewGuid().ToString(), itemRow, false);
                copy.ItemID = article.ID;
                provider.UpdateAllData();
            }
            return notAdded;
        }

        private bool isUniqueArticleInDB(Article article, out DataRow author)
        {
            author = null;
            LibraryDataSet = provider.GetAllData(dataType, targetFile);
            foreach(libraryDataSet.AuthorsRow authorRow in LibraryDataSet.Authors)
            {
                if (authorRow.Name == article.AuthorName)
                    author = authorRow;
            }
            foreach (libraryDataSet.ArticlesRow articleRow in LibraryDataSet.Articles)
            {
                libraryDataSet.ArticlesInMagazinesRow[] ArtAndMag = articleRow.GetArticlesInMagazinesRows();
                if (articleRow.ItemsRow.Name == article.Name && articleRow.ItemsRow.Publisher == article.Publisher && articleRow.Version == article.Version && articleRow.AuthorsRow.Name == article.AuthorName &&
                    article.MagazineName == ArtAndMag[0].MagazinesRow.ItemsRow.Name && article.MagazineIssueNumber == ArtAndMag[0].MagazinesRow.IssueNumber)
                    return false;
            }
            return true;
        }

        
    }
}
