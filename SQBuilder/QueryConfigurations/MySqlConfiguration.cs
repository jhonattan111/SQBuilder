namespace SQBuilder.Configurations
{
    public class MySqlConfiguration : BaseConfiguration
    {
        private const string DEFAULT_SCHEMA = "";
        private const string START_DELIMITER = "`";
        private const string FINAL_DELIMITER = "`";
        private const string SEPARATOR = ".";

        public MySqlConfiguration() : base(DEFAULT_SCHEMA, START_DELIMITER, FINAL_DELIMITER, SEPARATOR)
        {
        }

        public MySqlConfiguration(string schema) : base(schema, START_DELIMITER, FINAL_DELIMITER, SEPARATOR)
        {
        }

        public MySqlConfiguration(string schema, string startDelimiter, string finalDelimiter, string separator) : base(schema, startDelimiter, finalDelimiter, separator)
        {
        }
    }
}

