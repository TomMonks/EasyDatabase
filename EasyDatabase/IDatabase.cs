using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace EasyDatabase
{
    public interface IDatabase
    {
        DataTable ExecuteQuery(string SQL);
        DataTable GetSchema(string collectionName);
    }
}
