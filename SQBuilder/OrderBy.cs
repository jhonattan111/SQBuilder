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
		/// Adicione apenas o nome da coluna, a classe adiciona a instrução ORDER BY
		/// </summary>
		/// <param name="content"></param>
		public SQLBuilder OrderBy(string content)
		{
			AddContent(_orderBy, content);

			return this;
		}
	}
}
