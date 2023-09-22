using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQBuilder.Providers.SqlServer;

namespace SQBuilder.Tests
{
    [TestClass]
    public class Select
    {
        [TestMethod]
        public void SelectFromWhere()
        {
            IScriptBuilder query = new SqlServerScriptBuilder()
                                .Select("*")
                                .From("dbo.Table1")
                                .Where("Id = 1");

            Assert.AreEqual("SELECT * " +
                            "FROM dbo.Table1 " +
                            "WHERE Id = 1", query.ToScript());
        }

        [TestMethod]
        public void SelectFromWhereConditional()
        {
            bool condition = false;

            IScriptBuilder query = new SqlServerScriptBuilder()
                                .Select("*")
                                .From("dbo.Table1")
                                .Where("Id = 1", condition);

            Assert.AreEqual("SELECT * " +
                            "FROM dbo.Table1", query.ToScript());
        }

        [TestMethod]
        public void SelectFrom()
        {
            IScriptBuilder query = new SqlServerScriptBuilder()
                                .Select("P.Id")
                                .Select("P.Column1")
                                .From("dbo.Table1 P");

            Assert.AreEqual("SELECT P.Id, P.Column1 " +
                            "FROM dbo.Table1 P", query.ToScript());
        }

        [TestMethod]
        public void SelectFromWhereGroupBy()
        {
            IScriptBuilder query = new SqlServerScriptBuilder()
                                .Select("P.Date, SUM(P.Value)")
                                .From("dbo.Table1 P")
                                .Where("P.Id = 1")
                                .GroupBy("P.Date");

            Assert.AreEqual("SELECT P.Date, SUM(P.Value) " +
                            "FROM dbo.Table1 P " +
                            "WHERE P.Id = 1 " +
                            "GROUP BY P.Date", query.ToScript());
        }

        [TestMethod]
        public void SelectFromWhereGroupByOrderBy()
        {
            IScriptBuilder query = new SqlServerScriptBuilder()
                                .Select("P.Date, SUM(P.Value)")
                                .From("dbo.Table1 P")
                                .Where("P.Id = 1")
                                .GroupBy("P.Date")
                                .OrderBy("P.Date DESC");

            Assert.AreEqual("SELECT P.Date, SUM(P.Value) " +
                            "FROM dbo.Table1 P " +
                            "WHERE P.Id = 1 " +
                            "GROUP BY P.Date " +
                            "ORDER BY P.Date DESC", query.ToScript());
        }

        [TestMethod]
        public void SelectFromOrderBy()
        {
            IScriptBuilder query = new SqlServerScriptBuilder()
                                .Select("P.Date, P.Id")
                                .From("dbo.Table1 P")
                                .OrderBy("P.Date DESC");

            Assert.AreEqual("SELECT P.Date, P.Id " +
                            "FROM dbo.Table1 P " +
                            "ORDER BY P.Date DESC", query.ToScript());
        }

        [TestMethod]
        public void SelectWithoutWhere()
        {
            IScriptBuilder query = new SqlServerScriptBuilder()
                            .Select("*")
                            .From("dbo.Table1 P")
                            .Where("");

            Assert.AreEqual("SELECT * " +
                            "FROM dbo.Table1 P", query.ToScript());
        }
    }
}
