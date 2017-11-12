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
        public List<Magazine> GetAllMagazines()
        {
            DataRow[] magazines = this.LibraryDataSet.Magazines.Select();
            return GetRestPartsOfMagazines(magazines);
        }

        private List<Magazine> GetRestPartsOfMagazines(DataRow[] magazines)
        {
            if (magazines == null || magazines.Length == 0)
                return null;
            List<Magazine> finalMagazines = new List<Magazine>();
            foreach (libraryDataSet.MagazinesRow magazine in magazines)
            {
                Magazine tempMagazine;
                
                if (magazine.ItemsRow != null)
                    tempMagazine = new Magazine(magazine.ItemID,magazine.ItemsRow.Name, magazine.ItemsRow.Publisher,
                        magazine.ItemsRow.PublishedDate, magazine.IssueNumber);
                else
                    throw new Exception("Cannot find corresponding Item");                
                finalMagazines.Add(tempMagazine);
            }
            return finalMagazines;
        }
        public List<Magazine> SearchedMagazines(Magazine searchedMagazine)
        {
            List<Magazine> result = new List<Magazine>();
            string filter;
            if (searchedMagazine.PublishedDate == String.Empty)
                filter = String.Format("Parent.Name Like '%{0}%' and Parent.Publisher Like '%{1}%' and IssueNumber Like '%{2}%'",
                searchedMagazine.Name,searchedMagazine.Publisher,searchedMagazine.IssueNumber);
            else
                filter = String.Format("Parent.Name Like '%{0}%' and Parent.Publisher Like '%{1}%' and Parent.PublishedDate Like '%{3}%' and IssueNumber Like '%{2}%'",
                searchedMagazine.Name, searchedMagazine.Publisher, searchedMagazine.IssueNumber,searchedMagazine.PublishedDate);
            DataRow[] searched = LibraryDataSet.Magazines.Select(filter);

            foreach(libraryDataSet.MagazinesRow magazine in searched)
            {
                result.Add(new Magazine(magazine.GetParentRow("Magazines-Items")["ID"].ToString(), magazine.GetParentRow("Magazines-Items")["Name"].ToString(),
                    magazine.GetParentRow("Magazines-Items")["Publisher"].ToString(), magazine.GetParentRow("Magazines-Items")["PublishedDate"].ToString(), magazine.IssueNumber.ToString()));
            }
            return result;

        }

        /*public List<Magazine> SearchedMagazines(Magazine searchedMagazine)
        {
            libraryDataSet.itemsRow[] itemsRows = (libraryDataSet.itemsRow[])
                LibraryDataSet.items.Select(MakeFilteredQuery(searchedMagazine.ItemFields));
            if (itemsRows == null || itemsRows.Length == 0)
                return new List<Magazine>(0);

            List<libraryDataSet.magazinesRow> magazines = new List<libraryDataSet.magazinesRow>();
            foreach (libraryDataSet.itemsRow item in itemsRows)
            {
                libraryDataSet.magazinesRow[] magazineRow = item.GetmagazinesRows();
                if (magazineRow != null && magazineRow.Length != 0)
                    magazines.Add(magazineRow[0]);
            }
            if (searchedMagazine.IssueNumber == String.Empty)
                return GetRestPartsOfMagazines(magazines.ToArray()); ;

            List<libraryDataSet.magazinesRow> final;

            final = magazines.FindAll(val => val.IssueNumber == searchedMagazine.IssueNumber);
            return GetRestPartsOfMagazines(final.ToArray());
        }*/

        private bool IsUniqueMagazineInDB(Magazine magazine)
        {
            DataRow [] allMagazines = LibraryDataSet.Magazines.Select();
            if (allMagazines != null && allMagazines.Length == 0)
                return true;
            foreach (libraryDataSet.MagazinesRow magazineRow in allMagazines)
            {
                if (magazineRow.ItemsRow.Name == magazine.Name && magazineRow.ItemsRow.Publisher == magazine.Publisher &&
                    magazineRow.IssueNumber==magazine.IssueNumber)
                    return false;
            }
            return true;
        }
        public List<Magazine> AddMagazines(List<Magazine> list)
        {

            List<Magazine> notUpdated = new List<Magazine>();
            if(list.Count == 0 || list == null)
                return null;
            foreach (Magazine magazine in list)
            {
                
                bool isUnique = IsUniqueMagazineInDB(magazine);
                
                if (!isUnique)
                {
                    DataRow[] magazines = LibraryDataSet.Magazines.Select(String.Format("IssueNumber = '{0}'", magazine.IssueNumber));

                    foreach (libraryDataSet.MagazinesRow mag in magazines)
                    {
                        if (mag.ItemsRow.Name==magazine.Name && mag.ItemsRow.Publisher==magazine.Publisher)
                        {
                            libraryDataSet.CopiesRow Copy = LibraryDataSet.Copies.AddCopiesRow(Guid.NewGuid().ToString(), mag.ItemsRow, false);
                            Copy.ItemID = mag.ItemsRow.ID;
                            provider.UpdateAllData();
                        }
                    }
                    notUpdated.Add(magazine);
                    continue;
                }
                libraryDataSet.ItemsRow item = LibraryDataSet.Items.AddItemsRow(magazine.ID, magazine.Name, magazine.Publisher, magazine.PublishedDate);
                LibraryDataSet.Magazines.AddMagazinesRow(item,magazine.IssueNumber);
                libraryDataSet.CopiesRow copy = LibraryDataSet.Copies.AddCopiesRow(Guid.NewGuid().ToString(), item, false);
                copy.ItemID = magazine.ID;
                provider.UpdateAllData();
            }
            return notUpdated;
        }
    }
}
