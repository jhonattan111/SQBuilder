namespace SQBuilder
{
    public abstract partial class ScriptBuilder : IScriptBuilder
    {
		/// <summary>
		/// O numero de elementos a ser tragos na query
		/// </summary>
		/// <param name="content"></param>
		public IScriptBuilder Top(int top)
		{
			_top = top;
			return this;
		}

        public IScriptBuilder Limit(int limit)
        {
			_top = limit;
            return this;
        }
    }
}
