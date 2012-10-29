using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyDatabase.SQL
{
    public abstract class AbstractTableJoin : ITableJoin 
    {
        protected const string ON = "ON";
        protected const string EQUALS = "=";
        protected const string SPACE = " ";

        protected TableAlias table1;
        protected TableAlias table2;
        protected string field1;
        protected string field2;

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
            get { return this.field1; }
        }

        public string Field2
        {
            get { return this.field2; }
        }

        #endregion

        public AbstractTableJoin(TableAlias table1, TableAlias table2, string field1, string field2)
        {
            this.table1 = table1;
            this.table2 = table2;
            this.field1 = field1;
            this.field2 = field2;
        }


    }
}
