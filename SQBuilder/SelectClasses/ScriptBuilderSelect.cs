using System;
using System.Collections.Generic;
using System.Reflection;

namespace SQBuilder
{
    public abstract partial class ScriptBuilder : IScriptBuilder
    {
		/// <summary>
		/// Adicione apenas as colunas, a classe adiciona a instrução SELECT
		/// </summary>
		/// <param name="content"></param>
		public IScriptBuilder Select(string content)
		{
			_select.AddContent(content);
			return this;
		}

		/// <summary>
		/// Adicione uma lista de colunas, a classe adiciona a instrução SELECT
		/// </summary>
		/// <param name="content"></param>
		public IScriptBuilder Select(IEnumerable<string> content)
		{
			foreach(var field in content)
				_select.AddContent(field);

			return this;
		}

		/// <summary>
		/// O Select <typeparamref name="TModel"/> foi pensado para construir a query baseada nas propriedades do seu objeto, o parâmetro que vc precisa passar é a coluna que ele está contido
		/// </summary>
		/// <param name="content"></param>
		public IScriptBuilder Select<TModel>(string table = "") where TModel : class
        {	
			var query = Activator.CreateInstance<TModel>();
			var content = query.ReadFields(table);
			foreach (var field in content)
				_select.AddContent(field);
			
			return this;
        }

	}
}
