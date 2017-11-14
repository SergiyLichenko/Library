using System;
using Common;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Provider
{
    public class Provider
    {
        private libraryDataSet _libraryDs = new libraryDataSet();
        private SqlDataAdapter[] _libraryDataAdapters;
        private DataTable[] _libraryTables;
        private string[] _tablesName;
        private SourceType _dataType;
        private string _targetFile;

        public libraryDataSet GetAllData(SourceType dataType, string targetFile)
        {
            _dataType = dataType;
            _targetFile = targetFile;

            if (dataType == SourceType.Xml)
            {
                try
                {
                    _libraryDs = new libraryDataSet();
                    _libraryDs.ReadXml(targetFile);
                    _libraryDs.ReadXmlSchema(targetFile);
                    return _libraryDs;
                }
                catch (Exception)
                {
                    System.Windows.Forms.MessageBox.Show("An error occured. Restart application");
                    Application.ExitThread();
                }
            }
            _libraryTables = new DataTable[]
            {
                _libraryDs.Items,
                _libraryDs.Authors,
                _libraryDs.Books,
                _libraryDs.Borrows,
                _libraryDs.Copies,
                _libraryDs.Magazines,
                _libraryDs.Articles,
                _libraryDs.ArticlesInMagazines,
                _libraryDs.Users
            };
            _tablesName = new[]
            {
                "Items", "Authors", "Books", "Borrows", "Copies",
                "Magazines", "Articles", "ArticlesInMagazines", "Users"
            };
            _libraryDataAdapters = new SqlDataAdapter[_tablesName.Length];
            for (int i = 0; i < _tablesName.Length; i++)
            {
                _libraryDataAdapters[i] = new SqlDataAdapter("Select * from " + _tablesName[i], targetFile);
                new SqlCommandBuilder(_libraryDataAdapters[i]);
            }

            for (int i = 0; i < _tablesName.Length; i++)
                _libraryDataAdapters[i].Fill(_libraryTables[i]);

            return _libraryDs;
        }

        public void UpdateAllData()
        {
            if (_dataType == SourceType.Xml)
            {
                _libraryDs.WriteXml(_targetFile);
                return;
            }
            try
            {
                for (int i = 0; i < _libraryDataAdapters.Length; i++)
                    _libraryDataAdapters[i].Update(_libraryTables[i]);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public void DeleteAuthor(string authorId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_targetFile))
                {
                    con.Open();
                    var com = new SqlCommand("DeleteAuthor", con);
                    com.CommandType = CommandType.StoredProcedure;

                    var param = new SqlParameter();
                    param.ParameterName = "@AuthorID";
                    param.SqlDbType = SqlDbType.NVarChar;
                    param.Value = authorId;
                    param.Direction = ParameterDirection.Input;
                    com.Parameters.Add(param);
                    com.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
            }
        }

        public void FillAuthors()
        {
            if (_dataType == SourceType.Xml)
                return;
            _libraryTables[1].Clear();
            _libraryDataAdapters[1].Fill(_libraryTables[1]);
        }
    }
}