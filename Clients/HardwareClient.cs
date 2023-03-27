using SnipeITdotNET.Model;
using System.Collections.Specialized;
using System.Text.Json;

namespace SnipeITdotNET.Clients
{
    /// <summary>
    /// Provides access to the SnipeIT /hardware/ API
    /// </summary>
    public class HardwareClient
    {
        private SnipeConnection _connection;

        // INTERFACE MUST INCLUDE A CONNECTION

        private readonly string serviceName = "hardware";

        public HardwareClient(SnipeConnection connection)
        {
            _connection = connection;
        }

        public async Task<SnipeResult<Asset>> GetAll(NameValueCollection options)
        {
            return new SnipeResult<Asset>();
        }

        /// <summary>
        /// Get the API resource at the specified url
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri"></param>
        /// <returns>the specified asset as an object</returns>
        public async Task<SnipeResult<Asset>> GetByTag(string assetTag, NameValueCollection options)
        {
            return await _connection.GetAsync<Asset>($"api/v1/{serviceName}/bytag/{assetTag}?{options}");
        }
    }
}
