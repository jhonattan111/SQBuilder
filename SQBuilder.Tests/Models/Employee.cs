using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQBuilder.Tests.Models
{
    internal class Employee
    {
        [ColumnName("i_employee")]
        public int Id { get; set; }
        [ColumnName("name_emp")]
        public string Name { get; set; }
    }
}
