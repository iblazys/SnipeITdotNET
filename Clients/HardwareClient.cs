using SnipeITdotNET.Model;
using System.Collections.Specialized;
using System.Text.Json;

namespace SnipeITdotNET.Clients
{
    /// <summary>
    /// Provides access to the SnipeIT /hardware/ API
    /// </summary>
    public class HardwareClient : SnipeClient
    {
        public override string ServiceName => "hardware";
        protected override SnipeConnection Connection { get; set; }

        public HardwareClient(SnipeConnection connection) : base(connection)
        {
            Connection = connection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public async Task<SnipeResult<AssetCollection>> GetAll(NameValueCollection options)
        {
            return await Connection.GetAsync<AssetCollection>($"api/v1/{ServiceName}?{options}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public async Task<SnipeResult<Asset>> GetById(int id)
        {
            return await Connection.GetAsync<Asset>($"api/v1/{ServiceName}/{id}");
        }

        /// <summary>
        /// Get the API resource at the specified url
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri"></param>
        /// <returns>the specified asset as an object</returns>
        public async Task<SnipeResult<Asset>> GetByTag(string assetTag, NameValueCollection options)
        {
            return await Connection.GetAsync<Asset>($"api/v1/{ServiceName}/bytag/{assetTag}?{options}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assetSerial"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public async Task<SnipeResult<Asset>> GetBySerial(string assetSerial, NameValueCollection options)
        {
            return await Connection.GetAsync<Asset>($"api/v1/{ServiceName}/byserial/{assetSerial}?{options}");
        }
    }
}
