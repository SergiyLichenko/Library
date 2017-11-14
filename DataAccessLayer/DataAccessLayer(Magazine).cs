using System;
using System.Collections.Generic;
using System.Data;
using Common;

namespace DataAccessLayer
{
    public partial class DataAccessLayer
    {
        public List<Magazine> GetAllMagazines()
        {
            var magazines = this._libraryDataSet.Magazines.Select();
            return GetRestPartsOfMagazines(magazines);
        }

        private List<Magazine> GetRestPartsOfMagazines(IReadOnlyCollection<DataRow> magazines)
        {
            if (magazines == null || magazines.Count == 0)
                return null;
            var finalMagazines = new List<Magazine>();
            foreach (var dataRow in magazines)
            {
                var magazine = (libraryDataSet.MagazinesRow) dataRow;
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
                filter =$"Parent.Name Like '%{searchedMagazine.Name}%' and Parent.Publisher Like" +
                    $" '%{searchedMagazine.Publisher}%' and IssueNumber Like '%{searchedMagazine.IssueNumber}%'";
            else
                filter = String.Format("Parent.Name Like '%{0}%' and Parent.Publisher Like '%{1}%' and Parent.PublishedDate Like '%{3}%' and IssueNumber Like '%{2}%'",
                searchedMagazine.Name, searchedMagazine.Publisher, searchedMagazine.IssueNumber,searchedMagazine.PublishedDate);
            var searched = _libraryDataSet.Magazines.Select(filter);

            foreach(var dataRow in searched)
            {
                var magazine = (libraryDataSet.MagazinesRow) dataRow;
                result.Add(new Magazine(magazine.GetParentRow("Magazines-Items")["ID"].ToString(), magazine.GetParentRow("Magazines-Items")["Name"].ToString(),
                    magazine.GetParentRow("Magazines-Items")["Publisher"].ToString(), magazine.GetParentRow("Magazines-Items")["PublishedDate"].ToString(), magazine.IssueNumber.ToString()));
            }
            return result;

        }

        private bool IsUniqueMagazineInDb(Magazine magazine)
        {
            DataRow [] allMagazines = _libraryDataSet.Magazines.Select();
            if (allMagazines.Length == 0)
                return true;
            foreach (var dataRow in allMagazines)
            {
                var magazineRow = (libraryDataSet.MagazinesRow) dataRow;
                if (magazineRow.ItemsRow.Name == magazine.Name && magazineRow.ItemsRow.Publisher == magazine.Publisher &&
                    magazineRow.IssueNumber==magazine.IssueNumber)
                    return false;
            }

            return true;
        }

        public List<Magazine> AddMagazines(List<Magazine> list)
        {
            var notUpdated = new List<Magazine>();
            if(list.Count == 0 || list == null)
                return null;

            foreach (var magazine in list)
            {
                
                bool isUnique = IsUniqueMagazineInDb(magazine);
                
                if (!isUnique)
                {
                    DataRow[] magazines = _libraryDataSet.Magazines.Select(String.Format("IssueNumber = '{0}'", magazine.IssueNumber));

                    foreach (var dataRow in magazines)
                    {
                        var mag = (libraryDataSet.MagazinesRow) dataRow;
                        if (mag.ItemsRow.Name != magazine.Name ||
                            mag.ItemsRow.Publisher != magazine.Publisher) continue;

                        var Copy = _libraryDataSet.Copies.AddCopiesRow(Guid.NewGuid().ToString(), mag.ItemsRow, false);
                        Copy.ItemID = mag.ItemsRow.ID;
                        _provider.UpdateAllData();
                    }
                    notUpdated.Add(magazine);
                    continue;
                }

                var item = _libraryDataSet.Items.AddItemsRow(magazine.Id, magazine.Name, magazine.Publisher, magazine.PublishedDate);
                _libraryDataSet.Magazines.AddMagazinesRow(item,magazine.IssueNumber);
                var copy = _libraryDataSet.Copies.AddCopiesRow(Guid.NewGuid().ToString(), item, false);
                copy.ItemID = magazine.Id;
                _provider.UpdateAllData();
            }
            return notUpdated;
        }
    }
}
