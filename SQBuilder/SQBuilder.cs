using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SQBuilder
{
	public partial class SQLBuilder
	{
		private string _query { get; set; }
		private List<string> _select { get; set; }
		private List<string> _from { get; set; }
		private List<string> _where { get; set; }
		private List<string> _join { get; set; }
		private List<string> _groupBy { get; set; }
		private List<string> _orderBy { get; set; }
		private List<string> _having { get; set; }
		private int _top { get; set; }
		public SQLBuilder()
		{
			_select = new List<string>();
			_from = new List<string>();
			_where = new List<string>();
			_join = new List<string>();
			_groupBy = new List<string>();
			_orderBy = new List<string>();
		}

        #region Tranformar em uma consulta
        public override string ToString()
		{
			_query = string.Empty;

			AssemblySelect();
			AssemblyFrom();
			AssemblyJoin();
			AssemblyWhere();
			AssemblyGroupBy();
			AssemblyOrderBy();
			AssemblyHaving();

			return Regex.Replace(_query, @"\s+", " ", RegexOptions.Multiline).Trim();
		}
		#endregion

		public void AssemblySelect()
        {
			if (_select.Count > 0)
				_query += " SELECT ";

			if (_top > 0)
				_query += $"TOP {_top}";

			_query += string.Join(@", ", _select.Where(d => !string.IsNullOrWhiteSpace(d)));
		}

		public void AssemblyFrom()
		{
			if (_from.Count > 0)
				foreach (var item in _from)
					_query += $" FROM {item} ";
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

			_query += string.Join(@" AND ", _where.Where(d => !string.IsNullOrWhiteSpace(d)));
		}
	}
}
