using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQBuilder
{
    public partial class SQLBuilder
	{
		/// <summary>
		/// Atribui um conjunto union a query
		/// </summary>
		/// <param name="content"></param>
		public SQLBuilder Union()
		{
			var query = ToString();

			query += " UNION ";

			return new SQLBuilder(query);
		}

		/// <summary>
		/// Atribui um conjunto union all a query
		/// </summary>
		/// <param name="content"></param>
		public SQLBuilder UnionAll()
		{
			var query = ToString();

			query += " UNION ALL ";

			return new SQLBuilder(query);
		}
	}
}
