using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQBuilder.Providers.SqlServer;

namespace SQBuilder.Tests
{
    [TestClass]
    public class TopTests
    {
        [TestMethod]
        public void SelectTop()
        {
            IScriptBuilder query = new SqlServerScriptBuilder()
                            .Select("P.Id, P.Name")
                            .Top(10)
                            .From("dbo.Product P");

            Assert.AreEqual("SELECT TOP 10 P.Id, P.Name " +
                            "FROM dbo.Product P", query.ToScript());
        }
    }
}
