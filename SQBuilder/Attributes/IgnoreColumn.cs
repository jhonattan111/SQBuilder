using System;

namespace SQBuilder.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class IgnoreColumnAttribute : Attribute
    {
        private bool _ignoreColumn { get; set; }

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
