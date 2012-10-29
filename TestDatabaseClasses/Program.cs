using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EasyDatabase.MSAccess;
using EasyDatabase.SQL;

using System.Data;

using ExcelDotNet;
using ExcelDotNet.Format;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing;

namespace TestEasyDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestDBAccess();

            //TestComplexClause();
            //TestComplexClauseNoJoin();


           
            ComplexSelectStatment select = new ComplexSelectStatment();
            select.AddTable("emp");
            select.AddTable("dept");
            select.AddField("empid", "emp");
            select.AddField("name", "emp");
            select.AddField("dept", "dept");
            Console.WriteLine(select.ToString());
            

            Console.ReadKey();
        }

        private static void TestComplexClauseNoJoin()
        {
            ComplexFromClause from = new ComplexFromClause();
            NoJoin join = new NoJoin(new TableAlias("emp", "a"), new TableAlias("dept", "b"));
            from.AddJoin(join);
            Console.WriteLine(from.ToString());
        }

        private static void TestComplexClause()
        {
            ComplexFromClause from = new ComplexFromClause();
            InnerJoin join = new InnerJoin(new TableAlias("emp", "a"), new TableAlias("dept", "b"), "a.dept", "b.dept");
            from.AddJoin(join);
            Console.WriteLine(from.ToString());
        }

        private static void TestDBAccess()
        {
            //var query = new AccessDatabase("C:\\Plymouth\\CommunityNurse.accdb");

            //var select = new BasicSelectStatement("CommunityNurseRecords");
            //select.AddField("Easting");
            //select.AddField("Northing");
            //select.AddField("Team");
            //select.AddField("GP_Practice");

            ////note access uses american format dates.
            //var betweenClause = new BetweenDatesClause("Date") { fromDate = "08/01/2011", toDate = "08/02/2011" };
            //var dateClause = new DateClause("Date") { Date = "08/01/2011" };

            //var builder = new QueryBuilder(select);
            //builder.AddRestrict(dateClause);

            //DataTable results = query.ExecuteQuery(builder.BuildSQL());

            //ExcelWorkBookAdaptor wbk = new ExcelWorkBookAdaptor();
            //wbk.NewBook();

            //DataTableToExcelAdaptor pipe = new DataTableToExcelAdaptor(wbk[0], results);
            //pipe.Write(new Point(1, 1));

            //wbk.Show();

            //Console.WriteLine(results.Rows.Count);
        }



    }
}
