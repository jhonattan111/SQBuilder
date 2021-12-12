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
		/// Adicione apenas o nome da coluna, a classe adiciona a instrução ORDER BY
		/// </summary>
		/// <param name="content"></param>
		public SQBuilder OrderBy(string content)
		{
			_orderBy.Add(content);

			return this;
		}
	}
}
