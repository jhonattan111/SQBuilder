using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQBuilder.Tests
{
    [TestClass]
    public class TopTests
    {
        [TestMethod]
        public void SelectTop()
        {
            var query = new SQLBuilder()
                            .Select("P.Id, P.Name")
                            .Top(10)
                            .From("dbo.Product P");

            Assert.AreEqual("SELECT TOP 10 P.Id, P.Name " +
                            "FROM dbo.Product P", query.ToString());
        }
    }
}
