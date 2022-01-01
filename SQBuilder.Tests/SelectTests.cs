using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQBuilder.Tests.Models;
using System.Collections.Generic;

namespace SQBuilder.Tests
{
    [TestClass]
    public class Select
    {
        [TestCategory("Select")]
        [TestCategory("From")]
        [TestCategory("Where")]
        [TestMethod]
        public void SelectFromWhere()
        {
            var query = new SQLBuilder()
                                .Select("*")
                                .From("dbo.Table1")
                                .Where("Id = 1");

            Assert.AreEqual("SELECT * " +
                            "FROM dbo.Table1 " +
                            "WHERE Id = 1", query.ToString());
        }

        [TestCategory("Select")]
        [TestCategory("From")]
        [TestCategory("WhereConditional")]
        [TestMethod]
        public void SelectFromWhereConditional()
        {
            var condition = false;

            var query = new SQLBuilder()
                                .Select("*")
                                .From("dbo.Table1")
                                .Where("Id = 1", condition);

            Assert.AreEqual("SELECT * " +
                            "FROM dbo.Table1", query.ToString());
        }

        [TestCategory("Select")]
        [TestCategory("From")]
        [TestMethod]
        public void SelectFrom()
        {
            var query = new SQLBuilder()
                                .Select("P.Id")
                                .Select("P.Column1")
                                .From("dbo.Table1 P");

            Assert.AreEqual("SELECT P.Id, P.Column1 " +
                            "FROM dbo.Table1 P", query.ToString());
        }

        [TestCategory("Select")]
        [TestCategory("From")]
        [TestCategory("InnerJoin")]
        [TestCategory("Where")]
        [TestMethod]
        public void SelectFromInnerJoinWhere()
        {
            var query = new SQLBuilder()
                                .Select("P.Id")
                                .Select("P.Column1")
                                .From("dbo.Table1 P")
                                .InnerJoin("dbo.Table2 C ON C.Id = P.ColumnId");

            Assert.AreEqual("SELECT P.Id, P.Column1 " +
                            "FROM dbo.Table1 P " +
                            "INNER JOIN dbo.Table2 C ON C.Id = P.ColumnId", query.ToString());
        }

        [TestCategory("Select")]
        [TestCategory("From")]
        [TestCategory("leftJoin")]
        [TestCategory("Where")]
        [TestMethod]
        public void SelectFromLeftJoinWhere()
        {
            var query = new SQLBuilder()
                                .Select("P.Id")
                                .Select("P.Column1")
                                .From("dbo.Table1 P")
                                .LeftJoin("dbo.Table2 C ON C.Id = P.ColumnId");

            Assert.AreEqual("SELECT P.Id, P.Column1 " +
                            "FROM dbo.Table1 P " +
                            "LEFT JOIN dbo.Table2 C ON C.Id = P.ColumnId", query.ToString());
        }

        [TestCategory("Select")]
        [TestCategory("From")]
        [TestCategory("WhereIn")]
        [TestMethod]
        public void SelectFromWhereInString()
        {
            List<string> ids = new List<string>() { "1", "2", "3", "4", "5", "6", "7" };
            var query = new SQLBuilder()
                                .Select("*")
                                .From("dbo.Table1 P")
                                .Where(ids, "P.Id");

            Assert.AreEqual("SELECT * " +
                            "FROM dbo.Table1 P " +
                            "WHERE P.Id IN ('1', '2', '3', '4', '5', '6', '7')", query.ToString());
        }

        [TestCategory("Select")]
        [TestCategory("From")]
        [TestCategory("WhereIn")]
        [TestMethod]
        public void SelectFromWhereInInt()
        {
            List<int> ids = new List<int>() { 1, 2, 3, 4, 5, 6, 7};
            var query = new SQLBuilder()
                                .Select("*")
                                .From("dbo.Table1 P")
                                .Where(ids, "P.Id");

            Assert.AreEqual("SELECT * " +
                            "FROM dbo.Table1 P " +
                            "WHERE P.Id IN ('1', '2', '3', '4', '5', '6', '7')", query.ToString());
        }

        [TestCategory("Select")]
        [TestCategory("From")]
        [TestCategory("WhereInConditional")]
        [TestMethod]
        public void SelectFromWhereInStringConditional()
        {
            var condition = false;

            List<string> ids = new List<string>() { "1", "2", "3", "4", "5", "6", "7" };
            var query = new SQLBuilder()
                                .Select("*")
                                .From("dbo.Table1 P")
                                .Where(ids, "P.Id", condition);

            Assert.AreEqual("SELECT * " +
                            "FROM dbo.Table1 P", query.ToString());
        }

        [TestCategory("Select")]
        [TestCategory("From")]
        [TestCategory("WhereInConditional")]
        [TestMethod]
        public void SelectFromWhereInIntConditional()
        {
            var condition = false;
            List<int> ids = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            var query = new SQLBuilder()
                                .Select("*")
                                .From("dbo.Table1 P")
                                .Where(ids, "P.Id", condition);

            Assert.AreEqual("SELECT * " +
                            "FROM dbo.Table1 P", query.ToString());
        }

