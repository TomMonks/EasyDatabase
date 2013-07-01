using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EasyDatabase.SQL;

namespace EasyDatabase.MSAccess
{
    public class AccessObjectSQLFactory : ISQLFactory 
    {
        protected const string FIELDS_ONLY = "TOP 1 * ";

        public string ObjectName { get; set; }


        public ISelectStatement CreateSelect()
        {
            var select = new BasicSelectStatement();
            select.AddField(FIELDS_ONLY);
            return select;
        }

        public IFromClause CreateFrom()
        {
            if (this.ObjectName == "")
            {
                throw new ArgumentNullException("Please specify a table or query name");
            }

            return new SimpleFromClause(this.ObjectName);
        }

        public List<IRestrictClause> CreateRestrictions()
        {
            //no resticts
            var restricts = new List<IRestrictClause>();
            return restricts;
        }
    }
}
