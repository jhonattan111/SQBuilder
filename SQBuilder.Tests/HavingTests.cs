using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQBuilder.Tests
{
    [TestClass]
    public class HavingTests
    {
        [TestMethod]
        public void SimpleHaving()
        {
            var query = new SQLBuilder()
                            .Select("O.Date, SUM(O.Revenue")
                            .From("dbo.Order O")
                            .GroupBy("O.Date")
                            .OrderBy("O.Date DESC")
                            .Having("SUM(O.Revenue)");

            Assert.AreEqual("SELECT O.Date, SUM(O.Revenue " +
                            "FROM dbo.Order O " +
                            "GROUP BY O.Date " +
                            "HAVING SUM(O.Revenue) " +
                            "ORDER BY O.Date DESC", query.ToString());
        }
    }
}