        [TestCategory("Select")]
        [TestCategory("From")]
        [TestCategory("Where")]
        [TestCategory("GroupBy")]
        [TestMethod]
        public void SelectFromWhereGroupBy()
        {
            var query = new SQLBuilder()
                                .Select("P.Date, SUM(P.Value)")
                                .From("dbo.Table1 P")
                                .Where("P.Id = 1")
                                .GroupBy("P.Date");

            Assert.AreEqual("SELECT P.Date, SUM(P.Value) " +
                            "FROM dbo.Table1 P " +
                            "WHERE P.Id = 1 " +
                            "GROUP BY P.Date", query.ToString());
        }

        [TestCategory("Select")]
        [TestCategory("From")]
        [TestCategory("Where")]
        [TestCategory("GroupBy")]
        [TestCategory("OrderBy")]
        [TestMethod]
        public void SelectFromWhereGroupByOrderBy()
        {
            var query = new SQLBuilder()
                                .Select("P.Date, SUM(P.Value)")
                                .From("dbo.Table1 P")
                                .Where("P.Id = 1")
                                .GroupBy("P.Date")
                                .OrderBy("P.Date DESC");

            Assert.AreEqual("SELECT P.Date, SUM(P.Value) " +
                            "FROM dbo.Table1 P " +
                            "WHERE P.Id = 1 " +
                            "GROUP BY P.Date " +
                            "ORDER BY P.Date DESC", query.ToString());
        }

        [TestCategory("Select")]
        [TestCategory("From")]
        [TestCategory("OrderBy")]
        [TestMethod]
        public void SelectFromOrderBy()
        {
            var query = new SQLBuilder()
                                .Select("P.Date, P.Id")
                                .From("dbo.Table1 P")
                                .OrderBy("P.Date DESC");

            Assert.AreEqual("SELECT P.Date, P.Id " +
                            "FROM dbo.Table1 P " +
                            "ORDER BY P.Date DESC", query.ToString());
        }

        [TestCategory("Select")]
        [TestCategory("From")]
        [TestCategory("Where")]
        [TestMethod]
        public void SelectWithoutWhere()
        {
            var query = new SQLBuilder()
                            .Select("*")
                            .From("dbo.Table1 P")
                            .Where("");

            Assert.AreEqual("SELECT * " +
                            "FROM dbo.Table1 P", query.ToString());
        }

        [TestCategory("Select")]
        [TestCategory("Where")]
        [TestMethod]
        public void SelectT()
        {
            var query = new SQLBuilder()
                            .Select<Company>("P")
                            .From("dbo.Table1 P")
                            .Where("");

            Assert.AreEqual("SELECT P.Id, P.Name, P.Adress " +
                            "FROM dbo.Table1 P", query.ToString());
        }

        [TestCategory("Select")]
        [TestCategory("Where")]
        [TestMethod]
        public void SelectTWithouArgument()
        {
            var query = new SQLBuilder()
                            .Select<Company>()
                            .From("dbo.Table1 P")
                            .Where("");

            Assert.AreEqual("SELECT Id, Name, Adress " +
                            "FROM dbo.Table1 P", query.ToString());
        }

        [TestCategory("Select")]
        [TestCategory("Where")]
        [TestMethod]
        public void Select2TWithouArgument()
        {
            var query = new SQLBuilder()
                            .Select<Company>()
                            .Select<Employee>("E")
                            .From("dbo.Table1 P")
                            .LeftJoin("dbo.Employee E")
                            .Where("");

            Assert.AreEqual("SELECT Id, Name, Adress, E.i_employee AS Id, E.name_emp AS Name " +
                            "FROM dbo.Table1 P " +
                            "LEFT JOIN dbo.Employee E", query.ToString());
        }

        [TestCategory("Select")]
        [TestCategory("Where")]
        [TestMethod]
        public void SelectTCustomColumnName()
        {
            var query = new SQLBuilder()
                            .Select<Employee>("E")
                            .From("dbo.Employee E")
                            .Where("");

            Assert.AreEqual("SELECT E.i_employee AS Id, E.name_emp AS Name " +
                            "FROM dbo.Employee E", query.ToString());
        }

        [TestCategory("Select")]
        [TestCategory("From")]
        [TestCategory("Where")]
        [TestCategory("LeftJoin")]
        [TestCategory("InnerJoin")]
        [TestMethod]
        public void JoinOrderPositions()
        {
            var query = new SQLBuilder()
                                .Select("T1.*")
                                .From("dbo.Table1 T1")
                                .LeftJoin("dbo.Table2 T2 ON T1.Id = T2.T1Id")
                                .InnerJoin("dbo.Table3 T3 ON T2.Id = T3.T2Id")
                                .LeftJoin("dbo.Table4 T4 ON T3.Id = T4.T3Id")
                                .Where("T1.Id = 1");

            Assert.AreEqual("SELECT T1.* " +
                            "FROM dbo.Table1 T1 " +
                            "LEFT JOIN dbo.Table2 T2 ON T1.Id = T2.T1Id " +
                            "INNER JOIN dbo.Table3 T3 ON T2.Id = T3.T2Id " +
                            "LEFT JOIN dbo.Table4 T4 ON T3.Id = T4.T3Id " +
                            "WHERE T1.Id = 1", query.ToString());
        }
    }
}
