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
		/// Adicione apenas o nome da tabela e referência ON, a classe adiciona a instrução LEFT JOIN
		/// </summary>
		/// <param name="content"></param>
		public SQBuilder LeftJoin(string content)
		{
			_leftJoin.Add(content);

			return this;
		}
	}
}
