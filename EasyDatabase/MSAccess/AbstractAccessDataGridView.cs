using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data;

using EasyDatabase.SQL;

using EasyDatabase.MSAccess;

namespace EasyDatabase.MSAccess
{
    public abstract class AbstractAccessDataGridView: DataGridView
    {
        protected IDatabase database;
        protected QueryBuilder query;

        public AbstractAccessDataGridView() {
            
        }

        public IDatabase Database { set { this.database = value; } }
        public QueryBuilder Query { set { this.query = value; } }

        public void Execute()
        {
            var results = GetResults();
            results = ProcessResults(results);
            ShowResults(results);
        }

        protected virtual DataTable GetResults()
        {
            return this.database.ExecuteQuery(this.query.BuildSQL());
        }

        /// <summary>
        /// This method is abstract.  Inheriting classes implement its behaviour as appropriate (e.g. do nothing and return original results).
        /// </summary>
        /// <param name="results"></param>
        /// <returns></returns>
        protected abstract DataTable ProcessResults(DataTable results);
        
        protected virtual void ShowResults(DataTable results)
        {
            this.DataSource = results;
        }

    }
}
