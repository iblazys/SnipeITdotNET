using SnipeITdotNET.Attributes;
using SnipeITdotNET.Converters;
using System.Text.Json.Serialization;

namespace SnipeITdotNET.Model
{
    public class ApiModel : IApiModel
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        [RequiredRequestHeader("name")]
        public string Name { get; set; }

        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(SnipeDateConverter))]
        public SnipeDate CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        [JsonConverter(typeof(SnipeDateConverter))]
        public SnipeDate UpdatedAt { get; set; }


        public virtual Dictionary<string, string> BuildHeaders()
        {
            throw new NotImplementedException();
        }
    }
}
