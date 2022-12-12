﻿using SQBuilder.Attributes;
using SQBuilder.Enums;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SQBuilder
{
    internal static class Utilities
    {
        internal static void AddContent(this IList<Tuple<EJoinTypes, string>> _list, Tuple<EJoinTypes, string> content, bool condition = true)
        {
            if (!string.IsNullOrEmpty(content.Item2) && condition)
                _list.Add(content);
        }

        internal static void AddContent(this IList<string> _list, string content, bool condition = true)
        {
            if (!string.IsNullOrEmpty(content) && condition)
                _list.Add(content);
        }

        internal static List<string> ReadFields(this object obj, string table = "")
        {
            var fields = new List<string>();

            var objProperties = obj.GetType();

            string separator = string.IsNullOrWhiteSpace(table) ? "" : ".";

            foreach(var column in objProperties.GetProperties())
            {
                string columnName = string.Empty;
                var customColumnName = GetAttribute<ColumnNameAttribute>(column);
                var IgnoreColumn = GetAttribute<IgnoreColumnAttribute>(column);

                if (IgnoreColumn != null && IgnoreColumn.GetIgnoreColumn())
                    continue;

                if (customColumnName != null)
                    columnName = customColumnName.GetColumnName();

                if (string.IsNullOrWhiteSpace(columnName))
                    fields.Add($"{table}{separator}{column.Name}");
                else
                    fields.Add($"{table}{separator}{columnName} AS {column.Name}");
            }

            return fields;
        }

        private static TModel GetAttribute<TModel>(PropertyInfo propertyInfo) where TModel : Attribute
        {
            var attr = (TModel)Attribute.GetCustomAttribute(propertyInfo, typeof(TModel));

            return attr;
        }
    }
}
