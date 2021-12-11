using System.Collections.Generic;
using System.Linq;

namespace SQBuilder
{
    public partial class SQBuilder
    {
		/// <summary>
		/// Adicione apenas as cláusulas, a classe adiciona a instrução WHERE
		/// </summary>
		/// <param name="content"></param>
		public SQBuilder Where(string content)
		{
			_where.Add(content);

			return this;
		}

		/// <summary>
		/// Adicione apenas as cláusulas e a condição para a inclusão, a classe adiciona a instrução WHERE
		/// </summary>
		/// <param name="content"></param>
		/// <param name="condition"></param>
		public SQBuilder Where(string content, bool condition)
		{
			if (condition)
				_where.Add(content);

			return this;
		}

		/// <summary>
		/// Adicione uma lista que será colocada em uma cláusula IN, a classe adiciona a instrução WHERE
		/// </summary>
		/// <param name="content"></param>
		/// <param name="condition"></param>
		public SQBuilder Where(List<string> content, string column)
		{
			string list = string.Join("', '", content);

			if (content.Count > 0)
				_where.Add($"{column} IN ('{list}')");

			return this;
		}

		/// <summary>
		/// Adicione uma lista que será colocada em uma cláusula IN, a classe adiciona a instrução WHERE
		/// </summary>
		/// <param name="content"></param>
		/// <param name="condition"></param>
		public SQBuilder Where(List<int> content, string column)
		{
			var list = content.Select(d => d.ToString()).ToList();

			return this.Where(list, column);
		}
	}
}
