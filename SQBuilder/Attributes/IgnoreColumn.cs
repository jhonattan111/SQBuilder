using System;

namespace SQBuilder.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class IgnoreColumnAttribute : Attribute
    {
        private readonly bool _ignoreColumn;

        public IgnoreColumnAttribute()
        {
            _ignoreColumn = true;
        }

        public bool GetIgnoreColumn()
        {
            return _ignoreColumn;
        }
    }
}
