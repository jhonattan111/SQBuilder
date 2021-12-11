namespace SQBuilder
{
    public partial class SQBuilder
    {
		/// <summary>
		/// Adicione apenas as colunas, a classe adiciona a instrução SELECT
		/// </summary>
		/// <param name="content"></param>
		public SQBuilder Select(string content)
		{
			_select.Add(content);

			return this;
		}
	}
}
