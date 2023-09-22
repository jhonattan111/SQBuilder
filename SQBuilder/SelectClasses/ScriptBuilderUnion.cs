namespace SQBuilder
{
    public abstract partial class ScriptBuilder : IScriptBuilder
    {
		/// <summary>
		/// Atribui um conjunto union a query
		/// </summary>
		/// <param name="content"></param>
		public virtual IScriptBuilder Union()
		{
            string query = ToScript();
			query += " UNION ";
			_queries.Add(query);
			InitiateLists();
            return this;
		}

		/// <summary>
		/// Atribui um conjunto union all a query
		/// </summary>
		/// <param name="content"></param>
		public virtual IScriptBuilder UnionAll()
		{
            string query = ToScript();
			query += " UNION ALL ";
			_queries.Add(query);
            InitiateLists();
            return this;
		}
	}
}
