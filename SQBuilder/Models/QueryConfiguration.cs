using System.Text.Json.Serialization;

namespace SQBuilder.Models
{
    public  class QueryConfiguration
    {
        [JsonPropertyName("DefaultSchema")]
        public string Schema { get; set; }
        public string InicialDelimiter { get; set; }
        public string FinalDelimiter { get; set; }
    }
}
