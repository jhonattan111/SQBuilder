using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SQBuilder.Tests
{
    [TestClass]
    internal class JoinTests
    {
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
                            "FROM dbo.Table1 " +
                            "LEFT JOIN dbo.Table2 T2 ON T1.Id = T2.T1Id " +
                            "INNER JOIN dbo.Table3 T3 ON T2.Id = T3.T2Id " +
                            "LEFT JOIN dbo.Table4 T4 ON T3.Id = T4.T3Id "+
                            "WHERE T1.Id = 1", query.ToString());
        }
    }
}
