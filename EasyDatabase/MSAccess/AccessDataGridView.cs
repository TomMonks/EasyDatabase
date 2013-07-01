using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace EasyDatabase.MSAccess
{
    /// <summary>
    /// The standard AccessDataGridview class does not process the results after the query
    /// </summary>
    public class AccessDataGridView : AbstractAccessDataGridView 
    {
        protected override System.Data.DataTable ProcessResults(DataTable results)
        {
            return results;
        }
    }
}
