
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQBuilder.Providers.SqlServer;
using System.Collections.Generic;

namespace SQBuilder.Tests
{
    [TestClass]
    public class FromTests
    {
        [TestMethod]
        public void SelectMultipleFrom()
        {
            IScriptBuilder query = new SqlServerScriptBuilder()
                                .Select("*")
                                .From("dbo.Table1 P")
                                .From("dbo.Table2 P2");

            Assert.AreEqual("SELECT * " +
                            "FROM dbo.Table1 P, " +
                            "dbo.Table2 P2", query.ToScript()); 
        }

        [TestMethod]
        public void SelectFromWhereInInt()
        {
            List<int> ids = new() { 1, 2, 3, 4, 5, 6, 7 };
            IScriptBuilder query = new SqlServerScriptBuilder()
                                .Select("*")
                                .From("dbo.Table1 P")
                                .Where(ids, "P.Id");

            Assert.AreEqual("SELECT * " +
                            "FROM dbo.Table1 P " +
                            "WHERE P.Id IN ('1', '2', '3', '4', '5', '6', '7')", query.ToScript());
        }

        [TestMethod]
        public void SelectFromWhereInStringConditional()
        {
            bool condition = false;

            List<string> ids = new() { "1", "2", "3", "4", "5", "6", "7" };
            IScriptBuilder query = new SqlServerScriptBuilder()
                                .Select("*")
                                .From("dbo.Table1 P")
                                .Where(ids, "P.Id", condition);

            Assert.AreEqual("SELECT * " +
                            "FROM dbo.Table1 P", query.ToScript());
        }

        [TestMethod]
        public void SelectFromWhereInIntConditional()
        {
            bool condition = false;
            List<int> ids = new() { 1, 2, 3, 4, 5, 6, 7 };
            IScriptBuilder query = new SqlServerScriptBuilder()
                                .Select("*")
                                .From("dbo.Table1 P")
                                .Where(ids, "P.Id", condition);

            Assert.AreEqual("SELECT * " +
                            "FROM dbo.Table1 P", query.ToScript());
        }

    }
}
