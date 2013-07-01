using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Windows.Forms;

using EasyDatabase;

namespace EasyDatabase.MSAccess
{
    /// <summary>
    /// View the fields within a select access data table or query
    /// </summary>
    public class AccessObjectDataGridView : AbstractAccessDataGridView   
    {

        private const string COLUMN_HEADING = "Field";

        /// <summary>
        /// Overrides processing of results.  Loops through the columns of the results parameter
        /// and converts CoilumnNames into rows in a new DataTable
        /// </summary>
        /// <param name="results">DataTable to transpose into fieldname list</param>
        /// <returns></returns>
        protected override DataTable ProcessResults(DataTable results)
        {
            
            var fieldNames = new DataTable();
            fieldNames.Columns.Add(COLUMN_HEADING);

            foreach(DataColumn col in results.Columns){
                var toAdd = fieldNames.NewRow();
                toAdd[0] = col.ColumnName;
                fieldNames.Rows.Add(toAdd);
            }

            return fieldNames;
        }

    }
}
