using System.Linq;

namespace SQBuilder.Providers.SqlServer
{
    public partial class SqlServerScriptBuilder : ScriptBuilder
    {
        public override void AssemblySelect()
        {
            if (_select.Count > 0)
                _query += " SELECT ";

            if (_top > 0)
                _query += $" TOP {_top} ";

            _query += string.Join(@", ", _select.Where(d => !string.IsNullOrWhiteSpace(d)));
        }
    }
}
