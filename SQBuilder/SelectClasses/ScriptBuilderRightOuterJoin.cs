﻿using SQBuilder.Enums;
using System;
using System.Reflection;

namespace SQBuilder
{
    public abstract partial class ScriptBuilder : IScriptBuilder
    {
        /// <summary>
        /// Adicione apenas o nome da tabela e referência ON, a classe adiciona a instrução RIGHT JOIN
        /// </summary>
        /// <param name="content"></param>
        public virtual IScriptBuilder RightOuterJoin(string content)
        {
            if (!string.IsNullOrWhiteSpace(content))
                _join.AddContent(Tuple.Create(EJoinTypes.RightOuterJoin, content));

            return this;
        }

        /// <summary>
        /// Adicione apenas o nome da tabela e referência ON, a classe adiciona a instrução LEFT JOIN
        /// </summary>
        /// <param name="content"></param>
        public virtual IScriptBuilder RightOuterJoin(string content, string on)
        {
            string clausure = $"{content} ON {on}";
            return RightOuterJoin(clausure);
        }

        //TODO
        public virtual IScriptBuilder RightOuterJoin<T>(string alias)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();

            //Utilities.GetAttribute<ColumnAttribute>();

            return LeftJoin("");
        }
    }
}