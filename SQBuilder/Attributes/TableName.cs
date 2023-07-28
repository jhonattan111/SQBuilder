using System;

namespace SQBuilder.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TableNameAttribute : Attribute
    {
        private readonly string _dbTableName;

        public TableNameAttribute(string dbTableName)
        {
            _dbTableName = dbTableName;
        }

        public string GetTableName()
        {
            return _dbTableName;
        }
    }
}
