namespace SQBuilder
{
    public abstract partial class ScriptBuilder : IScriptBuilder
    {
        /// <summary>
        /// Adicione apenas o nome da tabela, a classe adiciona a instrução FROM
        /// </summary>
        /// <param name="content"></param>
        public virtual IScriptBuilder From(string content)
        {
            _from.Add(content);
            return this;
        }
    }
}
