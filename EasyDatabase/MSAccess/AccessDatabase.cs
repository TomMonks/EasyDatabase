using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.OleDb;

namespace EasyDatabase.MSAccess
{

    public static class AccessDatabaseCollections
    {
        public static string Tables = "Tables";
        public static string Queries = "Procedures";
    }

	/// <summary>
	/// Query an access database.  Connection string valid for 2007 onwards.
	/// </summary>
    public class AccessDatabase : IDatabase 
    {
        protected string connection;
        protected string path;
        protected OleDbConnection conn;

        public AccessDatabase(string path)
        {
            this.path = path;
            connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Persist Security Info=False;";
        }


        public DataTable ExecuteQuery(string sql)
        {
            conn = new OleDbConnection(connection);
            var results = new DataTable();

            try
            {
                conn.Open();

                OleDbDataAdapter adapter = null;

                using (adapter = new OleDbDataAdapter(CreateCommand(sql)))
                {
                    adapter.Fill(results);
                }
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return results;

        }

        public DataTable GetSchema(string collectionName)
        {
            DataTable results;

            conn = new OleDbConnection(connection);
            conn.Open();
            results =  conn.GetSchema(collectionName);
            conn.Close();
            return results;
        }


        //public DataTable GetTableSchema(string tableName)
        //{
        //    DataTable results;

            

        //    conn = new OleDbConnection(connection);
        //    conn.Open();
        //    results = conn.GetSchema("Columns", new string[]{null, null, null, tableName});
        //    conn.Close();
        //    return results;
        //}


        private OleDbCommand CreateCommand(string sql)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;

            return cmd;
        }


        

    }
}
