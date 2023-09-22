namespace SQBuilder.Configurations
{
    public class SqlServerConfiguration : BaseConfiguration
    {
        private const string DEFAULT_SCHEMA = "dbo";
        private const string START_DELIMITER = "[";
        private const string FINAL_DELIMITER = "]";
        private const string SEPARATOR = ".";

        public SqlServerConfiguration() : base(DEFAULT_SCHEMA, START_DELIMITER, FINAL_DELIMITER, SEPARATOR)
        {
        }

        public SqlServerConfiguration(string schema) : base(schema, START_DELIMITER, FINAL_DELIMITER, SEPARATOR)
        {
        }

        public SqlServerConfiguration(string schema, string startDelimiter, string finalDelimiter, string separator) : base(schema, startDelimiter, finalDelimiter, separator)
        {
        }
    }
}