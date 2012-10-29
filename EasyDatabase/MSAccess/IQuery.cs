using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EasyDatabase.MSAccess
{
    public interface IQuery
    {
        DataTable Execute();
    }
}
