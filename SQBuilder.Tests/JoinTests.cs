using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQBuilder.Tests
{
    [TestClass]
    public class JoinTests
    {
        [TestMethod]
        public void SimpleInnerJoin()
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

        [TestMethod]
        public void SimpleLeftJoin()
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

        [TestMethod]
        public void SimpleRightJoin()
        {
            var query = new SQLBuilder()
                            .Select("P.Id")
                            .Select("P.Column1")
                            .From("dbo.Table1 P")
                            .RightJoin("dbo.Table2 C ON C.Id = P.ColumnId");

            Assert.AreEqual("SELECT P.Id, P.Column1 " +
                            "FROM dbo.Table1 P " +
                            "RIGHT JOIN dbo.Table2 C ON C.Id = P.ColumnId", query.ToString());
        }

        [TestMethod]
        public void JoinOrderPositions()
        {
            var query = new SQLBuilder()
                                .Select("T1.*")
                                .From("dbo.Table1 T1")
                                .LeftJoin("dbo.Table2 T2 ON T1.Id = T2.T1Id")
                                .InnerJoin("dbo.Table3 T3 ON T2.Id = T3.T2Id")
                                .LeftJoin("dbo.Table4 T4 ON T3.Id = T4.T3Id")
                                .RightJoin("dbo.Table5 T5 ON T4.Id = T5.T4Id")
                                .Where("T1.Id = 1");

            Assert.AreEqual("SELECT T1.* " +
                            "FROM dbo.Table1 T1 " +
                            "LEFT JOIN dbo.Table2 T2 ON T1.Id = T2.T1Id " +
                            "INNER JOIN dbo.Table3 T3 ON T2.Id = T3.T2Id " +
                            "LEFT JOIN dbo.Table4 T4 ON T3.Id = T4.T3Id " +
                            "RIGHT JOIN dbo.Table5 T5 ON T4.Id = T5.T4Id " +
                            "WHERE T1.Id = 1", query.ToString());
        }
    }
}
