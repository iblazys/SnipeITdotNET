using SnipeITdotNET.Model;
using SnipeITdotNET.Model.Assets;
using System.Collections.Specialized;

namespace SnipeITdotNET.Clients
{
    /// <summary>
    /// Provides access to the SnipeIT /hardware/ API
    /// </summary>
    public class HardwareClient : SnipeClient<Asset>
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
        public async Task<SnipeResponse<List<Asset>>> GetAll(NameValueCollection options)
        {
            return await Connection.GetAsync<List<Asset>>($"api/v1/{ServiceName}?limit=2");
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
        public async Task<SnipeResponse<List<Asset>>> GetBySerial(string assetSerial, NameValueCollection options)
        {
            return await Connection.GetAsync<List<Asset>>($"api/v1/{ServiceName}/byserial/{assetSerial}?{options}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<SnipeResponse<List<Asset>>> GetDueForAudit()
        {
            return await Connection.GetAsync<List<Asset>>($"api/v1/{ServiceName}/audit/due");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<SnipeResponse<List<Asset>>> GetOverdueForAudit()
        {
            return await Connection.GetAsync<List<Asset>>($"api/v1/{ServiceName}/audit/overdue");
        }

        /// <summary>
        /// Creates a new asset
        /// </summary>
        /// <returns></returns>
        public override async Task<SnipeResponse<Asset>> Create(IApiModel data)
        {
            // TODO: Validate

            return await Connection.PostAsync<Asset>($"api/v1/{ServiceName}", data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public override async Task<SnipeResponse<Asset>> Update(IApiModel data)
        {
            // TODO: Validate

            return await Connection.PutAsync<Asset>($"api/v1/{ServiceName}/{data.Id}", data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public override async Task<SnipeResponse<Asset>> PartialUpdate(IApiModel data)
        {
            // TODO: Validate

            return await Connection.PatchAsync<Asset>($"api/v1/{ServiceName}/{data.Id}", data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public override async Task<SnipeResponse<Asset>> Delete(IApiModel data)
        {
            // TODO: Validate

            return await Connection.DeleteAsync<Asset>($"api/v1/{ServiceName}/{data.Id}");
        }
    }
}
