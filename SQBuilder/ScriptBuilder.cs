using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SQBuilder.Enums;

namespace SQBuilder
{
    public abstract partial class ScriptBuilder : IScriptBuilder
    {
        public string Schema { get; private set; }
        public string InicialDelimiter { get; private set; }
        public string FinalDelimiter { get; private set; }

        protected string _query { get; set; }
        protected List<string> _queries { get; set; }
        protected List<string> _select { get; set; }
        protected List<string> _from { get; set; }
        protected List<string> _where { get; set; }
        protected List<Tuple<EJoinTypes, string>> _join { get; set; }
        protected List<string> _groupBy { get; set; }
        protected List<string> _orderBy { get; set; }
        protected List<string> _having { get; set; }
        protected uint _top { get; set; }
        public ScriptBuilder()
        {
            InitiateLists();
            _queries = new List<string>();
        }

        protected void SetTop(uint top)
        {
            if (top > 0) _top = top;
        }

        public void InitiateLists()
        {
            _select = new List<string>();
            _from = new List<string>();
            _where = new List<string>();
            _join = new List<Tuple<EJoinTypes, string>>();
            _groupBy = new List<string>();
            _orderBy = new List<string>();
            _having = new List<string>();
        }

        #region Tranformar em uma consulta
        public virtual string ToScript()
        {
            _query = string.Empty;

            AssemblyUnion();
            AssemblySelect();
            AssemblyFrom();
            AssemblyJoin();
            AssemblyWhere();
            AssemblyGroupBy();
            AssemblyHaving();
            AssemblyOrderBy();

            return Regex.Replace(_query, @"\s+", " ", RegexOptions.Multiline).Trim();
        }
        #endregion

        public virtual void AssemblyUnion()
        {
            if (_queries.Count > 0)
                _query += string.Join(@" ", _queries.Where(d => !string.IsNullOrWhiteSpace(d)));
        }

        public virtual void AssemblySelect()
        {
            if (_select.Count > 0)
                _query += " SELECT ";

            _query += string.Join(@", ", _select.Where(d => !string.IsNullOrWhiteSpace(d)));
        }

        public virtual void AssemblyFrom()
        {
            if (_select.Count > 0)
                _query += " FROM ";

            _query += string.Join(@", ", _from.Where(d => !string.IsNullOrWhiteSpace(d)));
        }

        public virtual void AssemblyJoin()
        {
            if (_join.Count > 0)
                foreach (Tuple<EJoinTypes, string> item in _join)
                    _query += $"{item} ";
        }

        public virtual void AssemblyWhere()
        {
            if (_where.Count > 0)
                _query += " WHERE ";

            _query += string.Join(@" AND ", _where.Where(d => !string.IsNullOrWhiteSpace(d)));
        }

        public virtual void AssemblyGroupBy()
        {
            if (_groupBy.Count > 0)
                _query += " GROUP BY ";

            _query += string.Join(@", ", _groupBy.Where(d => !string.IsNullOrWhiteSpace(d)));
        }

        public virtual void AssemblyOrderBy()
        {
            if (_orderBy.Count > 0)
                _query += " ORDER BY ";

            _query += string.Join(@", ", _orderBy.Where(d => !string.IsNullOrWhiteSpace(d)));
        }

        public virtual void AssemblyHaving()
        {
            if (_having.Count > 0)
                _query += " HAVING ";

            _query += string.Join(@" AND ", _having.Where(d => !string.IsNullOrWhiteSpace(d)));
        }
    }
}
