using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyDatabase.SQL
{

    public class BetweenDatesClause : IRestrictClause 
    {


        protected const string MISSING_DATE_ERROR = "Please provide both a from and to date for the query";

        /// <summary>
        /// American format mm/dd/yyyy
        /// </summary>
        public string fromDate
        {
            get;
            set;
        }


        /// <summary>
        /// American format mm/dd/yyyy
        /// </summary>
        public string toDate
        {
            get;
            set;
        }

        protected string fieldName;

        public BetweenDatesClause(string fieldName)
        {
            this.fieldName = fieldName;
        }

        public override string ToString()
        {
            string between;
            
            if (fromDate != null & toDate != null)
            {
                between = string.Concat(fieldName, " between #",  this.fromDate,  "# and #", this.toDate + "#");
       
            }
            else
            {
                throw new NullReferenceException(MISSING_DATE_ERROR);
            }

            return between;
        }
    }
}
