using System.Text.Json.Serialization;

namespace SnipeITdotNET.Api
{


    public class ErrorResponse
    {
        public string status { get; set; }
        public string messages { get; set; }
        public object payload { get; set; }
    }



}
