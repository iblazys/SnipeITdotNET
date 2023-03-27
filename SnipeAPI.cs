using SnipeITdotNET.Clients;

namespace SnipeITdotNET
{
    public class SnipeAPI
    {
        internal SnipeConnection Connection { get; set; }

        public SnipeAPI(SnipeConnection connection)
        {
            Connection = connection;

            Hardware = new HardwareClient(Connection);
        }

        /// <summary>
        /// Provides access to the SnipeIT /hardware/ API
        /// </summary>
        public HardwareClient Hardware { get; private set; }
    }
}