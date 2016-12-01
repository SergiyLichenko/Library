using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Common.libraryDataSetTableAdapters;
using System.Windows.Forms;

namespace Provider
{
    public class Provider
    {

        libraryDataSet libraryDS = new libraryDataSet();
        SqlDataAdapter[] libraryDataAdapters;
        DataTable[] libraryTables;
        string[] tablesName;
        SourceType dataType;
        string targetFile;

        public Provider() { }

        public libraryDataSet GetAllData(SourceType dataType, string targetFile)
        {
            
            this.dataType = dataType;
            this.targetFile = targetFile;

            if (dataType == SourceType.XML)
            {
                try
                {
                    this.libraryDS = new libraryDataSet();
                    this.libraryDS.ReadXml(targetFile);
                    this.libraryDS.ReadXmlSchema(targetFile);
                    return this.libraryDS;
                }
                catch (Exception)
                {
                    System.Windows.Forms.MessageBox.Show("An error occured. Restart application");
                    Application.ExitThread();
                }
               
            }
            this.libraryTables = new DataTable[]
            {
                this.libraryDS.items,
                this.libraryDS.authors,
                this.libraryDS.books,
                this.libraryDS.borrows,
                this.libraryDS.copies,
                this.libraryDS.magazines,
                this.libraryDS.articles,
                this.libraryDS.articlesinmagazines,
                this.libraryDS.users
            
            };            
            this.tablesName = new string[]{"Items","Authors","Books","Borrows","Copies",
                "Magazines","Articles","ArticlesInMagazines","Users"};
            libraryDataAdapters = new SqlDataAdapter[this.tablesName.Length];
            for (int i = 0; i < this.tablesName.Length; i++)
            {
                this.libraryDataAdapters[i] = new SqlDataAdapter("Select * from " + tablesName[i], targetFile);                
                SqlCommandBuilder builder = new SqlCommandBuilder(libraryDataAdapters[i]);
               
            }
            for (int i = 0; i < this.tablesName.Length; i++)
                this.libraryDataAdapters[i].Fill(libraryTables[i]);
            
            return this.libraryDS;
        }

        public void UpdateAllData()
        {            
            if (this.dataType == SourceType.XML)
            {
                this.libraryDS.WriteXml(this.targetFile);
                return;
            }
            try
            {                
                for (int i = 0; i < this.libraryDataAdapters.Length; i++)
                    this.libraryDataAdapters[i].Update(libraryTables[i]);
            }
            catch(Exception)
            {
            }
        }
        public void DeleteAuthor(string authorID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(targetFile))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("DeleteAuthor", con);
                    com.CommandType = CommandType.StoredProcedure;

                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@AuthorID";
                    param.SqlDbType = SqlDbType.NVarChar;
                    param.Value = authorID;
                    param.Direction = ParameterDirection.Input;
                    com.Parameters.Add(param);
                    com.ExecuteNonQuery();
                }
            }
            catch(Exception)
            {

            }
        }
        public void FillAuthors()
        {
            if (dataType == SourceType.XML)
                return;
            libraryTables[1].Clear();
            libraryDataAdapters[1].Fill(libraryTables[1]);
        }
    }
}
