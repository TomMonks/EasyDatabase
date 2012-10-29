using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyDatabase.SQL
{
    public class InnerJoin : AbstractTableJoin  
    {
        private const string INNER_JOIN = "INNER JOIN";

        public InnerJoin(TableAlias table1, TableAlias table2, string field1, string field2) : base(table1, table2, field1, field2)
        {

        }

        public override string ToString()
        {
            return string.Concat(this.table1.ToString(), SPACE, INNER_JOIN, SPACE, this.table2.ToString(), SPACE, ON, SPACE, this.field1, EQUALS, this.field2);
        }
    }
}
