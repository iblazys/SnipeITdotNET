using System.Text.Json.Serialization;

namespace SnipeITdotNET.Model
{
    public class AssetCollection
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("rows")]
        public Asset[] Assets { get; set; }
    }
}
