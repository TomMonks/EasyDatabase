using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EasyDatabase.SQL;


namespace EasyDatabase.MSAccess
{
    /// <summary>
    /// Creates SQL to query the MSSytemObject table for tables and queries in MS Access 2007/10
    /// </summary>
    public class AccessSystemSQLFactory: ISQLFactory 
    {

        public const string TABLE_NAME = "MSysObjects";
        public const string NAME_FIELD = "Name";
        protected const string TYPE_FIELD = "Type";


        public ISelectStatement CreateSelect()
        {
            var select = new BasicSelectStatement();
            select.AddField(NAME_FIELD);
            return select;
        }

        public IFromClause CreateFrom()
        {
            return new SimpleFromClause(TABLE_NAME);
        }

        public List<IRestrictClause> CreateRestrictions()
        {
            var restricts = new List<IRestrictClause>();
            restricts.Add(new InClause(TYPE_FIELD, new List<string>(new string[] { "1", "5" })));
            return restricts;
        }
    }
}
