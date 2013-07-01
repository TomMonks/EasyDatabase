using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDatabase.SQL
{
    /// <summary>
    /// A clause restricting a field to a set of values e.g. SELECT * from SysObjects WHERE Type in(1,4) returns all records where Type = 1 or Type = 4
    /// </summary>
    public class InClause : IRestrictClause 
    {

        protected string fieldName;
        protected List<string> valueSet;

        /// <summary>
        /// The values to restrict the field to
        /// </summary>
        public List<string> ValueSet
        {
            get
            {
                return this.valueSet;
            }
            set
            {
                this.valueSet = value;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fieldName">The name of the field</param>
        public InClause(string fieldName)
        {
            this.fieldName = fieldName;
            this.valueSet = new List<string>();

        }


        /// <summary>
        /// Overloaded Constructor
        /// </summary>
        /// <param name="fieldName">The name of the field</param>
        public InClause(string fieldName, List<string> valueSet)
        {
            this.fieldName = fieldName;
            this.valueSet = valueSet;
        }

        public override string ToString()
        {
            string sql;

            if (0 < this.valueSet.Count )
            {
                sql = fieldName + " in (";
                
                foreach (var val in this.valueSet)
                {
                    sql += val + ", ";
                }

                sql = sql.Substring(0, sql.Length) + ")";
                 
            }
            else
            {
                throw new NullReferenceException("Please provide a value set for the in clause");
            }

            return sql;
        }
    }
}
