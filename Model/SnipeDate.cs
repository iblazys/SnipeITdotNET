using System.Text.Json.Serialization;

namespace SnipeITdotNET.Model
{
    public class SnipeDate
    {
        [JsonPropertyName("datetime")]
        public string DateTime { get; set; }

        [JsonPropertyName("formatted")]
        public string Formatted { get; set; }
    }
}
