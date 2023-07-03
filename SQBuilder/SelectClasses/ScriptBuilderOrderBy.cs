namespace SQBuilder
{
    public abstract partial class ScriptBuilder : IScriptBuilder
    {
		/// <summary>
		/// Adicione apenas o nome da coluna, a classe adiciona a instrução ORDER BY
		/// </summary>
		/// <param name="content"></param>
		public virtual IScriptBuilder OrderBy(string content)
		{
			_orderBy.AddContent(content);
			return this;
		}
	}
}
