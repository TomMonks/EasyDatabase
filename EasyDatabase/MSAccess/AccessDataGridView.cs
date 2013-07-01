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
    public class AccessDataGridView: DataGridView
    {
        protected IDatabase database;
        protected QueryBuilder query;

        public AccessDataGridView() {

            
        }

        public IDatabase Database { set { this.database = value; } }
        public QueryBuilder Query { set { this.query = value; } }

        public void Execute()
        {
            var results = this.database.ExecuteQuery(this.query.BuildSQL());
            this.DataSource = results;
        }




    }
}
