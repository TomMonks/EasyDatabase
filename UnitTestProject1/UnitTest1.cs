using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using EasyDatabase.SQL;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestComplexFromClauseNoJoin()
        {
            string expected = "FROM emp AS a, dept AS b";

            ComplexFromClause from = new ComplexFromClause();
            NoJoin join = new NoJoin(new TableAlias("emp", "a"), new TableAlias("dept", "b"));
            from.AddJoin(join);
           
            Assert.AreEqual(expected.ToLower(), from.ToString().ToLower());
        }

        [TestMethod]
        public void TestComplexFromClauseWithInnerJoin()
        {
            string expected = "FROM emp AS a INNER JOIN dept AS b ON a.dept=b.dept";

            ComplexFromClause from = new ComplexFromClause();
            InnerJoin join = new InnerJoin(new TableAlias("emp", "a"), new TableAlias("dept", "b"), "a.dept", "b.dept");
            from.AddJoin(join);

            Assert.AreEqual(expected.ToLower(), from.ToString().ToLower());
        }


        [TestMethod]
        public void TestComplexSelect()
        {
            string expected = "SELECT a.empid, a.name, b.dept";

            ComplexSelectStatment select = new ComplexSelectStatment();
            select.AddTable("emp");
            select.AddTable("dept");
            select.AddField("empid", "emp");
            select.AddField("name", "emp");
            select.AddField("dept", "dept");

            
            Assert.AreEqual(expected.ToLower(), select.ToString().ToLower());
        }


        [TestMethod]
        public void TestSimpleFromClause()
        {
            string expected = "FROM emp";

            var from = new SimpleFromClause("emp");
           
            Assert.AreEqual(expected.ToLower(), from.ToString().ToLower());
        }


        [TestMethod]
        public void TestSimpleSelectSpecifiedFields()
        {
            string expected = "Select emp, dept";

            var select = new BasicSelectStatement();
            select.AddField("emp");
            select.AddField("dept");

            Assert.AreEqual(expected.ToLower(), select.ToString().ToLower());
        }

        [TestMethod]
        public void TestSimpleSelectOneSpecifiedField()
        {
            string expected = "Select emp";

            var select = new BasicSelectStatement();
            select.AddField("emp");
            
            Assert.AreEqual(expected.ToLower(), select.ToString().ToLower());
        }

        [TestMethod]
        public void TestSimpleSelectNoSpecifiedFields()
        {
            string expected = "Select *";

            var select = new BasicSelectStatement();
            
            Assert.AreEqual(expected.ToLower(), select.ToString().ToLower());
        }


       
        //public void TestQueryBuilderBasic()
        //{
        //    string expected = "Select emp, dept from emp";

        //    var select = new BasicSelectStatement();
        //    select.AddField("emp");
        //    select.AddField("dept");
        //    var from = new SimpleFromClause("emp");

        //    var builder = new StandardQueryBuilder(select, from);

        //    Assert.AreEqual(expected.ToLower(), builder.BuildSQL().ToLower());
        //}

        [TestMethod]
        public void TestComplexSelectGetFieldName()
        {
            string expected = "a.dept";

            ComplexSelectStatment select = new ComplexSelectStatment();
            select.AddTable("emp");
            select.AddField("dept", "emp");
            
            Assert.AreEqual(expected.ToLower(), select.GetSQLFormatFieldName("dept").ToLower());
        }
        
    }
}
