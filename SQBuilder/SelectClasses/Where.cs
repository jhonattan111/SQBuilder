using System.Collections.Generic;
using System.Linq;

namespace SQBuilder
{
    public partial class SQLBuilder
    {
		/// <summary>
		/// Adicione apenas as cláusulas, a classe adiciona a instrução WHERE
		/// </summary>
		/// <param name="content"></param>
		public SQLBuilder Where(string content)
		{
			_where.AddContent(content);

			return this;
		}

		/// <summary>
		/// Adicione apenas as cláusulas e a condição para a inclusão, a classe adiciona a instrução WHERE
		/// </summary>
		/// <param name="content"></param>
		/// <param name="condition"></param>
		public SQLBuilder Where(string content, bool condition)
		{
				_where.AddContent(content, condition);

			return this;
		}

		/// <summary>
		/// Adicione uma lista que será colocada em uma cláusula IN, a classe adiciona a instrução WHERE
		/// </summary>
		/// <param name="content"></param>
		/// <param name="condition"></param>
		public SQLBuilder Where(List<string> content, string column)
		{
			var list = string.Join("', '", content);

			if (content.Count > 0)
				_where.AddContent($"{column} IN ('{list}')");

			return this;
		}

		/// <summary>
		/// Adicione uma lista que será colocada em uma cláusula IN, a classe adiciona a instrução WHERE
		/// </summary>
		/// <param name="content"></param>
		/// <param name="column"></param>
		public SQLBuilder Where(List<int> content, string column)
		{
			var list = content.Select(d => d.ToString()).ToList();

			this.Where(list, column);

			return this;
		}

		/// <summary>
		/// Adicione uma lista que será colocada em uma cláusula IN, a classe adiciona a instrução WHERE
		/// </summary>
		/// <param name="content"></param>
		/// <param name="condition"></param>
		public SQLBuilder Where(List<string> content, string column, bool condition)
		{
			if (condition)
				this.Where(content, column);

			return this;
		}

		/// <summary>
		/// Adicione uma lista que será colocada em uma cláusula IN, a classe adiciona a instrução WHERE
		/// </summary>
		/// <param name="content"></param>
		/// <param name="column"></param>
		/// <param name="condition"></param>
		public SQLBuilder Where(List<int> content, string column, bool condition)
		{
			if (condition)
            {
				var list = content.Select(d => d.ToString()).ToList();

				this.Where(list, column);
			}

			return this;
		}
	}
}
