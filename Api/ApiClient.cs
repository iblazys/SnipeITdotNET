using RestSharp;

namespace SnipeITdotNET.Api
{
    public class ApiRequest
    {
        public string ApiKey { get; set; }
        public string BaseUrl { get; set; }
        public string RequestUrl { get; set; }

        public ApiRequest(string apiKey, string baseUrl, string requestUrl)
        {
            ApiKey = apiKey;
            BaseUrl = baseUrl;
            RequestUrl = requestUrl;
        }

        public RestResponse Execute(Method method)
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest(RequestUrl, method);

            request.Timeout = 5000;

            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {ApiKey}");
            
            var response = client.Execute(request);

            return response;
        }
    }
}
