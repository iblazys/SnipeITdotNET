using System.Text.Json;

namespace SnipeITdotNET
{
    public class SnipeResult<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        /// <summary>
        /// Wrapper for the SnipeIT API responses, as they are all different.
        /// </summary>
        /// <param name="json"></param>
        /// <returns>a formatted SnipeResult</returns>
        /*
        public static SnipeResult<T> FromJson(string json)
        {

            var apiResponse = new SnipeResult<T>();

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var jsonDocument = JsonDocument.Parse(json);

            // Wont detect unauthorized errors, SnipeConnection.cs will handle that.

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
        */
    }
}
