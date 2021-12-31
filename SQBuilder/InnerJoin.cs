namespace SQBuilder
{
	public partial class SQLBuilder
	{
		/// <summary>
		/// Adicione apenas o nome da tabela e referência ON, a classe adiciona a instrução INNER JOIN
		/// </summary>
		/// <param name="content"></param>
		public SQLBuilder InnerJoin(string content)
		{
			if (!string.IsNullOrWhiteSpace(content))
				_join.AddContent($"INNER JOIN {content}");

			return this;
		}
	}
}
