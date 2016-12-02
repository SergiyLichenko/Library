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
            DataRow[] searchedArticles = LibraryDataSet.articles.Select();
            return GetRestPartsOfArticles(searchedArticles);
        }
        private List<Article> GetRestPartsOfArticles(DataRow[] searchedArticles)
        {
            if (searchedArticles.Length == 0 || searchedArticles == null)
                return null;
            List<Article> articles = new List<Article>();
            foreach (libraryDataSet.articlesRow art in searchedArticles)
            {
                Article tempArticle=null;
                libraryDataSet.articlesinmagazinesRow[] articleAndMagazine = art.GetarticlesinmagazinesRows();
                if (art.itemsRow != null && articleAndMagazine[0].magazinesRow.itemsRow != null &&
                    articleAndMagazine[0].magazinesRow != null && articleAndMagazine.Length > 0 && art.authorsRow != null)
                    tempArticle = new Article(art.itemsRow.ID,art.itemsRow.Name, art.itemsRow.Publisher, art.itemsRow.PublishedDate,
                        articleAndMagazine[0].magazinesRow.itemsRow.Name, articleAndMagazine[0].magazinesRow.IssueNumber,
                        art.authorsRow.Name, art.Version);
                else
                    throw new Exception("Cannot find corresponding Item");
                if (tempArticle != null)
                    articles.Add(tempArticle);
            }
            return articles;
        }

        public List<Article> SearchedArticles(Article searchedArticle)
        {
            libraryDataSet.itemsRow[] items = (libraryDataSet.itemsRow[])LibraryDataSet.items.Select(MakeFilteredQuery(searchedArticle.ItemFields));
            if (items.Length == 0 && items == null)
                return new List<Article>(0);

            List<libraryDataSet.articlesRow> articles = new List<libraryDataSet.articlesRow>();
            foreach (libraryDataSet.itemsRow item in items)
            {
                libraryDataSet.articlesRow[] article = item.GetarticlesRows();
                if (article != null && article.Length != 0)
                    articles.Add(article[0]);
            }
            
            libraryDataSet.authorsRow[] authors = (libraryDataSet.authorsRow[])LibraryDataSet.authors.Select(MakeFilteredQuery(searchedArticle.AuthorFields));
            if (authors.Length == 0 && authors == null)
                return new List<Article>(0);

            List<libraryDataSet.articlesRow> final = new List<libraryDataSet.articlesRow>();
            for (int i = 0; i < authors.Length; i++)
            {
                List<libraryDataSet.articlesRow> findedArticles = articles.FindAll(val => val.AuthorID == authors[i].ID);
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
                    DataRow[] artRows = LibraryDataSet.articles.Select(String.Format("Version = '{0}'", article.Version));
                    foreach (libraryDataSet.articlesRow artRow in artRows)
                    {
                        if (artRow.itemsRow.Name==article.Name && artRow.itemsRow.Publisher == article.Publisher && artRow.authorsRow.Name == article.AuthorName)
                        {
                            libraryDataSet.copiesRow Copy = LibraryDataSet.copies.AddcopiesRow(Guid.NewGuid().ToString(), artRow.itemsRow, false);
                            Copy.ItemID = artRow.itemsRow.ID;
                            provider.UpdateAllData();
                        }
                    }
                    notAdded.Add(article);
                    continue;
                }
                libraryDataSet.itemsRow itemRow = LibraryDataSet.items.AdditemsRow(article.ID, article.Name, article.Publisher, article.PublishedDate);
                libraryDataSet.authorsRow authorRow;
                if (author == null)
                    authorRow = LibraryDataSet.authors.AddauthorsRow(Guid.NewGuid().ToString(), article.AuthorName);
                else
                    authorRow = (libraryDataSet.authorsRow)author;
                libraryDataSet.articlesRow articleRow = LibraryDataSet.articles.AddarticlesRow(itemRow, article.Version, authorRow);

                DataRowCollection allMagazines = LibraryDataSet.magazines.Rows;
                List<libraryDataSet.magazinesRow> searchedMagazines = new List<libraryDataSet.magazinesRow>();
                
                foreach(libraryDataSet.magazinesRow magazine in allMagazines)
                {
                    if (magazine.itemsRow.Name == article.MagazineName && magazine.IssueNumber == article.MagazineIssueNumber) 
                        searchedMagazines.Add(magazine);
                }
                
                if (searchedMagazines == null || searchedMagazines.Count == 0)
                    return new List<Article>(0);
                foreach (libraryDataSet.magazinesRow magazineRow in searchedMagazines)
                {
                    LibraryDataSet.articlesinmagazines.AddarticlesinmagazinesRow(articleRow, magazineRow);
                }
                libraryDataSet.copiesRow copy = LibraryDataSet.copies.AddcopiesRow(Guid.NewGuid().ToString(), itemRow, false);
                copy.ItemID = article.ID;
                provider.UpdateAllData();
            }
            return notAdded;
        }

        private bool isUniqueArticleInDB(Article article, out DataRow author)
        {
            author = null;
            LibraryDataSet = provider.GetAllData(dataType, targetFile);
            foreach(libraryDataSet.authorsRow authorRow in LibraryDataSet.authors)
            {
                if (authorRow.Name == article.AuthorName)
                    author = authorRow;
            }
            foreach (libraryDataSet.articlesRow articleRow in LibraryDataSet.articles)
            {
                libraryDataSet.articlesinmagazinesRow[] ArtAndMag = articleRow.GetarticlesinmagazinesRows();
                if (articleRow.itemsRow.Name == article.Name && articleRow.itemsRow.Publisher == article.Publisher && articleRow.Version == article.Version && articleRow.authorsRow.Name == article.AuthorName &&
                    article.MagazineName == ArtAndMag[0].magazinesRow.itemsRow.Name && article.MagazineIssueNumber == ArtAndMag[0].magazinesRow.IssueNumber)
                    return false;
            }
            return true;
        }

        
    }
}
