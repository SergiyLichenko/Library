using System;
using System.Collections.Generic;
using Common;

namespace DataAccessLayer
{
    public partial class DataAccessLayer
    {
        private libraryDataSet _libraryDataSet;
        private readonly Provider.Provider _provider = new Provider.Provider();
        private readonly SourceType _dataType;
        private readonly string _targetFile;

        public DataAccessLayer(SourceType dataType, string targetFile)
        {
            _dataType = dataType;
            _targetFile = targetFile;
            _libraryDataSet = _provider.GetAllData(dataType, targetFile);
        }

        private string MakeFilteredQuery(Dictionary<string, string> searchedTable)
        {
            string query = String.Empty;
            if (searchedTable == null)
                return query;
            foreach (KeyValuePair<string, string> row in searchedTable)
            {
                if (string.IsNullOrEmpty(row.Value))
                    continue;
                if (query == String.Empty)
                    query += $"[{row.Key}] like '%{row.Value}%'";
                else
                    query += $" and [{row.Key}] like '%{row.Value}%'";
            }
            return query;
        }

        
    }
}
