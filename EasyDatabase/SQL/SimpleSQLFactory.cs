using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyDatabase.SQL
{
    public class SimpleSQLFactory : ISQLFactory 
    {
        protected string tableName;
        protected List<string> fields;

        /// <summary>
        /// Specify a select all (*) query from the specified table/view
        /// </summary>
        /// <param name="tableName">The table/view that contains the data</param>
        public SimpleSQLFactory(string tableName)
        {
            this.tableName = tableName;
            this.fields = new List<string>() { "*" };
        }

        /// <summary>
        /// Select a list of field names from the table or view
        /// </summary>
        /// <param name="tableName">The table/view that contains the data</param>
        /// <param name="fields">The list of field names containing the data to select</param>
        public SimpleSQLFactory(string tableName, List<string> fields)
        {
            this.tableName = tableName;
            this.fields = fields;
        }

        public ISelectStatement CreateSelect()
        {
         
            var select = new BasicSelectStatement();
            this.fields.ForEach(x => select.AddField(x));
            return select;
        }

        public IFromClause CreateFrom()
        {
            return new SimpleFromClause(this.tableName);
        }

        public List<IRestrictClause> CreateRestrictions()
        {
            return new List<IRestrictClause>();
        }
    }
}
