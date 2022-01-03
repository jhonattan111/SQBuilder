using System;
using System.Collections.Generic;
using System.Reflection;

namespace SQBuilder
{
    public partial class SQLBuilder
    {
		/// <summary>
		/// Adicione apenas as colunas, a classe adiciona a instrução SELECT
		/// </summary>
		/// <param name="content"></param>
		public SQLBuilder Select(string content)
		{
			_select.AddContent(content);

			return this;
		}

		/// <summary>
		/// Adicione uma lista de colunas, a classe adiciona a instrução SELECT
		/// </summary>
		/// <param name="content"></param>
		public SQLBuilder Select(List<string> content)
		{
			foreach(var field in content)
				_select.AddContent(field);

			return this;
		}

		/// <summary>
		/// O Select<typeparamref name="T"/> foi pensado para construir a query baseada nas propriedades do seu objeto, o parâmetro que vc precisa passar é a coluna que ele está contido
		/// </summary>
		/// <param name="content"></param>
		public SQLBuilder Select<T>(string table = "") where T : class
        {
			var query = Activator.CreateInstance<T>();

			var content = query.ReadFields(table);

			foreach (var field in content)
				_select.AddContent(field);
			
			return this;
        }

	}
}
