using SnipeITdotNET.Converters;
using System.Net.Http.Json;
using System.Runtime.Serialization;
using System.Text.Json;

namespace SnipeITdotNET
{
    public class SnipeConnection
    {
        public Uri ApiBaseUrl { get; private set; }
        public string ApiKey { get; private set; }

        public SnipeConnection(string apiUrl, string apiKey)
        {
            ApiBaseUrl = new Uri(apiUrl);

            ApiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));

            if (!ApiBaseUrl.IsAbsoluteUri)
            {
                throw new ArgumentException("the api url must be and absolute uri!");
            }
        }

        public bool TestConnection()
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceUrl"></param>
        /// <returns></returns>
        internal async Task<string> GetAsStringAsync(string serviceUrl)
        {
            using var client = new HttpClient();

            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {ApiKey}");

            var response = await client.GetAsync(ApiBaseUrl.AbsoluteUri + serviceUrl);

            return await response.Content.ReadAsStringAsync();  
        }

        /// <summary>
        /// Gets the resource at the specified api url
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serviceUrl"></param>
        /// <returns>the json data in string format</returns>
        /// <exception cref="SerializationException"></exception>
        internal async Task<SnipeResult<T>> GetAsync<T>(string serviceUrl) where T : new()
        {
            using var client = new HttpClient();
            var options = new JsonSerializerOptions();
            options.Converters.Add(new SnipeConverter<T>());

            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {ApiKey}");

            string url = ApiBaseUrl.AbsoluteUri + serviceUrl;

            var response = await client.GetAsync(url);

            var content = await response.Content.ReadFromJsonAsync<SnipeResult<T>>(options);

            /* works
            var content = await response.Content.ReadAsStringAsync();
            var result = SnipeResult<T>.FromJson(content);
            */

            return content;
        }
    }
}
