using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQBuilder
{
	public partial class SQBuilder
	{
		/// <summary>
		/// Adicione apenas o nome da tabela, a classe adiciona a instrução GROUP BY
		/// </summary>
		/// <param name="content"></param>
		public SQBuilder GroupBy(string content)
		{
			_groupBy.Add(content);

			return this;
		}
	}
}
