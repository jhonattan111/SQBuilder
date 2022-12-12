using System.Collections.Generic;

namespace SQBuilder
{
    public interface IScriptBuilder
    {
        string ToScript();
        IScriptBuilder Select(string content);
        IScriptBuilder Select(IEnumerable<string> content);
        IScriptBuilder Select<TModel>(string table = "") where TModel : class;
        IScriptBuilder From(string content);
        IScriptBuilder LeftJoin(string content);
        IScriptBuilder LeftJoin(string content, string on);
        IScriptBuilder RightJoin(string content);
        IScriptBuilder RightJoin(string content, string on);
        IScriptBuilder InnerJoin(string content);
        IScriptBuilder InnerJoin(string content, string on);
        IScriptBuilder LeftOuterJoin(string content);
        IScriptBuilder LeftOuterJoin(string content, string on);
        IScriptBuilder RightOuterJoin(string content);
        IScriptBuilder RightOuterJoin(string content, string on);
        IScriptBuilder Where(List<int> content, string column, bool condition);
        IScriptBuilder Where(List<string> content, string column, bool condition);
        IScriptBuilder Where(List<int> content, string column);
        IScriptBuilder Where(List<string> content, string column);
        IScriptBuilder Top(int top);
        IScriptBuilder Limit(int limit);
        IScriptBuilder Union();
        IScriptBuilder UnionAll();
    }
}
