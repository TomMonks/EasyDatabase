﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyDatabase.SQL
{
    public interface ISelectStatement
    {
        string GetSQLFormatFieldName(string fieldName);
    }
}
