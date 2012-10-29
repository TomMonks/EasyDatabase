/*
 * Created by SharpDevelop.
 * User: tm300
 * Date: 11/09/2012
 * Time: 11:44
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace EasyDatabase.SQL
{
	/// <summary>
	/// A standard clause such as dept = 3; another example would be empid = 10
	/// </summary>
	public class StandardClause : IRestrictClause 
	{

        protected const string SPACE = " ";
        protected const string MISSING_VALUE_ERROR = "Please provide a value for the clause";
        protected const string EQUALS = "=";
        protected const string GREATER_THAN = ">";
        protected const string LESS_THAN = "<";

		protected string fieldName;

        /// <summary>
        /// American format mm/dd/yyyy
        /// </summary>
        public string Value { get; set; }

        public SQLOperator Operator { get; set; }
		
	
		public StandardClause(string fieldName)
		{
			this.fieldName = fieldName;
		}
	
		public override string ToString()
    	{
        	string sql;

            if (null != this.Value)
            {
                sql = fieldName + ConvertOperator() + SPACE + this.Value;
            }else{
                throw new NullReferenceException(MISSING_VALUE_ERROR);
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
