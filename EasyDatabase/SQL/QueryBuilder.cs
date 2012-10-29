using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EasyDatabase.SQL
{
    public abstract class QueryBuilder  
    {
        protected const string WHERE = "WHERE";
        protected const string SPACE = " ";
        protected const string AND = "AND";
        
        protected List<IRestrictClause> whereClauses;
        protected ISelectStatement  select;
        protected IFromClause from;

        /// <summary>
        /// QueryBuilderConstructor
        /// </summary>
        /// <param name="factory">A factory class that creates the components of a SQL statement</param>
        public QueryBuilder(ISQLFactory factory)
        {
            this.select = factory.CreateSelect();
            this.from = factory.CreateFrom();
            this.whereClauses = factory.CreateRestrictions();
        }


        /// <summary>
        /// Build a full SQL statement
        /// </summary>
        /// <returns>An SQL statement that can be execute against a DB</returns>
        public abstract string BuildSQL();

      
    }
}
