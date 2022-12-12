namespace SQBuilder
{
    public abstract partial class ScriptBuilder : IScriptBuilder
    {
		/// <summary>
		/// Atribui um conjunto union a query
		/// </summary>
		/// <param name="content"></param>
		public IScriptBuilder Union()
		{
			var query = ToScript();
			query += " UNION ";
			_queries.Add(query);
			InicitiateLists();
            return this;
		}

		/// <summary>
		/// Atribui um conjunto union all a query
		/// </summary>
		/// <param name="content"></param>
		public IScriptBuilder UnionAll()
		{
			var query = ToScript();
			query += " UNION ALL ";
			_queries.Add(query);
            InicitiateLists();
            return this;
		}
	}
}
