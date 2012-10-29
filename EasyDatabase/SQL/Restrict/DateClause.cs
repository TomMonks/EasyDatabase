using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyDatabase.SQL
{

    public enum SQLOperator
    {
        Equals = 0,
        GreaterThan = 1,
        LessThan = 2
    }


    /// <summary>
    /// Represents a date field either euqal to, greater than or less than a specified date.
    /// </summary>
    public class DateClause: IRestrictClause
    {

        protected const string EQUALS = "=";
        protected const string GREATER_THAN = ">";
        protected const string LESS_THAN = "<";

        protected string fieldName;

        /// <summary>
        /// American format mm/dd/yyyy
        /// </summary>
        public string Date { get; set; }

        public SQLOperator Operator { get; set; }


        public DateClause(string fieldName)
        {
            this.fieldName = fieldName;

        }

        public override string ToString()
        {
            string sql;

            if (null != this.Date)
            {
                sql = fieldName + ConvertOperator() + " #" + this.Date + "#";
            }else{
                throw new NullReferenceException("Please provide a date for the clause");
            }

            return sql;
        }

        private string ConvertOperator()
        {
            if (this.Operator == SQLOperator.Equals)
            {
                return EQUALS;
            }else if(this.Operator == SQLOperator.GreaterThan){
                return GREATER_THAN;
            }else{
            
                return LESS_THAN;
            }
        }

    }
}
