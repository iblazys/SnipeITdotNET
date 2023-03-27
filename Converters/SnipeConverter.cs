using System.Text.Json;
using System.Text.Json.Serialization;

namespace SnipeITdotNET.Converters
{
    internal class SnipeConverter<T> : JsonConverter<SnipeResult<T>>
    {
        public override SnipeResult<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using JsonDocument jsonDocument = JsonDocument.ParseValue(ref reader);

            var apiResponse = new SnipeResult<T>();

            if (jsonDocument.RootElement.TryGetProperty("status", out JsonElement statusElement))
            {
                if (statusElement.GetString() == "error")
                {
                    apiResponse.Success = false;
                    apiResponse.Message = jsonDocument.RootElement.GetProperty("messages").GetString();
                }
                else
                {
                    apiResponse.Success = true;
                    apiResponse.Data = jsonDocument.Deserialize<T>(options);//JsonSerializer.Deserialize<T>(json, options);
                }
            }
            else
            {
                apiResponse.Success = true;
                apiResponse.Data = jsonDocument.Deserialize<T>(options);//JsonSerializer.Deserialize<T>(json, options);
            }

            return apiResponse;
        }

        public override void Write(Utf8JsonWriter writer, SnipeResult<T> value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
