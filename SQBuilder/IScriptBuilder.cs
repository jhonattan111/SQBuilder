using System.Collections.Generic;

namespace SQBuilder
{
    public interface IScriptBuilder
    {
        string ToScript();
        IScriptBuilder Select(string content, uint limit = 0);
        IScriptBuilder Select(IEnumerable<string> content, uint limit = 0);
        IScriptBuilder Select<TModel>(string table = "") where TModel : class;
        IScriptBuilder From(string content);
        IScriptBuilder LeftJoin(string content);
        IScriptBuilder LeftJoin(string content, string on);
        IScriptBuilder LeftJoin<T>(string alias);
        IScriptBuilder RightJoin(string content);
        IScriptBuilder RightJoin(string content, string on);
        IScriptBuilder RightJoin<T>(string alias);
        IScriptBuilder InnerJoin(string content);
        IScriptBuilder InnerJoin(string content, string on);
        IScriptBuilder InnerJoin<T>(string alias);
        IScriptBuilder LeftOuterJoin(string content);
        IScriptBuilder LeftOuterJoin(string content, string on);
        IScriptBuilder LeftOuterJoin<T>(string alias);
        IScriptBuilder RightOuterJoin(string content);
        IScriptBuilder RightOuterJoin(string content, string on);
        IScriptBuilder RightOuterJoin<T>(string alias);
        IScriptBuilder Where(string content, bool condition = true);
        IScriptBuilder Where(List<int> content, string column, bool condition = true);
        IScriptBuilder Where(List<string> content, string column, bool condition = true);
        IScriptBuilder Top(uint top);
        IScriptBuilder Limit(uint limit);
        IScriptBuilder Union();
        IScriptBuilder UnionAll();
        IScriptBuilder GroupBy(string content);
        IScriptBuilder OrderBy(string content);
        IScriptBuilder Having(string content);
    }
}
