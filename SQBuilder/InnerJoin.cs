namespace SQBuilder
{
	public partial class SQBuilder
	{
		/// <summary>
		/// Adicione apenas o nome da tabela e referência ON, a classe adiciona a instrução INNER JOIN
		/// </summary>
		/// <param name="content"></param>
		public SQBuilder InnerJoin(string content)
		{
			_innerJoin.Add(content);

			return this;
		}
	}
}
