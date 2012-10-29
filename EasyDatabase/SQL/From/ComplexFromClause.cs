using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyDatabase.SQL
{
    public class ComplexFromClause : IFromClause 
    {
        protected const string FROM = "FROM";
        protected const string SPACE = " ";

        protected Dictionary<string, ITableJoin> joins;
                      
        public ComplexFromClause()
        {
            this.joins = new Dictionary<string, ITableJoin>();
        }

        public void AddJoin(ITableJoin join)
        {
            this.joins.Add(join.Table1.TableName, join);
        }

        public override string ToString()
        {
            string clause = FROM + SPACE;

            foreach (var join in joins.Values)
            {
                clause += join.ToString();
            }

            return clause;
        }
    }
}
