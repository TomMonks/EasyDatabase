using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace EasyDatabase.SQL
{

    /// <summary>
    /// Basic select statement from one table (no aliases)
    /// </summary>
    public class BasicSelectStatement : ISelectStatement 
    {
        protected const string SELECT = "SELECT";
        protected const string ALL = "*";
        protected const string SPACE = " ";

        protected List<string> fields;
                
        public BasicSelectStatement()
        {
            this.fields = new List<string>();
        }

        public override string ToString()
        {
            string statement = SELECT;

            AddSelectedFields(ref statement);

            return statement;

        }

        

        /// <summary>
        /// Add a field to the select statement
        /// </summary>
        /// <param name="fieldName">A fieldName from the database table</param>
        public void AddField(string fieldName){
        	fields.Add(fieldName);
        }
        
        private void AddSelectedFields(ref string statement)
        {
            if (fields.Count > 0)
            {
                foreach (string field in fields)
                {
                    statement = string.Concat(statement, " ", field, ",");
                    
                }
                
                statement = statement.Substring(0, statement.Length - 1);

            }
            else
            {
                statement = statement + SPACE + ALL;
            }
            
        }

        /// <summary>
        /// Get the field name as it will appear in the SQL
        /// </summary>
        /// <param name="fieldName">The fieldName to return</param>
        /// <returns>Basic select will return the fieldname in the same format</returns>
        public string GetSQLFormatFieldName(string fieldName)
        {
            return fieldName;
        }
    }
}
