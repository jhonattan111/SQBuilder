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
		/// Adicione apenas o nome da tabela e referência ON, a classe adiciona a instrução RIGHT JOIN
		/// </summary>
		/// <param name="content"></param>
		public SQLBuilder RightJoin(string content)
		{
			if (!string.IsNullOrWhiteSpace(content))
				_join.AddContent($"RIGHT JOIN {content}");

			return this;
		}
	}
}
