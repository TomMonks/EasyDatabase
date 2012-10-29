using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyDatabase.SQL
{
    public class NoJoin : ITableJoin   
    {
        protected const string COMMA = ",";
        protected const string SPACE = " ";
        protected const string BLANK = "";

        protected TableAlias table1;
        protected TableAlias table2;

        #region Properties

        public TableAlias Table1
        {
            get { return this.table1; }
        }

        public TableAlias Table2
        {
            get { return this.table2; }
        }

        public string Field1
        {
            get { return BLANK; }
        }

        public string Field2
        {
            get { return BLANK; }
        }

        #endregion

        public NoJoin(TableAlias table1, TableAlias table2)
        {
            this.table1 = table1;
            this.table2 = table2;

        }

        public override string ToString()
        {
            return string.Concat(this.table1.ToString(), COMMA, SPACE, this.table2.ToString());
        }


  
    }
}
