/* 
 * MIT License
 * 
 * Copyright (c) 2023 - Jhonattan Alves
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 * 
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQBuilder.Providers.SqlServer;

namespace SQBuilder.Tests
{
    [TestClass]
    public class UnionTests
    {
        [TestMethod]
        public void SelectUnion()
        {
            IScriptBuilder query = new SqlServerScriptBuilder()
                                .Select("P.Id, P.Name")
                                .From("dbo.Table1 P")
                                .Union()
                                .Select("T.Id, T.Name")
                                .From("dbo.Table2 T");

            Assert.AreEqual("SELECT P.Id, P.Name " +
                            "FROM dbo.Table1 P " +
                            "UNION " +
                            "SELECT T.Id, T.Name " +
                            "FROM dbo.Table2 T", query.ToScript());
        }

        [TestMethod]
        public void SelectUnionOrderBy()
        {
            IScriptBuilder query = new SqlServerScriptBuilder()
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
                            "ORDER BY T.Id DESC", query.ToScript());
        }

        [TestMethod]
        public void Select2Union()
        {
            IScriptBuilder query = new SqlServerScriptBuilder()
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
                            "FROM dbo.Table3 C", query.ToScript());
        }

        [TestMethod]
        public void SelectUnionAll()
        {
            IScriptBuilder query = new SqlServerScriptBuilder()
                                .Select("P.Id, P.Name")
                                .From("dbo.Table1 P")
                                .UnionAll()
                                .Select("T.Id, T.Name")
                                .From("dbo.Table2 T");

            Assert.AreEqual("SELECT P.Id, P.Name " +
                            "FROM dbo.Table1 P " +
                            "UNION ALL " +
                            "SELECT T.Id, T.Name " +
                            "FROM dbo.Table2 T", query.ToScript());
        }

        [TestMethod]
        public void Select2UnionAll()
        {
            IScriptBuilder query = new SqlServerScriptBuilder()
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
                            "FROM dbo.Table3 C", query.ToScript());
        }

        [TestMethod]
        public void SelectUnionAndUnionAll()
        {
            IScriptBuilder query = new SqlServerScriptBuilder()
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
                            "FROM dbo.Table3 C", query.ToScript());
        }
    }
}
