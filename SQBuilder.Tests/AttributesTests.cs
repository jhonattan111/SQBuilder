using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQBuilder.Tests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQBuilder.Tests
{
    [TestClass]
    public class AttributesTests
    {
        [TestMethod]
        public void SimpleSelectT()
        {
            var query = new SQLBuilder()
                            .Select<Company>()
                            .From("dbo.Table1 P")
                            .Where("");

            Assert.AreEqual("SELECT Id, Name, Adress " +
                            "FROM dbo.Table1 P", query.ToString());
        }

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
    }
}
