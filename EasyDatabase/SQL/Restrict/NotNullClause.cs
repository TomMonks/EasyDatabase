using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyDatabase.SQL
{
    public class NotNullClause : IRestrictClause 
    {
        protected string fieldName;

        public NotNullClause(string fieldName)
        {
            this.fieldName = fieldName;
        }

        public override string ToString()
        {
            return string.Format("{0} IS NOT NULL", this.fieldName);
        }
    }
}
