using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQBuilder.Tests
{
    [TestClass]
    public class UnionTests
    {
        [TestMethod]
        public void SelectUnion()
        {
            var query = new SQLBuilder()
                                .Select("P.Id, P.Name")
                                .From("dbo.Table1 P")
                                .Union()
                                .Select("T.Id, T.Name")
                                .From("dbo.Table2 T");

            Assert.AreEqual("SELECT P.Id, P.Name " +
                            "FROM dbo.Table1 P " +
                            "UNION " +
                            "SELECT T.Id, T.Name " +
                            "FROM dbo.Table2 T", query.ToString());
        }

        [TestMethod]
        public void SelectUnionOrderBy()
        {
            var query = new SQLBuilder()
                                .Select("P.Id, P.Name")
                                .From("dbo.Table1 P")
                                .Union()
                                .Select("T.Id, T.Name")
                                .From("dbo.Table2 T")
                                .OrderBy("T.Id DESC");

            Assert.AreEqual("SELECT P.Id, P.Name " +
                            "FROM dbo.Table1 P " +
                            "UNION " +
                            "SELECT T.Id, T.Name " +
                            "FROM dbo.Table2 T " +
                            "ORDER BY T.Id DESC", query.ToString());
        }

        [TestMethod]
        public void Select2Union()
        {
            var query = new SQLBuilder()
                                .Select("P.Id, P.Name")
                                .From("dbo.Table1 P")
                                .Union()
                                .Select("T.Id, T.Name")
                                .From("dbo.Table2 T")
                                .Union()
                                .Select("C.Id, C.Name")
                                .From("dbo.Table3 C");

            Assert.AreEqual("SELECT P.Id, P.Name " +
                            "FROM dbo.Table1 P " +
                            "UNION " +
                            "SELECT T.Id, T.Name " +
                            "FROM dbo.Table2 T " +
                            "UNION " +
                            "SELECT C.Id, C.Name " +
                            "FROM dbo.Table3 C", query.ToString());
        }

        [TestMethod]
        public void SelectUnionAll()
        {
            var query = new SQLBuilder()
                                .Select("P.Id, P.Name")
                                .From("dbo.Table1 P")
                                .UnionAll()
                                .Select("T.Id, T.Name")
                                .From("dbo.Table2 T");

            Assert.AreEqual("SELECT P.Id, P.Name " +
                            "FROM dbo.Table1 P " +
                            "UNION ALL " +
                            "SELECT T.Id, T.Name " +
                            "FROM dbo.Table2 T", query.ToString());
        }

        [TestMethod]
        public void Select2UnionAll()
        {
            var query = new SQLBuilder()
                                .Select("P.Id, P.Name")
                                .From("dbo.Table1 P")
                                .UnionAll()
                                .Select("T.Id, T.Name")
                                .From("dbo.Table2 T")
                                .UnionAll()
                                .Select("C.Id, C.Name")
                                .From("dbo.Table3 C");

            Assert.AreEqual("SELECT P.Id, P.Name " +
                            "FROM dbo.Table1 P " +
                            "UNION ALL " +
                            "SELECT T.Id, T.Name " +
                            "FROM dbo.Table2 T " +
                            "UNION ALL " +
                            "SELECT C.Id, C.Name " +
                            "FROM dbo.Table3 C", query.ToString());
        }

        [TestMethod]
        public void SelectUnionAndUnionAll()
        {
            var query = new SQLBuilder()
                                .Select("P.Id, P.Name")
                                .From("dbo.Table1 P")
                                .UnionAll()
                                .Select("T.Id, T.Name")
                                .From("dbo.Table2 T")
                                .Union()
                                .Select("C.Id, C.Name")
                                .From("dbo.Table3 C");

            Assert.AreEqual("SELECT P.Id, P.Name " +
                            "FROM dbo.Table1 P " +
                            "UNION ALL " +
                            "SELECT T.Id, T.Name " +
                            "FROM dbo.Table2 T " +
                            "UNION " +
                            "SELECT C.Id, C.Name " +
                            "FROM dbo.Table3 C", query.ToString());
        }
    }
}
