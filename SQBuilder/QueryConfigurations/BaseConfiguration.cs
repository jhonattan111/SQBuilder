namespace SQBuilder.Configurations
{
    public abstract class BaseConfiguration
    {
        public BaseConfiguration(string defaultSchema, string startDelimiter, string finalDelimiter, string separator)
        {
            DefaultSchema = defaultSchema;
            StartDelimiter = startDelimiter;
            FinalDelimiter = finalDelimiter;
            Separator = separator;
        }
        public string DefaultSchema { get; set; }
        public string StartDelimiter { get; set; }
        public string FinalDelimiter { get; set; }
        public string Separator { get; set; }
    }
}