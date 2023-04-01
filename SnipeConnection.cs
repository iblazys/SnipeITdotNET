using SnipeITdotNET.Converters;
using SnipeITdotNET.Model;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.Serialization;
using System.Text.Json;

namespace SnipeITdotNET
{
    public class SnipeConnection
    {
        public Uri ApiBaseUrl { get; private set; }
        public string ApiKey { get; private set; }

        private JsonSerializerOptions serializerOptions = new JsonSerializerOptions();

        public SnipeConnection(string apiUrl, string apiKey)
        {
            ApiBaseUrl = new Uri(apiUrl);

            ApiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));

            if (!ApiBaseUrl.IsAbsoluteUri)
            {
                throw new ArgumentException("the api url must be and absolute uri!");
            }

            TestConnection();
        }

        public bool TestConnection()
        {
            //GetAsString("api/v1/hardware/audit/due");
            return false;
        }

        internal string GetAsString(string serviceUrl)
        {
            using var client = new HttpClient();

            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {ApiKey}");

            var response =  client.GetAsync(ApiBaseUrl.AbsoluteUri + serviceUrl).Result;

            return response.Content.ReadAsStringAsync().Result;
        }

        internal SnipeResponse<T> Get<T>(string serviceUrl)
        {

            return new SnipeResponse<T>();
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

        // non async Get

        /// <summary>
        /// Gets the resource at the specified api url
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serviceUrl"></param>
        /// <returns>the json data in an object format</returns>
        /// <exception cref="SerializationException"></exception>
        internal async Task<SnipeResponse<T>> GetAsync<T>(string serviceUrl)
        {
            using var client = new HttpClient();

            serializerOptions.Converters.Add(new SnipeResponseConverter<T>());

            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {ApiKey}");

            string url = ApiBaseUrl.AbsoluteUri + serviceUrl;

            var response = await client.GetAsync(url);

            var content = await response.Content.ReadFromJsonAsync<SnipeResponse<T>>(serializerOptions);

            return content;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serviceUrl"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        internal async Task<SnipeResponse<T>> PostAsync<T>(string serviceUrl, IApiModel data)
        {
            // What an absolute mess the SnipeIT API is....
            using var client = new HttpClient();
            string url = ApiBaseUrl.AbsoluteUri + serviceUrl;

            serializerOptions.Converters.Add(new SnipeResponseConverter<T>());

            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {ApiKey}");
           
            var headers = data.BuildHeaders();
            var jsonString = new StringContent(JsonSerializer.Serialize(headers));
            jsonString.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(url, jsonString);

            Console.WriteLine(await response.Content.ReadAsStringAsync());

            var content = await response.Content.ReadFromJsonAsync<SnipeResponse<T>>(serializerOptions);

            return content;
        }
    }
}
