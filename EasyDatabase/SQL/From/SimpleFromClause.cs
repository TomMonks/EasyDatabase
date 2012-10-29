using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyDatabase.SQL
{
    public class SimpleFromClause : IFromClause
    {
        protected const string FROM = "FROM";
        protected const string SPACE = " ";
        
        protected string tableName;

        public SimpleFromClause(string tableName)
        {
            this.tableName = tableName;
        }

        public override string ToString()
        {
            return string.Concat(FROM, SPACE, tableName);
        }
    }
}
