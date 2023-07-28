using SQBuilder.Attributes;

namespace SQBuilder.Tests.Models
{
    [TableName("Company")]
    internal class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
