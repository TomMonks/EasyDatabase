using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyDatabase.SQL
{
    public interface ISQLFactory
    {
        ISelectStatement CreateSelect();
        IFromClause CreateFrom();
        List<IRestrictClause> CreateRestrictions(); 
    }
}
