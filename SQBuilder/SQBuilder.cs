using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SQBuilder
{
	public partial class SQBuilder
	{
		private List<string> _select { get; set; }
		private List<string> _from { get; set; }
		private List<string> _where { get; set; }
		private List<string> _leftJoin { get; set; }
		private List<string> _innerJoin { get; set; }
		private List<string> _groupBy { get; set; }
		private List<string> _orderBy { get; set; }
		public SQBuilder()
		{
			_select = new List<string>();
			_from = new List<string>();
			_where = new List<string>();
			_leftJoin = new List<string>();
			_innerJoin = new List<string>();
			_groupBy = new List<string>();
			_orderBy = new List<string>();
		}

        #region Tranformar em uma consulta
        public override string ToString()
		{
			string _query = string.Empty;

			if (_select.Count > 0)
				_query += " SELECT ";

			_query += string.Join(@", ", _select.Where(d => !string.IsNullOrWhiteSpace(d)));

			if (_from.Count > 0)
				foreach (var item in _from)
					_query += $" FROM {item} ";

			if (_innerJoin.Count > 0)
				foreach (var item in _innerJoin)
					_query += $" INNER JOIN {item}";

			if (_leftJoin.Count > 0)
				foreach (var item in _leftJoin)
					_query += $" LEFT JOIN {item}";

			if (_where.Count > 0)
				_query += " WHERE ";

			_query += string.Join(@" AND ", _where.Where(d => !string.IsNullOrWhiteSpace(d)));

			if (_groupBy.Count > 0)
				_query += " GROUP BY ";

			_query += string.Join(@", ", _groupBy.Where(d => !string.IsNullOrWhiteSpace(d)));

			if (_orderBy.Count > 0)
				_query += " ORDER BY ";

			_query += string.Join(@", ", _orderBy.Where(d => !string.IsNullOrWhiteSpace(d)));

			return Regex.Replace(_query, @"\s+", " ", RegexOptions.Multiline).Trim();
		}
		#endregion
	}
}
