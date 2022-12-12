using SQBuilder.Enums;
using System;

namespace SQBuilder
{
	public abstract partial class ScriptBuilder : IScriptBuilder
    {
		/// <summary>
		/// Adicione apenas o nome da tabela e referência ON, a classe adiciona a instrução LEFT JOIN
		/// </summary>
		/// <param name="content"></param>
		public IScriptBuilder LeftJoin(string content)
		{
			if(!string.IsNullOrWhiteSpace(content))
				_join.AddContent(Tuple.Create(EJoinTypes.LeftJoin, content));

			return this;
		}

        /// <summary>
        /// Adicione apenas o nome da tabela e referência ON, a classe adiciona a instrução LEFT JOIN
        /// </summary>
        /// <param name="content"></param>
        public IScriptBuilder LeftJoin(string content, string on)
        {
            string clausure = $"{content} ON {on}";

            return LeftJoin(clausure);
        }
    }
}
