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
			AddContent(_innerJoin, content);

			return this;
		}
	}
}
