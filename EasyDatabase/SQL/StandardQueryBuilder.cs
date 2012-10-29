using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyDatabase.SQL
{
    public class StandardQueryBuilder : QueryBuilder 
    {

        /// <summary>
        /// QueryBuilder Constructor
        /// </summary>
        /// <param name="factory">A factory class that creates the components of a SQL statement</param>
        public StandardQueryBuilder(ISQLFactory factory) : base(factory)  {}

        /// <summary>
        /// Build a full SQL statement
        /// </summary>
        /// <returns>An SQL statement that can be execute against a DB</returns>
        public override string BuildSQL()
        {

            string query = string.Concat(select.ToString(), SPACE, from.ToString());
            query = RestrictResults(query);

            return query;

        }

        protected string RestrictResults(string query)
        {
            if (this.whereClauses.Count > 0)
            {
                query = string.Concat(query, SPACE, WHERE, SPACE);
            }
            else
            {
                return query;
            }

            foreach (var clause in this.whereClauses)
            {
                query = string.Concat(query, clause.ToString(), SPACE, AND, SPACE);
            }

            return query.Substring(0, query.Length - 5);
        }


    }
}
