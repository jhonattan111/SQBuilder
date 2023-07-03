using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQBuilder
{
    public abstract partial class ScriptBuilder : IScriptBuilder
    {
		/// <summary>
		/// Adicione apenas o nome da tabela, a classe adiciona a instrução GROUP BY
		/// </summary>
		/// <param name="content"></param>
		public virtual IScriptBuilder GroupBy(string content)
		{	
			_groupBy.AddContent(content);

			return this;
		}
	}
}
