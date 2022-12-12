using System.Linq;
using System.Text.RegularExpressions;

namespace SQBuilder.Providers.SqlServer
{
    public partial class SqlServerScriptBuilder : ScriptBuilder
    {
        public virtual string ToScript()
        {
            _query = string.Empty;

            AssemblyUnion();
            AssemblySelect();
            AssemblyFrom();
            AssemblyJoin();
            AssemblyWhere();
            AssemblyGroupBy();
            AssemblyHaving();
            AssemblyOrderBy();

            return Regex.Replace(_query, @"\s+", " ", RegexOptions.Multiline).Trim();
        }

        public override void AssemblyUnion()
        {
            if (_queries.Count > 0)
                _query += string.Join(@" ", _queries.Where(d => !string.IsNullOrWhiteSpace(d)));
        }

        public void AssemblySelect()
        {
            if (_select.Count > 0)
                _query += " SELECT ";

            if (_top > 0)
                _query += $" TOP {_top} ";

            _query += string.Join(@", ", _select.Where(d => !string.IsNullOrWhiteSpace(d)));
        }

        public void AssemblyFrom()
        {
            if (_select.Count > 0)
                _query += " FROM ";

            _query += string.Join(@", ", _from.Where(d => !string.IsNullOrWhiteSpace(d)));
        }

        public void AssemblyJoin()
        {
            if (_join.Count > 0)
                foreach (var item in _join)
                    _query += $"{item} ";
        }

        public void AssemblyWhere()
        {
            if (_where.Count > 0)
                _query += " WHERE ";

            _query += string.Join(@" AND ", _where.Where(d => !string.IsNullOrWhiteSpace(d)));
        }

        public void AssemblyGroupBy()
        {
            if (_groupBy.Count > 0)
                _query += " GROUP BY ";

            _query += string.Join(@", ", _groupBy.Where(d => !string.IsNullOrWhiteSpace(d)));
        }

        public void AssemblyOrderBy()
        {
            if (_orderBy.Count > 0)
                _query += " ORDER BY ";

            _query += string.Join(@", ", _orderBy.Where(d => !string.IsNullOrWhiteSpace(d)));
        }

        public void AssemblyHaving()
        {
            if (_having.Count > 0)
                _query += " HAVING ";

            _query += string.Join(@" AND ", _having.Where(d => !string.IsNullOrWhiteSpace(d)));
        }
    }
}
