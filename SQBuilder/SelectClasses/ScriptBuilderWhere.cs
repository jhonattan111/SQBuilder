using System.Collections.Generic;
using System.Linq;

namespace SQBuilder
{
    public abstract partial class ScriptBuilder : IScriptBuilder
    {
		/// <summary>
        /// Adicione apenas as cláusulas e a condição para a inclusão, a classe adiciona a instrução WHERE
        /// </summary>
        /// <param name="content"></param>
        /// <param name="condition"></param>
        public virtual IScriptBuilder Where(string content, bool condition = true)
		{
			if(condition)
				_where.AddContent(content, condition);

			return this;
		}

		/// <summary>
		/// Adicione uma lista que será colocada em uma cláusula IN, a classe adiciona a instrução WHERE
		/// </summary>
		/// <param name="content"></param>
		/// <param name="condition"></param>
		public virtual IScriptBuilder Where(List<string> content, string column)
		{
            string list = string.Join("', '", content);

			if (content.Count > 0)
				_where.AddContent($"{column} IN ('{list}')");

			return this;
		}

        /// <summary>
        /// Adicione uma lista que será colocada em uma cláusula IN, a classe adiciona a instrução WHERE
        /// </summary>
        /// <param name="content"></param>
        /// <param name="condition"></param>
        public virtual IScriptBuilder Where(List<string> content, string column, bool condition = true)
		{
			if (condition)
				Where(content, column);

			return this;
		}

		/// <summary>
		/// Adicione uma lista que será colocada em uma cláusula IN, a classe adiciona a instrução WHERE
		/// </summary>
		/// <param name="content"></param>
		/// <param name="column"></param>
		/// <param name="condition"></param>
		public virtual IScriptBuilder Where(List<int> content, string column, bool condition = true)
		{
			if (condition)
            {
                List<string> list = content.Select(d => d.ToString()).ToList();
				Where(list, column);
			}

			return this;
		}
	}
}
