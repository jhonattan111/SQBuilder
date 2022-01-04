using SQBuilder.Attributes;

namespace SQBuilder.Tests.Models
{
    internal class Employee
    {
        [ColumnName("i_employee")]
        public int Id { get; set; }
        [ColumnName("name_emp")]
        public string Name { get; set; }
        [IgnoreColumn]
        public string Adress { get; set; }
    }
}
