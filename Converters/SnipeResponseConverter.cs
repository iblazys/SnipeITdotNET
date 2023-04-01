using SnipeITdotNET.Model;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SnipeITdotNET.Converters
{
    internal class SnipeResponseConverter<T> : JsonConverter<SnipeResponse<T>>
    {
        public override SnipeResponse<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // All this is needed due to the inconsistency of the SnipeIT API responses.

            using JsonDocument jsonDocument = JsonDocument.ParseValue(ref reader);

            var apiResponse = new SnipeResponse<T>();

            // Handle Status
            if (jsonDocument.RootElement.TryGetProperty("status", out JsonElement statusElement))
            {
                apiResponse.Status = statusElement.GetString();

                // Handle messages
                if (jsonDocument.RootElement.TryGetProperty("messages", out JsonElement messages))
                {
                    // Handles "messages" when it is an object of arrays
                    if (messages.ValueKind == JsonValueKind.Object)
                    {
                        var enumerator = messages.EnumerateObject();

                        apiResponse.Messages = new string[enumerator.Count()];

                        for (int i = 0; i < enumerator.Count(); i++)
                        {
                            // Rough way - need to get actual array values
                            // Currently outputting "[\u0022The asset tag must be unique.\u0022]"
                            apiResponse.Messages[i] = enumerator.ElementAt(i).Value.ToString();
                        }
                    }
                    else
                    {
                        // TODO: handle "message" aswell.. comes from error 401 / 405
                        // Handle a single message
                        apiResponse.Messages = new string[1];
                        apiResponse.Messages[0] = jsonDocument.RootElement.GetProperty("messages").ToString();
                    }
                }
            }

            // Handle payload
            if (jsonDocument.RootElement.TryGetProperty("payload", out JsonElement payload))
            {
                // If we have a payload section, it is usually coming from a POST/PUT/PATCH etc
                apiResponse.Data = payload.Deserialize<T>(options);
            }
            else
            {
                // No payload section is usually a GET request and those differ aswell.
                apiResponse.Data = jsonDocument.Deserialize<T>(options);
            }

            return apiResponse;
        }

        public override void Write(Utf8JsonWriter writer, SnipeResponse<T> value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
