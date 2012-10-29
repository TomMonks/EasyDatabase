using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyDatabase.SQL
{

    public class ComplexSelectStatment : ISelectStatement 
    {
        protected const string TABLE_ERROR = "No table of this name has currently stored.  Please add this first to ensure that no mistakes are made in the select";
        protected const string SELECT = "SELECT";
        protected const string SPACE = " ";
        protected const string COMMA = ",";
        protected const string FULLSTOP = ".";


        protected Dictionary<string, string> fields;
        protected Dictionary<string, TableAlias> tables;
        protected int aliasCounter;

        public ComplexSelectStatment()
        {
            this.tables = new Dictionary<string, TableAlias>();
            this.fields = new Dictionary<string, string>();
            this.aliasCounter = 0;
        }

        /// <summary>
        /// Add a table that fields can be selected from
        /// </summary>
        /// <param name="tableName">The name of the table to add</param>
        public void AddTable(string tableName)
        {
            this.aliasCounter++;
            var alias = new TableAlias(tableName, Convert.ToChar(aliasCounter + 64).ToString());
            this.tables.Add(tableName, alias);

        }


        /// <summary>
        /// Select a field from a table.  
        /// Throws NullReferenceException if table has not been added to class tables collection
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="selectFromTableName"></param>
        public void AddField(string fieldName, string selectFromTableName)
        {

            if (this.tables.ContainsKey(selectFromTableName))
            {
                this.fields.Add(fieldName, this.tables[selectFromTableName].Alias + FULLSTOP + fieldName);
            }
            else
            {
                throw new NullReferenceException(TABLE_ERROR);

            }
        }

        /// <summary>
        /// Get the fieldname as it will appear in the SQL
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns>Fieldname including table alias</returns>
        public string GetSQLFormatFieldName(string fieldName){
            return this.fields[fieldName];
        }

        public override string ToString()
        {
            string statement = SELECT;

            AddSelectedFields(ref statement);

            return statement;

        }

        private void AddSelectedFields(ref string statement)
        {
            if (this.fields.Count > 0)
            {
                foreach (string field in fields.Values)
                {
                    statement = string.Concat(statement, SPACE, field, COMMA);

                }

                statement = statement.Substring(0, statement.Length - 1);

            }
            else
            {
                
                foreach(var table in tables.Values){
                    statement += table.Alias + ".* ,";
                }

                statement = statement.Substring(0, statement.Length - 1);
                
            }

        }

        
    }


}
