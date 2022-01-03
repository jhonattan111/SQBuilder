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
		/// O numero de elementos a ser tragos na query
		/// </summary>
		/// <param name="content"></param>
		public SQLBuilder Top(int top)
		{
			_top = top;

			return this;
		}
	}
}
