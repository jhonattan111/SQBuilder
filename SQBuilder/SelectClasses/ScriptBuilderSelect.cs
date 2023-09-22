using System;
using System.Collections.Generic;

namespace SQBuilder
{
    public abstract partial class ScriptBuilder : IScriptBuilder
    {
		/// <summary>
		/// Adicione apenas as colunas, a classe adiciona a instrução SELECT
		/// </summary>
		/// <param name="content"></param>
		public virtual IScriptBuilder Select(string content)
		{
			_select.AddContent(content);
			return this;
		}

		/// <summary>
		/// Adicione uma lista de colunas, a classe adiciona a instrução SELECT
		/// </summary>
		/// <param name="content"></param>
		public virtual IScriptBuilder Select(IEnumerable<string> content)
		{
			foreach(string field in content)
				_select.AddContent(field);

			return this;
		}

		/// <summary>
		/// O Select <typeparamref name="TModel"/> foi pensado para construir a query baseada nas propriedades do seu objeto, o parâmetro que vc precisa passar é a coluna que ele está contido
		/// </summary>
		/// <param name="content"></param>
		public IScriptBuilder Select<TModel>(string table = "") where TModel : class
        {	
			TModel query = Activator.CreateInstance<TModel>();
            List<string> content = query.ReadFields(table);
			foreach (string field in content)
				_select.AddContent(field);
			
			return this;
        }

	}
}
