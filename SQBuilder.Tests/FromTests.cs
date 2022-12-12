
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace SQBuilder.Tests
{
    [TestClass]
    public class FromTests
    {
        [TestMethod]
        public void SelectMultipleFrom()
        {
            var query = new SQLBuilder()
                                .Select("*")
                                .From("dbo.Table1 P")
                                .From("dbo.Table2 P2");

            Assert.AreEqual("SELECT * " +
                            "FROM dbo.Table1 P, " +
                            "dbo.Table2 P2", query.ToString()); 
        }

        [TestMethod]
        public void SelectFromWhereInInt()
        {
            List<int> ids = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            var query = new SQLBuilder()
                                .Select("*")
                                .From("dbo.Table1 P")
                                .Where(ids, "P.Id");

            Assert.AreEqual("SELECT * " +
                            "FROM dbo.Table1 P " +
                            "WHERE P.Id IN ('1', '2', '3', '4', '5', '6', '7')", query.ToString());
        }

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

    }
}
