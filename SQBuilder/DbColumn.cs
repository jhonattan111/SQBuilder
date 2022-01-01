using System;

namespace SQBuilder
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ColumnNameAttribute : Attribute
    {
        private string _dbColumnName { get; set; }

        public ColumnNameAttribute(string dbColumnName)
        {
            _dbColumnName = dbColumnName;
        }

        public string GetColumnName()
        {
            return _dbColumnName;
        }

    }
}
