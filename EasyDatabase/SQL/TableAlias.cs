using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyDatabase.SQL
{
    /// <summary>
    /// Encapsulates a table and its alias
    /// </summary>
    public struct TableAlias
    {
        public readonly string tableName;
        public readonly string alias;

        public string TableName { get { return this.tableName; } }
        public string Alias { get { return this.alias; } }


        public TableAlias(string tableName, string alias)
        {
            this.tableName = tableName;
            this.alias = alias;
        }

        public override string ToString()
        {
            return String.Format("{0} AS {1}", this.TableName, this.Alias);
        }

        public override bool Equals(object obj)
        {
            var test = (TableAlias)obj;

            if (test.TableName == this.TableName && test.Alias == this.Alias)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
