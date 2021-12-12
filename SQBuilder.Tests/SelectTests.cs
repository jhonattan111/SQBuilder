using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var query = new SQBuilder()
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

            var query = new SQBuilder()
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
            var query = new SQBuilder()
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
            var query = new SQBuilder()
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
            var query = new SQBuilder()
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
            var query = new SQBuilder()
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
            var query = new SQBuilder()
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
            var query = new SQBuilder()
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
            var query = new SQBuilder()
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
            var query = new SQBuilder()
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
            var query = new SQBuilder()
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
            var query = new SQBuilder()
                                .Select("P.Date, P.Id")
                                .From("dbo.Table1 P")
                                .OrderBy("P.Date DESC");

            Assert.AreEqual("SELECT P.Date, P.Id " +
                            "FROM dbo.Table1 P " +
                            "ORDER BY P.Date DESC", query.ToString());
        }
    }
}
