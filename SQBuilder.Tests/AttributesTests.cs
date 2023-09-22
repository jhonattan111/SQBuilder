using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQBuilder.Providers.SqlServer;
using SQBuilder.Tests.Models;

namespace SQBuilder.Tests
{
    [TestClass]
    public class AttributesTests
    {
        [TestMethod]
        public void SimpleSelectT()
        {
            IScriptBuilder query = new SqlServerScriptBuilder()
                            .Select<Company>()
                            .From("dbo.Table1 P")
                            .Where("");

            Assert.AreEqual("SELECT Id, Name, Adress " +
                            "FROM dbo.Table1 P", query.ToScript());
        }

        [TestMethod]
        public void Select2TWithouArgument()
        {
            IScriptBuilder query = new SqlServerScriptBuilder()
                            .Select<Company>()
                            .Select<Employee>("E")
                            .From("dbo.Table1 P")
                            .LeftJoin("dbo.Employee E");

            Assert.AreEqual("SELECT Id, Name, Adress, E.i_employee AS Id, E.name_emp AS Name " +
                            "FROM dbo.Table1 P " +
                            "LEFT JOIN dbo.Employee E", query.ToScript());
        }

        [TestMethod]
        public void SelectTCustomColumnName()
        {
            IScriptBuilder query = new SqlServerScriptBuilder()
                            .Select<Employee>("E")
                            .From("dbo.Employee E");

            Assert.AreEqual("SELECT E.i_employee AS Id, E.name_emp AS Name " +
                            "FROM dbo.Employee E", query.ToScript());
        }
    }
}
