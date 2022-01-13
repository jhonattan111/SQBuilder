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
		/// Adicione apenas o nome da tabela e referência ON, a classe adiciona a instrução LEFT JOIN
		/// </summary>
		/// <param name="content"></param>
		public SQLBuilder LeftJoin(string content)
		{
			if(!string.IsNullOrWhiteSpace(content))
				_join.AddContent($" LEFT JOIN {content}");

			return this;
		}
	}
}
