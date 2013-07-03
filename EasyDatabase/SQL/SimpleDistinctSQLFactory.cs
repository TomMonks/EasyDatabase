using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyDatabase.SQL
{
    public class SimpleDistinctSQLFactory : ISQLFactory 
    {
        protected string tableName;
        protected List<string> fields;
        protected DistinctSelectStatement select;

        /// <summary>
        /// Select a list of field names from the table or view
        /// </summary>
        /// <param name="tableName">The table/view that contains the data</param>
        /// <param name="fields">The list of field names containing the data to select</param>
        public SimpleDistinctSQLFactory(string tableName, List<string> fields)
        {
            this.tableName = tableName;
            this.fields = fields;
            this.select = new DistinctSelectStatement();
        }

        public ISelectStatement CreateSelect()
        {
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
