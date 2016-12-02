using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Provider;

namespace DataAccessLayer
{
    public partial class DataAccessLayer
    {
        libraryDataSet LibraryDataSet;
        Provider.Provider provider = new Provider.Provider();
        SourceType dataType;
        string targetFile;
        public DataAccessLayer(SourceType dataType, string targetFile)
        {
            this.dataType = dataType;
            this.targetFile = targetFile;
            this.LibraryDataSet = this.provider.GetAllData(dataType, targetFile);
        }
        private string MakeFilteredQuery(Dictionary<string, string> searchedTable)
        {
            string query = String.Empty;
            if (searchedTable == null)
                return query;
            foreach (KeyValuePair<string, string> row in searchedTable)
            {
                if (row.Value == null || row.Value == String.Empty)
                    continue;
                if (query == String.Empty)
                    query += String.Format("[{0}] like '%{1}%'", row.Key, row.Value);
                else
                    query += String.Format(" and [{0}] like '%{1}%'", row.Key, row.Value);
            }
            return query;
        }

        
    }
}
