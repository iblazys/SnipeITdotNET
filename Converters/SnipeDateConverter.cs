using SnipeITdotNET.Model;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SnipeITdotNET.Converters
{
    // Handles the inconsistent date types for the SnipeIT API
    internal class SnipeDateConverter : JsonConverter<SnipeDate>
    {
        public override SnipeDate? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using JsonDocument jsonDocument = JsonDocument.ParseValue(ref reader);

            if(jsonDocument.RootElement.ValueKind == JsonValueKind.String)
            {
                return new SnipeDate
                {
                    DateTime = jsonDocument.RootElement.GetString()

                    // TODO: Formatted
                };
            }

            if(jsonDocument.RootElement.ValueKind == JsonValueKind.Object) 
            {
                return jsonDocument.Deserialize<SnipeDate>();
            }

            throw new JsonException("Unexpected date time format");
        }

        public override void Write(Utf8JsonWriter writer, SnipeDate value, JsonSerializerOptions options)
        {
            // String type - found in asset create
            if (value.Formatted == null)
            {
                writer.WriteStringValue(value.DateTime);
            }
            else
            {
                /*
                 *      "created_at": {
                        "datetime": "2023-04-01 10:42:10",
                        "formatted": "Sat Apr 01, 2023 10:42AM"
                      },
                */

                writer.WriteStartObject();

                writer.WriteString("datetime", value.DateTime);
                writer.WriteString("formatted", value.Formatted);

                writer.WriteEndObject();
            }

            //Console.WriteLine($"DATECONVERTER - DateTime: {value.DateTime} Formatted: {value.Formatted}");
        }
        
    }
}
