namespace SnipeITdotNET.Clients
{
    public abstract class SnipeClient
    {
        protected abstract SnipeConnection Connection { get; set; }
        public abstract string ServiceName { get; }
        protected SnipeClient(SnipeConnection connection) 
        {
            Connection = connection;
        }
    }
}
