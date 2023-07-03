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
		/// Adicione apenas a condição, a classe adiciona a instrução HAVING
		/// </summary>
		/// <param name="content"></param>
		public virtual IScriptBuilder Having(string content)
		{
			_having.AddContent(content);
			return this;
		}
	}
}
