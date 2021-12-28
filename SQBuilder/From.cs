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
		/// Adicione apenas o nome da tabela, a classe adiciona a instrução FROM
		/// </summary>
		/// <param name="content"></param>
		public SQLBuilder From(string content)
		{
			_from.Add(content);

			return this;
		}
	}
}
