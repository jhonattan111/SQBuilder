using SQBuilder.Attributes;
using SQBuilder.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading;

namespace SQBuilder
{
    internal static class Utilities
    {
        internal static void AddContent(this IList<Tuple<EJoinTypes, string>> _list, Tuple<EJoinTypes, string> content, bool condition = true)
        {
            if (!string.IsNullOrEmpty(content.Item2) && condition)
                _list.Add(content);
        }

        internal static IEnumerable<TModel> DeserializeJson<TModel>(string filePath) where TModel : class 
        {
            string data = File.ReadAllText(filePath);
            IEnumerable<TModel> deserialized = JsonSerializer.Deserialize<IEnumerable<TModel>>(data).ToList();
            return deserialized;
        }

        internal static void AddContent(this IList<string> _list, string content, bool condition = true)
        {
            if (!string.IsNullOrEmpty(content) && condition)
                _list.Add(content);
        }

        internal static List<string> ReadFields(this object obj, string table = "", EDatabases database = EDatabases.SQLServer)
        {
            List<string> fields = new();

            Type objProperties = obj.GetType();
            TableNameAttribute customTableName = objProperties.GetCustomAttribute<TableNameAttribute>();
            if (!string.IsNullOrEmpty(customTableName?.GetTableName()))
                table = customTableName?.GetTableName();

            string separator = string.IsNullOrWhiteSpace(table) ? "" : ".";

            foreach(PropertyInfo column in objProperties.GetProperties())
            {
                string columnName = string.Empty;
                ColumnNameAttribute customColumnName = GetAttribute<ColumnNameAttribute>(column);
                IgnoreColumnAttribute IgnoreColumn = GetAttribute<IgnoreColumnAttribute>(column);

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
            TModel attr = (TModel)Attribute.GetCustomAttribute(propertyInfo, typeof(TModel));
            return attr;
        }
    }
}
