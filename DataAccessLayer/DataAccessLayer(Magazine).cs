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
            DataRow[] magazines = this.LibraryDataSet.magazines.Select();
            return GetRestPartsOfMagazines(magazines);
        }

        private List<Magazine> GetRestPartsOfMagazines(DataRow[] magazines)
        {
            if (magazines == null || magazines.Length == 0)
                return null;
            List<Magazine> finalMagazines = new List<Magazine>();
            foreach (libraryDataSet.magazinesRow magazine in magazines)
            {
                Magazine tempMagazine;
                
                if (magazine.itemsRow != null)
                    tempMagazine = new Magazine(magazine.ItemID,magazine.itemsRow.Name, magazine.itemsRow.Publisher,
                        magazine.itemsRow.PublishedDate, magazine.IssueNumber);
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
            DataRow[] searched = LibraryDataSet.magazines.Select(filter);

            foreach(libraryDataSet.magazinesRow magazine in searched)
            {
                result.Add(new Magazine(magazine.GetParentRow("MagazinesItems")["ID"].ToString(), magazine.GetParentRow("MagazinesItems")["Name"].ToString(),
                    magazine.GetParentRow("MagazinesItems")["Publisher"].ToString(), magazine.GetParentRow("MagazinesItems")["PublishedDate"].ToString(), magazine.IssueNumber.ToString()));
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
            DataRow [] allMagazines = LibraryDataSet.magazines.Select();
            if (allMagazines != null && allMagazines.Length == 0)
                return true;
            foreach (libraryDataSet.magazinesRow magazineRow in allMagazines)
            {
                if (magazineRow.itemsRow.Name == magazine.Name && magazineRow.itemsRow.Publisher == magazine.Publisher &&
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
                    DataRow[] magazines = LibraryDataSet.magazines.Select(String.Format("IssueNumber = '{0}'", magazine.IssueNumber));

                    foreach (libraryDataSet.magazinesRow mag in magazines)
                    {
                        if (mag.itemsRow.Name==magazine.Name && mag.itemsRow.Publisher==magazine.Publisher)
                        {
                            libraryDataSet.copiesRow Copy = LibraryDataSet.copies.AddcopiesRow(Guid.NewGuid().ToString(), mag.itemsRow, false);
                            Copy.ItemID = mag.itemsRow.ID;
                            provider.UpdateAllData();
                        }
                    }
                    notUpdated.Add(magazine);
                    continue;
                }
                libraryDataSet.itemsRow item = LibraryDataSet.items.AdditemsRow(magazine.ID, magazine.Name, magazine.Publisher, magazine.PublishedDate);
                LibraryDataSet.magazines.AddmagazinesRow(item,magazine.IssueNumber);
                libraryDataSet.copiesRow copy = LibraryDataSet.copies.AddcopiesRow(Guid.NewGuid().ToString(), item, false);
                copy.ItemID = magazine.ID;
                provider.UpdateAllData();
            }
            return notUpdated;
        }
    }
}
