using SQBuilder.Enums;
using System;

namespace SQBuilder
{
    public abstract partial class ScriptBuilder : IScriptBuilder
    {
		/// <summary>
		/// Adicione apenas o nome da tabela e referência ON, a classe adiciona a instrução RIGHT JOIN
		/// </summary>
		/// <param name="content"></param>
		public IScriptBuilder RightJoin(string content)
		{
			if (!string.IsNullOrWhiteSpace(content))
				_join.AddContent(Tuple.Create(EJoinTypes.RightJoin, content));

			return this;
		}

        /// <summary>
        /// Adicione apenas o nome da tabela e referência ON, a classe adiciona a instrução LEFT JOIN
        /// </summary>
        /// <param name="content"></param>
        public IScriptBuilder RightJoin(string content, string on)
        {
            string clausure = $"{content} ON {on}";
            return RightJoin(clausure);
        }
    }
}
