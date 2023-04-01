using SnipeITdotNET.Model;
using SnipeITdotNET.Model.Assets;
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
        public async Task<SnipeResponse<AssetCollection>> GetAll(NameValueCollection options)
        {
            return await Connection.GetAsync<AssetCollection>($"api/v1/{ServiceName}?{options}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public async Task<SnipeResponse<Asset>> GetById(int id)
        {
            return await Connection.GetAsync<Asset>($"api/v1/{ServiceName}/{id}");
        }

        /// <summary>
        /// Get the API resource at the specified url
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri"></param>
        /// <returns>the specified asset as an object</returns>
        public async Task<SnipeResponse<Asset>> GetByTag(string assetTag, NameValueCollection options)
        {
            return await Connection.GetAsync<Asset>($"api/v1/{ServiceName}/bytag/{assetTag}?{options}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assetSerial"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public async Task<SnipeResponse<AssetCollection>> GetBySerial(string assetSerial, NameValueCollection options)
        {
            return await Connection.GetAsync<AssetCollection>($"api/v1/{ServiceName}/byserial/{assetSerial}?{options}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<SnipeResponse<AssetCollection>> GetDueForAudit()
        {
            return await Connection.GetAsync<AssetCollection>($"api/v1/{ServiceName}/audit/due");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<SnipeResponse<AssetCollection>> GetOverdueForAudit()
        {
            return await Connection.GetAsync<AssetCollection>($"api/v1/{ServiceName}/audit/overdue");
        }

        /// <summary>
        /// Creates a new asset
        /// </summary>
        /// <returns></returns>
        public async Task<SnipeResponse<Asset>> Create()
        {
            //var response = await GetById(1);
            //var data = response.Data;

            var data = new Asset
            {
                AssetTag = "newtest112455",
                Model = new()
                {
                    Id = 1
                },

                StatusLabel = new()
                {
                    Id = 1
                }
            };

            return await Connection.PostAsync<Asset>($"api/v1/{ServiceName}", data);
        }
    }
}
