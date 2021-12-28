namespace SQBuilder
{
    public partial class SQLBuilder
    {
		/// <summary>
		/// Adicione apenas as colunas, a classe adiciona a instrução SELECT
		/// </summary>
		/// <param name="content"></param>
		public SQLBuilder Select(string content)
		{
			AddContent(_select, content);

			return this;
		}
	}
}
