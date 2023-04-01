using SnipeITdotNET.Model;

namespace SnipeITdotNET.Clients
{
    public abstract class SnipeClient<T>
    {
        
        protected abstract SnipeConnection Connection { get; set; }
        public abstract string ServiceName { get; }
        protected SnipeClient(SnipeConnection connection) 
        {
            Connection = connection;
        }

        public abstract Task<SnipeResponse<T>> Create(IApiModel data);
        public abstract Task<SnipeResponse<T>> Update(IApiModel data);
        public abstract Task<SnipeResponse<T>> PartialUpdate(IApiModel data);
        public abstract Task<SnipeResponse<T>> Delete(IApiModel data);
    }
}
