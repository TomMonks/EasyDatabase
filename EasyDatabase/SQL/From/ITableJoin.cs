using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyDatabase.SQL
{
    public interface ITableJoin
    {
        TableAlias Table1 { get; }
        TableAlias Table2 { get; }

        string Field1 { get; }
        string Field2 { get; }

    }
}
