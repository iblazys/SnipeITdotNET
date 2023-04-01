using System.Text.Json.Serialization;

namespace SnipeITdotNET.Model.Assets
{
    public class AssetCollection
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("rows")]
        public Asset[] Assets { get; set; }
    }
}
