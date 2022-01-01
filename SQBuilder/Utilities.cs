using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SQBuilder
{
    internal static class Utilities
    {
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
                var customColumnName = (ColumnNameAttribute)Attribute.GetCustomAttribute(column, typeof(ColumnNameAttribute));

                if (customColumnName != null)
                    columnName = customColumnName.GetColumnName();

                if (string.IsNullOrWhiteSpace(columnName))
                    fields.Add($"{table}{separator}{column.Name}");
                else
                    fields.Add($"{table}{separator}{columnName} AS {column.Name}");
            }

            return fields;
        }
    }
}
