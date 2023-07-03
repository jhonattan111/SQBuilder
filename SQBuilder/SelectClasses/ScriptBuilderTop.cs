namespace SQBuilder
{
    public abstract partial class ScriptBuilder : IScriptBuilder
    {
		/// <summary>
		/// O numero de elementos a ser tragos na query
		/// </summary>
		/// <param name="content"></param>
		public virtual IScriptBuilder Top(int top)
		{
			_top = top;
			return this;
		}

        public virtual IScriptBuilder Limit(int limit)
        {
			_top = limit;
            return this;
        }
    }
}
